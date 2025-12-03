using System;
using Geometry;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using BazisGUI.Reflect;
using BazisGUI.Scene.VBO;
using OpenTK.Graphics.OpenGL;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void отзеркаливаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripMenuItem;
                if (btn.Checked)
                {
                    var reflect = new ReflectControl();
                    reflect.SetGlObjs(VBOController.GetVBObjs().Select(x => x.ObjName));

                    var reflectForm = new Form()
                    {
                        TopMost = true,
                        ShowIcon = true,
                        Icon = this.Icon,
                        Owner = Application.OpenForms[0],
                        MaximizeBox = false,
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        Text = "Отражение"
                    };
                    reflectForm.Controls.Add(reflect);
                    reflect.Dock = DockStyle.Fill;

                    reflect.ShowObjs += (ar) =>
                    {
                        SetBackColorToAllObjects();

                        var vbo = VBOController.FindVBObj(ar);

                        //var a = (int)vbo.PointsColors[0];
                        //var r = (int)vbo.PointsColors[1];
                        //var g = (int)vbo.PointsColors[2];
                        //var b = (int)vbo.PointsColors[3];

                        //var color = Color.FromArgb(a, r, g, b);

                        //foreach (var item in reflect.GetAllSrcObjs())
                        //    ChangeVBOColor(item, color);
                        ChangeVBOColor(ar, Color.Red);
                        DisplayObjects();
                    };

                    reflect.CreateReflectObj += (ar1, ar2) =>
                    {
                        var copyObjs = VBOController.GetVBObjs().Where(x => x.ObjName.Contains($"{ar1}_copy")).
                        Select(x => x.ObjName);
                        CreateReflectedVBObject(ar1, $"{ar1}_copy_{copyObjs.Count() + 1}", ar2);
                        reflect.SetGlObjs(copyObjs);
                        DisplayObjects();
                    };

                    reflect.MatrixEvent += (s, ev) =>
                    {
                        var obj = VBOController.FindVBObj(s);
                        ev.Matrix = obj.ModelMatrix;
                    };

                    reflect.UpdateReflectPlane += (s, p) =>
                    {
                        DisplayReflectionPlane(s, p);
                        DisplayObjects();
                    };

                    reflectForm.FormClosing += (o, ev) =>
                    {
                        btn.Checked = false;
                        DisplayReflectionPlaneEvent = null;
                        VBOController.DeleteAllVBObjects();
                        //clipPlaneRenderer?.DestroyBoundingBoxVBO();
                        //PresentAllModelObjectsToScene();
                        //CreateReflectedVBObject("", "", null);
                        DisplayObjects();
                    };
                    reflectForm.Show();

                    var location = PointToScreen(Point.Empty);
                    reflectForm.Location = location;


                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "reflectForm");
                    if (form != null)
                    {
                        form.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// Создает зеркальную (относительно плоскости) копию вбо-объекта, если задано имя оригинала и копии и коэффициенты плоскости
        /// </summary>
        /// <param name="srcVboName">[In]Имя объекта источника или пустая строка как триггер отмены эвента рисования плоскости</param>
        /// <param name="copyVboName">[In]Имя объекта копии</param>
        /// <param name="coef">[In]Коэффициенты плоскости</param>
        public void CreateReflectedVBObject(string srcVboName, string copyVboName, float[] coef)
        {
            var normal = new Point3D(coef[0], coef[1], coef[2]);
            normal = Geometry.Vector.GetVectorNorm(normal);
            var plane = new Geometry.Plane(normal, coef[3]);

            var copyVbo = VBOController.FindVBObj(copyVboName);
            if (copyVbo != null)
                throw new Exception($"Объект с именем {copyVbo} уже существует");

            var srcVbo = VBOController.FindVBObj(srcVboName) as VBObject;

            if (srcVbo == null)
                throw new Exception($"Объект с именем {srcVbo} не существует");

            VBOController.CopyVBObjects(srcVbo, copyVboName);
            var copeVbo = VBOController.FindVBObj(copyVboName);

            var reflMatrix = GetReflectionMatrix(plane);//from stack
            //DisplayReflectionPlane(src, plane);
            GL.MatrixMode(MatrixMode.Modelview);//видовая и модельная матрица
            GL.PushMatrix();
            GL.LoadMatrix(srcVbo.ModelMatrix);
            GL.MultMatrix(reflMatrix);
            GL.GetFloat(GetPName.ModelviewMatrix, copeVbo.ModelMatrix);
            GL.PopMatrix();
        }

        public float[] GetReflectionMatrix(Geometry.Plane plane)
        {
            var reflection = new float[16];
            var x = -plane.Normal._x;
            var y = -plane.Normal._y;
            var z = -plane.Normal._z;
            var d = plane.Shifting;
            reflection[0] = 1 - 2 * x * x;
            reflection[1] = -2 * x * y;
            reflection[2] = -2 * x * z;
            reflection[3] = 0.0f;
            reflection[4] = -2 * x * y;
            reflection[5] = 1 - 2 * y * y;
            reflection[6] = -2 * y * z;
            reflection[7] = 0.0f;
            reflection[8] = -2 * x * z;
            reflection[9] = -2 * y * z;
            reflection[10] = 1 - 2 * z * z;
            reflection[11] = 0.0f;
            reflection[12] = -2 * x * d;
            reflection[13] = -2 * y * d;
            reflection[14] = -2 * z * d;
            reflection[15] = 1.0f;
            return reflection;
        }

        private void ChangeVBOColor(string ar, Color color)
        {
            var obj = VBOController.FindVBObj(ar);

            var colors = new float[obj.ColorLength];

            //var count = obj.ColorLength / 4;
            for (int i = 0; i < obj.ColorLength; i += 4)
            {
                colors[i] = Convert.ToInt32(color.R) / 255.0f;
                colors[i + 1] = Convert.ToInt32(color.G) / 255.0f;
                colors[i + 2] = Convert.ToInt32(color.B) / 255.0f;
                colors[i + 3] = Convert.ToInt32(color.A) / 255.0f;
            }
            obj.PointsColors = colors;
        }
    }
}
