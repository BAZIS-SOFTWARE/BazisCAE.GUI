using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BaseControl;
using ToolStrips;
using Model;
using ModelController.MeshObjsCreator;
using Project.Interfaces;
using Project.TasksData;
using Scene.Events;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ModelControl
{
    public partial class ModelPage: BasePage
    {
        Dictionary<string, int> imgDict;

        private int nodesObjsIndex = 3;
        private int elementsObjsIndex = 4;

        public ModelPage()
        {
            InitializeComponent();

            TreeView.ImageList = treeNodesImageList;

            ProjectInfoIndex = 2;
            CollapseIndex = 0;
            ExpandIndex = 1;

            imgDict = new Dictionary<string, int>()
            {
                { "Узлы",nodesObjsIndex},
                { "Элементы3D",elementsObjsIndex},
                { "Элементы2D",elementsObjsIndex},
            };

            var meshToolStrip = new MeshToolStrip();
            meshToolStrip.Renderer = new BtnToolStrRender();
            meshToolStrip.ItemClicked += MeshToolStrip_ItemClicked;
            
            AddToolStrip(meshToolStrip);

            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            SetVersion(verStr);
        }

        public override void CreateMenuInterface()
        {
            AddToolStripMenuItem(AddMeshInterface());
        }

        private ToolStripMenuItem AddMeshInterface()
        {
            ToolStripMenuItem meshMenuItem = new ToolStripMenuItem()
            {
                Name = "meshMenuItem",
                Text = "Сетка"
            };

            ToolStripMenuItem boundaryElements2DMenuItem = new ToolStripMenuItem()
            {
                Name = "boundaryElements2D",
                Text = "Создать поверхностные элементы"
            };

            ToolStripMenuItem meshGeneratorMenuItem = new ToolStripMenuItem()
            {
                Name = "meshGenerator",
                Text = "Генератор сетки"
            };

            meshMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            boundaryElements2DMenuItem,meshGeneratorMenuItem
            });

            boundaryElements2DMenuItem.Click += (ar1, ar2) => { CreateBoundaryElements2D();};
           
            meshGeneratorMenuItem.Click += (ar1, ar2) => {
                var meshFolder = Directory.GetFiles(Application.StartupPath, "Mesh.exe", SearchOption.AllDirectories);
                if (meshFolder.Length > 0)
                {
                    var myProcess = new Process();
                    myProcess.StartInfo.FileName = meshFolder[0];
                    myProcess.Start();
                };
            };

            return meshMenuItem;
        }

        private void MeshToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "0")
            {
                CreateBoundaryElements2D();
            }
            else if(e.ClickedItem.Tag.ToString() == "1")
            {
                var mesher = Directory.GetFiles(Application.StartupPath, "mesh.exe", SearchOption.AllDirectories);

                if(mesher.Length > 0)
                {
                    var myProcess = new Process();
                    myProcess.StartInfo.FileName = mesher[0];
                    myProcess.Start();
                }

            }
        }

        private void CreateBoundaryElements2D()
        {
            var els3D = Project.Model.ObjectData.FindMany<Element3D>();

            if(els3D != null)
            {
                var creator = new Extract2DFrom3D(els3D.ToArray());

                var startNumber = Project.Model.ObjectData.GetLastObjNumber() + 1;
                var boundaryElements2D = creator.Create(startNumber);

                Project.Model.ObjectData.AddRange(boundaryElements2D);

                PresentAllModelObjectsOnScene();
                PresentModelOnSelectToolStrip();
                SetModelObjsInfo();

                ConsoleControl.PrintInfo("Созданы 2D элементы", Color.Black);
            }
            else
                ConsoleControl.PrintInfo("Модель не содержит объемных элементов!", Color.Red);

        }

        public IEnumerable<KeyValuePair<string, List<string>>> GetObjectsInfo()
        {
            if(Project != null)
            {
                var objTypes = Project.Model.ObjectData.GetObjectTypes();
                foreach (var objType in objTypes)
                {
                    var objKinds = new List<string>();
                    foreach (var obj in Project.Model.ObjectData.FindMany(objType))
                    {
                        objKinds.Add(obj.ObjKind.ToString());
                    }
                    yield return new KeyValuePair<string, List<string>>(objType, objKinds);
                }
            }

        }


        public IEnumerable<KeyValuePair<string, string>> GetGroupsInfo()
        {
            if (Project != null)
                foreach (var group in Project.Model.GroupData)
                {
                    yield return new KeyValuePair<string, string>(group.GroupName, group.ObjType);
                }
        }      

        public void SetModelObjsInfo()
        {

            TreeView.BeginUpdate();
            TreeView.Nodes["объекты"].Expand();

            TreeView.Nodes["объекты"].Nodes.Clear();
            foreach (var objInfo in GetObjectsInfo())
                CreateNewObjectsNode(objInfo);

            TreeView.EndUpdate();

        }

        public void SetModelGroupInfo()
        {
            TreeView.BeginUpdate();
            TreeView.Nodes["группыОбъектов"].Expand();

            TreeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var grInfo in GetGroupsInfo())
                CreateNewModelGroupNode(grInfo);

            TreeView.EndUpdate();
        }

        private void CreateNewObjectsNode(KeyValuePair<string, List<string>> objInfo)
        {
            var trNode = new TreeNode()
            {
                ContextMenuStrip = object_MenuStrip,
                Name = objInfo.Key,
                Text = string.Format("{0} : {1}", objInfo.Key, objInfo.Value.Count),

                ImageIndex = imgDict[objInfo.Key],
                SelectedImageIndex = imgDict[objInfo.Key],
                Tag = "3.1"
            };

            TreeView.Nodes["объекты"].Nodes.Add(trNode);
        }

        private void CreateNewModelGroupNode(KeyValuePair<string, string> grInfo)
        {
            var trNode = new TreeNode()
            {
                Text = grInfo.Key,
                Name = grInfo.Value,
                ImageIndex = imgDict[grInfo.Value],
                SelectedImageIndex = imgDict[grInfo.Value],
                Tag = "4.1"
            };
            TreeView.Nodes["группыОбъектов"].Nodes.Add(trNode);

            if (imgDict[grInfo.Value] == nodesObjsIndex)
                trNode.ContextMenuStrip = ndGroup_MenuStrip;
            else trNode.ContextMenuStrip = elGroup_MenuStrip;


        }

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            TreeView.LabelEdit = true;
            TreeView.SelectedNode.BeginEdit();
        }

        private void TsiCreateNodeGroup_Click(object sender, EventArgs e)
        {
            //CreateGroupEvent(this, new GroupEvArgs(treeView.SelectedNode.Name, treeView.SelectedNode.Index));
        }     

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.ContextMenuStrip != null)
                    e.Node.ContextMenuStrip.Show(e.Location);
            }
            else
            {
                if (e.Node.Tag.ToString() == "4.1")
                    SelectGroup(e.Node.Text);
            }
            TreeView.SelectedNode = e.Node;
        }

        private void SelectGroup(string groupName)
        {
            try
            {
                SceneControl.SetBackColorToAll_VBObjects();

                var group = Project.Model.GroupData.Find(groupName);

                foreach (var objNumber in group.ObjsNumbers)
                    Project.Model.ObjectData.Find(objNumber).MasterColor = Color.FromArgb(255, 0, 0);

                SceneControl.ChangeColorsVBObjects(group.ObjType);

                SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!TreeView.LabelEdit)
                e.CancelEdit = true;
        }

        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null | e.Label.Contains(" ") == true)
                e.CancelEdit = true;
            else
            {
                var parentNode = TreeView.SelectedNode.Parent;

                var newName = e.Label;
                var oldName = e.Node.Text;

                if (parentNode.Name == "группыОбъектов")
                {
                    RenameGroup(newName, oldName);
                }
            }
            
            TreeView.LabelEdit = false;
        }

        private void RenameGroup(string newName, string oldName)
        {
            var gr = Project.Model.GroupData.Find(oldName);
            if (gr != null)
            {
                gr.GroupName = newName;
                foreach (var data in Project.TaskData)
                {
                    var dataStr = data.GetInfo;
                    if (dataStr.Contains(oldName))
                    {
                        dataStr = dataStr.Replace(oldName, newName);
                        data.SetInfo(dataStr);
                    }
                }
            }

        }

        private void ShowAllObjects_Click(object sender, EventArgs e)
        {
            foreach (var obj in Project.Model.ObjectData)
            {
                obj.ViewState = true;
            }
            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }

        private void ShowAllGroups_Click(object sender, EventArgs e)
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var objNumber in group)
                {
                    Project.Model.ObjectData.Find(objNumber).ViewState = true;
                }
            }
            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }

        private void ShowGroup_Click(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode != null)
                ViewStateGroup(TreeView.SelectedNode.Name, TreeView.SelectedNode.Index, true);

            PresentModelObjectsOnScene(TreeView.SelectedNode.Name);
            SceneControl.DisplayObjects();
        }

        private void HideGroup_Click(object sender, EventArgs e)
        {
            ViewStateGroup(TreeView.SelectedNode.Name, TreeView.SelectedNode.Index, false);

            PresentModelObjectsOnScene(TreeView.SelectedNode.Name);
            SceneControl.DisplayObjects();
        }

        private void ShowObjects_Click(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode != null)
                ViewStateObjects(TreeView.SelectedNode.Name, true);

            PresentModelObjectsOnScene(TreeView.SelectedNode.Name);
            SceneControl.DisplayObjects();
        }

        private void HideObjects_Click(object sender, EventArgs e)
        {
            ViewStateObjects(TreeView.SelectedNode.Name, false);

            PresentModelObjectsOnScene(TreeView.SelectedNode.Name);
            SceneControl.DisplayObjects();
        }

        private void ViewStateObjects(string objsType, bool state)
        {
            var modelObjects = Project.Model.ObjectData.FindMany(objsType).ToArray();
            foreach (var modelObject in modelObjects)
            {
                modelObject.ViewState = state;
            }
        }

        private void ViewStateGroup(string objsType, int groupIndex, bool state)
        {
            var group = Project.Model.GroupData[groupIndex];

            foreach (var number in group.ObjsNumbers)
                Project.Model.ObjectData.Find(number).ViewState = state;

            var modelObjects = Project.Model.ObjectData.FindMany(group.ObjType).ToArray();
        }

        private void HideAllObjects_Click(object sender, EventArgs e)
        {
            foreach (var obj in Project.Model.ObjectData)
            {
                obj.ViewState = false;
            }

            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }



        private void HideAllGroups_Click(object sender, EventArgs e)
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var objNumber in group)
                {
                    Project.Model.ObjectData.Find(objNumber).ViewState = false;
                }
            }

            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }

        private void DelAllObjects_Click(object sender, EventArgs e)
        {
            TreeView.SelectedNode.Nodes.Clear();
            DeleteAllObjects();

            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }

        private void DelAllGroups_Click(object sender, EventArgs e)
        {
            TreeView.SelectedNode.Nodes.Clear();
             DeleteAllGroups();
        }

        private void DeleteAllGroups()
        {
            var valData = Project.TaskData.Where(x => x is IValuableData).Select(x => (IValuableData)x).ToList();
            foreach (var group in Project.Model.GroupData)
            {
                var selData = valData.Where(x => x.GroupName == group.GroupName);

                foreach (Data data in selData)
                    Project.TaskData.Remove(data);
            }

            Project.Model.GroupData.Clear();
        }

        private void DeleteAllObjects()
        {
            foreach (var obj in Project.Model.ObjectData)
                obj.ExistState = false;
            DeleteAllGroups();
        }

        private void DelObject_Click(object sender, EventArgs e)
        {
            DeleteObjects(TreeView.SelectedNode.Name);
            TreeView.Nodes["объекты"].Nodes.Remove(TreeView.SelectedNode);
        }

        private void DelGroup_Click(object sender, EventArgs e)
        {
            DeleteGroup(TreeView.SelectedNode.Name, TreeView.SelectedNode.Index);
            TreeView.Nodes["группыОбъектов"].Nodes.Remove(TreeView.SelectedNode);
        }

        private void DeleteGroup(string objsType, int groupIndex)
        {
            Project.Model.GroupData.RemoveAt(groupIndex);

            var valData = Project.TaskData.Where(x => x is IValuableData).Select(x => (IValuableData)x).
                Where(x => x.GroupName == objsType).ToArray();

            foreach (Data data in valData)
                Project.TaskData.Remove(data);
        }

        private void DeleteObjects(string objsType)
        {
            Project.Model.ObjectData.RemoveRange(objsType);

            var searchGroups = Project.Model.GroupData.FindMany(objsType).ToArray();

            foreach (var searchGroup in searchGroups)
            {
                Project.Model.GroupData.Remove(searchGroup);
            }

            var selectToolStrip = FindToolStrip<SelectToolStrip>();

            selectToolStrip.RemoveObjectsType(objsType);
            SetModelGroupInfo();

            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }


        private void FindRootParentNode(TreeNode node, ref TreeNode rootNode)
        {
            if (node.Parent != null)
                FindRootParentNode(node.Parent, ref rootNode);
            else rootNode = node;
        }

        private async void EditGroup_Click(object sender, EventArgs e)
        {
            //ChangeGroupEvent(this, new GroupEvArgs(treeView.SelectedNode.Name, treeView.SelectedNode.Index));

            var group = Project.Model.GroupData.Find(TreeView.SelectedNode.Text);
            var selToolStrip = FindToolStrip<SelectToolStrip>();
            selToolStrip.SelectObjectsType = group.ObjType;

            //SelectToolStrip.SelectObjectsType = group.ObjType;

            foreach (var objNumber in group.ObjsNumbers)
                Project.Model.ObjectData.Find(objNumber).MasterColor = SceneControl.SelectionColor;

            SceneControl.ChangeColorsVBObjects(group.ObjType);
            SceneControl.DisplayObjects();

            var actConfirm = new Func<bool>(() =>
            {
                if (SceneControl.GetSelectedObjects().Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return false;
                }
                else
                {
                    group.Clear();
                    group.AddRange(SceneControl.GetSelectedObjects());
                    Project.Model.GroupData.Add(group);
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Группа изменена успешно", Color.Green);
                        PrintCommand("");
                    }));
                    return true;
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                    PrintCommand("");
                }));
            });

            var message = "измените группу, добавив или удалив объекты, и нажмите на кнопку Enter или нажмите кнопку ESC";

            await AsyncMthodContainer(actConfirm, actBreak, message);
        }

        private void InfoGroup_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[TreeView.SelectedNode.Index];
            ConsoleControl.PrintInfo(group.ToString(), Color.Black);
        }     

        private void ModelPage_Load(object sender, EventArgs e)
        {
            PresentProjectOnTree();
        }

        public override void PresentProjectOnTree()
        {
            base.PresentProjectOnTree();

            TreeView.BeforeLabelEdit += TreeView_BeforeLabelEdit;
            TreeView.AfterLabelEdit += TreeView_AfterLabelEdit;
            TreeView.NodeMouseClick += TreeView_NodeMouseClick;

            TreeView.Nodes.RemoveByKey("объекты");
            TreeView.Nodes.RemoveByKey("группыОбъектов");

            var objsNode = new TreeNode()
            {
                Text = "Объекты",
                Name = "объекты",
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                ContextMenuStrip = objects_MenuStrip,
                Tag = "3"
            };
            TreeView.Nodes.Add(objsNode);
            var objGrpsNode = new TreeNode()
            {
                Text = "Группы объектов",
                Name = "группыОбъектов",
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                ContextMenuStrip = objects_MenuStrip,
                Tag = "4"
            };
            TreeView.Nodes.Add(objGrpsNode);

            SetModelObjsInfo();
            SetModelGroupInfo();
        }

        public override void sceneControl_CreateMeshGroupEvent(object arg1, CreateGroupEventArgs arg2)
        {
            base.sceneControl_CreateMeshGroupEvent(arg1, arg2);

            SetModelGroupInfo();
        }

        public override void sceneControl_DeleteSelectionEvent(object arg1, EventArgs arg2)
        {
            base.sceneControl_DeleteSelectionEvent(arg1, arg2);

            SetModelObjsInfo();
            SetModelGroupInfo();
        }


    }
}
