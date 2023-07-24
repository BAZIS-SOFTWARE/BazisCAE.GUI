using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BaseModule;
using ToolStrips;
using Model;
using ModelController.MeshObjsCreator;
using Project.Interfaces;
using Project.TasksData;
using Scene.Events;
using System.Diagnostics;
using System.IO;
using Scene;
using ModelController.ModelScenePresentator;
using Model.Interfaces;

namespace ModelModule
{
    public partial class ModelPage: BasePage
    {
        Dictionary<string, int> imgDict;


        public ModelPage()
        {
            InitializeComponent();

            imgDict = new Dictionary<string, int>()
            {
                { "Узлы",3},
                { "Элементы3D",4},
                { "Элементы2D",4},
                { "Элементы1D",4}
            };

            var meshToolStrip = new MeshToolStrip();
            meshToolStrip.Renderer = new BtnToolStrRender();
            meshToolStrip.ItemClicked += MeshToolStrip_ItemClicked;
            
            AddToolStrip(meshToolStrip);
        }

        public override void CreateMenuInterface()
        {
            AddToolStripMenuItem(AddMeshInterface());
            base.CreateMenuInterface();
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

            if(els3D.Count() != 0)
            {
                var creator = new Extract2DFrom3D(els3D.ToArray());

                var startNumber = Project.Model.ObjectData.GetLastObjNumber() + 1;
                var boundaryElements2D = creator.Create(startNumber);

                Project.Model.ObjectData.AddRange(boundaryElements2D);

                var presentor = new ModelScenePresentator(Project.Model);
                SceneControl.SetPresentor(presentor);

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
                CreateNewGroupNode(grInfo);

            TreeView.EndUpdate();
        }

        private void CreateNewObjectsNode(KeyValuePair<string, List<string>> objInfo)
        {
            var trNode = new TreeNode()
            {
                ContextMenuStrip = object_MenuStrip,
                Name = objInfo.Key,
                Text = string.Format("{0} : {1}", objInfo.Key, objInfo.Value.Count),

                ImageIndex = imgDict[objInfo.Key] == 3 ? 5 : 6,
                SelectedImageIndex = imgDict[objInfo.Key] == 3 ? 5 : 6,               
     
                Tag = "4.1"
            };

            TreeView.Nodes["объекты"].Nodes.Add(trNode);
        }

        private void CreateNewGroupNode(KeyValuePair<string, string> grInfo)
        {
            var trNode = new TreeNode()
            {
                Text = grInfo.Key,
                Name = grInfo.Value,
                ImageIndex = imgDict[grInfo.Value],
                SelectedImageIndex = imgDict[grInfo.Value],
                Tag = "5.1"
            };
            TreeView.Nodes["группыОбъектов"].Nodes.Add(trNode);

            if (grInfo.Value == "Узлы")
                trNode.ContextMenuStrip = ndGroup_MenuStrip;
            else trNode.ContextMenuStrip = elGroup_MenuStrip;


        }

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            TreeView.LabelEdit = true;
            TreeView.SelectedNode.BeginEdit();
        }

        private void ShowGroupWithNodes_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[TreeView.SelectedNode.Index];

            foreach (var number in group.ObjsNumbers)
            {
                var obj = (IElement)Project.Model.ObjectData.Find(number);
                obj.ViewState = true;

                foreach (var node in obj.GetNodes())
                    node.ViewState = true;

            }

            if (SceneControl.IsVBObjectShown("Узлы"))
                SceneControl.HideVBObject("Узлы");
            SceneControl.DeleteVBObjects("Узлы");

            SceneControl.CreateVBObjects("Узлы");
            SceneControl.ShowVBObject("Узлы");

            TreeView.Nodes[4].Nodes["Узлы"].ImageIndex = 5;
            TreeView.Nodes[4].Nodes["Узлы"].SelectedImageIndex = 5;

            if (SceneControl.IsVBObjectShown(TreeView.SelectedNode.Name))
                SceneControl.HideVBObject(TreeView.SelectedNode.Name);
            SceneControl.DeleteVBObjects(TreeView.SelectedNode.Name);

            SceneControl.CreateVBObjects(TreeView.SelectedNode.Name);
            SceneControl.ShowVBObject(TreeView.SelectedNode.Name);

            TreeView.Nodes[4].Nodes[TreeView.SelectedNode.Name].ImageIndex = imgDict[TreeView.SelectedNode.Name] == 3 ? 5 : 6;
            TreeView.Nodes[4].Nodes[TreeView.SelectedNode.Name].SelectedImageIndex = imgDict[TreeView.SelectedNode.Name] == 3 ? 5 : 6;

            SceneControl.DisplayObjects();
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
                if (e.Node.Tag.ToString() == "5.1")
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

        private void ShowAllGroups_Click(object sender, EventArgs e)
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var objNumber in group)
                {
                    Project.Model.ObjectData.Find(objNumber).ViewState = true;
                }

                TreeView.Nodes[4].Nodes[group.ObjType].ImageIndex = imgDict[group.ObjType] == 3 ? 5 : 6;
                TreeView.Nodes[4].Nodes[group.ObjType].SelectedImageIndex = imgDict[group.ObjType] == 3 ? 5 : 6;
            }
            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }

        private void ShowGroup_Click(object sender, EventArgs e)
        {           
            var group = Project.Model.GroupData[TreeView.SelectedNode.Index];

            foreach (var number in group.ObjsNumbers)
                Project.Model.ObjectData.Find(number).ViewState = true;

            if (SceneControl.IsVBObjectShown(group.ObjType))
                SceneControl.HideVBObject(group.ObjType);
            SceneControl.DeleteVBObjects(group.ObjType);

            SceneControl.CreateVBObjects(group.ObjType);
            SceneControl.ShowVBObject(group.ObjType);

            TreeView.Nodes[4].Nodes[group.ObjType].ImageIndex = imgDict[group.ObjType] == 3 ? 5 : 6;
            TreeView.Nodes[4].Nodes[group.ObjType].SelectedImageIndex = imgDict[group.ObjType] == 3 ? 5 : 6;

            SceneControl.DisplayObjects();
        }

        private void HideGroup_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[TreeView.SelectedNode.Index];

            foreach (var number in group.ObjsNumbers)
                Project.Model.ObjectData.Find(number).ViewState = false;

            if (SceneControl.IsVBObjectShown(group.ObjType))
                SceneControl.HideVBObject(group.ObjType);
            SceneControl.DeleteVBObjects(group.ObjType);

            SceneControl.CreateVBObjects(group.ObjType);
            SceneControl.ShowVBObject(group.ObjType);

            SceneControl.DisplayObjects();
        }

        public void ShowObjects_Click(object sender, EventArgs e)
        {
            var modelObjects = Project.Model.ObjectData.FindMany(TreeView.SelectedNode.Name);
            foreach (var modelObject in modelObjects)
                modelObject.ViewState = true;

            if(SceneControl.IsVBObjectShown(TreeView.SelectedNode.Name))
                SceneControl.HideVBObject(TreeView.SelectedNode.Name);
            SceneControl.DeleteVBObjects(TreeView.SelectedNode.Name);

            SceneControl.CreateVBObjects(TreeView.SelectedNode.Name);
            SceneControl.ShowVBObject(TreeView.SelectedNode.Name);

            TreeView.SelectedNode.ImageIndex = imgDict[TreeView.SelectedNode.Name] == 3 ? 5 : 6;
            TreeView.SelectedNode.SelectedImageIndex = imgDict[TreeView.SelectedNode.Name] == 3 ? 5 : 6;

            SceneControl.DisplayObjects();
        }

        private void SwitchAllObjects_Click(object sender, EventArgs e)
        {
            SwitchAllObjects();
            SceneControl.DisplayObjects();
        }

        private void SwitchOnObjects_Click(object sender, EventArgs e)
        {
            SwitchOnObjects(TreeView.SelectedNode.Name);
            SceneControl.DisplayObjects();
        }

        private void SwitchOffObjects_Click(object sender, EventArgs e)
        {
            SwitchOffObjects(TreeView.SelectedNode.Name);
            SceneControl.DisplayObjects();
        }

        private void SwitchOffAllObjects_Click(object sender, EventArgs e)
        {
            SwitchOffAllObjects();
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

        private void DelObjects_Click(object sender, EventArgs e)
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

            var presentor = new ModelScenePresentator(Project.Model);
            SceneControl.SetPresentor(presentor);

            PresentAllModelObjectsOnScene();
            SceneControl.DisplayObjects();
        }


        private void FindRootParentNode(TreeNode node, ref TreeNode rootNode)
        {
            if (node.Parent != null)
                FindRootParentNode(node.Parent, ref rootNode);
            else rootNode = node;
        }

        private async void EditGroup_Click(object sender, EventArgs e) //
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

            var actConfirm = new Func<Tuple<bool,object>>(() =>
            {
                if (SceneControl.GetSelectedObjects().Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
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
                    return new Tuple<bool, object>(true, new object());
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

            await AsyncMethodContainer(actConfirm, actBreak, message);
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
                Tag = "4"
            };
            TreeView.Nodes.Add(objsNode);
            var objGrpsNode = new TreeNode()
            {
                Text = "Группы объектов",
                Name = "группыОбъектов",
                ImageIndex = CollapseIndex,
                SelectedImageIndex = CollapseIndex,
                ContextMenuStrip = groups_MenuStrip,
                Tag = "5"
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

        private void HideObjects_Click(object sender, EventArgs e)
        {
            var modelObjects = Project.Model.ObjectData.FindMany(TreeView.SelectedNode.Name);
            foreach (var modelObject in modelObjects)
                modelObject.ViewState = false;

            if (SceneControl.IsVBObjectShown(TreeView.SelectedNode.Name))
                SceneControl.HideVBObject(TreeView.SelectedNode.Name);
            SceneControl.DeleteVBObjects(TreeView.SelectedNode.Name);

            SceneControl.CreateVBObjects(TreeView.SelectedNode.Name);
            SceneControl.ShowVBObject(TreeView.SelectedNode.Name);

            SceneControl.DisplayObjects();
        }

        private void ребраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneControl.ChangeViewModeVBObjects(TreeView.SelectedNode.Name, Scene.VBO.ObjView.Lines);
            SceneControl.DisplayObjects();
        }

        private void поверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneControl.ChangeViewModeVBObjects(TreeView.SelectedNode.Name, Scene.VBO.ObjView.Surface);
            SceneControl.DisplayObjects();
        }

        private void ребраИПоверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneControl.ChangeViewModeVBObjects(TreeView.SelectedNode.Name, Scene.VBO.ObjView.LinesSurface);
            SceneControl.DisplayObjects();
        }
    }
}
