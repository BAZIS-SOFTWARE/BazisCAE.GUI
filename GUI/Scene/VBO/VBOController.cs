using BazisGUI.Scene.EventsArgs;
using BazisGUI.Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Scene.VBO
{
    public class VBOController
    {
        public Action<object, MessageEventArgs> MessageEvent;

        List<VBObject> glObjs = new List<VBObject>();

        public VBObject FindVBObj(string objName)
        {
            return glObjs.Find(x => x.ObjName == objName);
        }

        public void AddVbo(VBObject vbObject)
        {

            glObjs.Add(vbObject);
        }

        public void DeleteAllVBObjects()
        {
            foreach (var glObj in glObjs)
                VBO.DeleteAllBuffers(glObj);//Если удаляем объект, то чистим массивы во избежании утечки памяти на видеокарте
            glObjs.Clear();
            
        }


        public bool DeleteVBObjects(string objName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objName);
            if (glObj != null)
            {
                VBO.DeleteAllBuffers(glObj);//Если удаляем объект, то чистим массивы во избежании утечки памяти на видеокарте
                return glObjs.Remove(glObj);
            }
            else return false;

        }

        public void ShowAllVBObjects()
        {
            glObjs.ForEach(x => x.ViewState = true);
        }

        public void HideAllVBObjects()
        {
            glObjs.ForEach(x => x.ViewState = false);
        }

        /// <summary>
        /// CreateSurfaceVBObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="coords"></param>
        /// <param name="colors"></param>
        /// <param name="normals"></param>
        /// <param name="edges"></param>
        /// <param name="objsName"></param>
        /// <param name="separs"></param>
        /// <param name="viewMode"></param>
        public SurfaceObjects CreateSurfaceVBObjects(int[] ptrs, float[] coords, float[] colors, float[] normals,
            bool[] edges, string objsName, int[] separs, ObjView viewMode)
        {
            var vbObj = new SurfaceObjects(objsName,edges, ptrs, coords, colors, normals);
            vbObj.CreateSeparators(separs);
            vbObj.Create3DBoundingBoxes(coords, separs);
            vbObj.ViewMode = viewMode;
            return vbObj;
            //glObjs.Add(vbObj);
            //vbObj.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
        }
        /// <summary>
        /// CreateLineVBObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="coords"></param>
        /// <param name="colors"></param>
        /// <param name="normals"></param>
        /// <param name="edges"></param>
        /// <param name="objsName"></param>
        public LineObjects CreateLineVBObjects(int[] ptrs, float[] coords, float[] colors, float[] normals, bool[] edges, string objsName)
        {
            return new LineObjects(objsName,edges, ptrs, coords, colors, normals);
            //glObjs.Add(obj);
            //obj.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
        }
        /// <summary>
        /// CreatePointVBObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="coords"></param>
        /// <param name="colors"></param>
        /// <param name="normals"></param>
        /// <param name="objsName"></param>
        public PointObjects CreatePointVBObjects(int[] ptrs, float[] coords, float[] colors, float[] normals, string objsName)
        {
            return new PointObjects(objsName,ptrs, coords, colors, normals);
            //glObjs.Add(obj);
            //obj.ActiveDrawingObject = AverageColorRenderer.IsEnable ? averageColorRenderer : null;
        }


        /// <inheritdoc/>


        public void CopyVBObjects(VBObject original, string copyName)
        {
            var pointers = original.PointsIndexes;
            var coords = original.PointsCoords;
            var colors = original.PointsColors;
            var normals = original.NormalsCoords;

            if (original.GL_ObjType == GLObjType.point)
                CreatePointVBObjects(pointers, coords, colors, normals, copyName);
            else if (original.GL_ObjType == GLObjType.line)
                CreateLineVBObjects(pointers, coords, colors, normals, new bool[0], copyName);
            else if (original.GL_ObjType == GLObjType.triangle)
            {
                var sObj = original as SurfaceObjects;
                var edges = sObj.EdgeFlags;
                normals = normals.Select(v => -v).ToArray();

                CreateSurfaceVBObjects(pointers, coords, colors, normals, edges, copyName, sObj.Separators, ObjView.LinesSurface);
            }


        }
        /// <summary>
        /// Смена режима прозрачности для vbo-объектов
        /// </summary>
        /// <param name="AverageColorRenderer"></param>
        public void ChangeVBOTransparentMode(AverageColorRenderer averageColorRenderer)
        {
            foreach (var globj in GetVBObjs())
                globj.ActiveDrawingObject = averageColorRenderer;
        }

        public void ChangeViewModeVBObjects(string objsName, ObjView objView)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);
            if (glObj == null)
                MessageEvent?.Invoke(this, new MessageEventArgs("Не найдены объекты указанного типа!"));
            else
                glObj.ViewMode = objView;
        }

        public void ChangeSettingsVBObjects(string objsName, float pointsSize, float linesWith)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);
            if (glObj == null)
                MessageEvent?.Invoke(this, new MessageEventArgs("Не найдены объекты указанного типа!"));
            else
            {
                glObj.Gl_PointSize = pointsSize;
                glObj.Gl_LineWidth = linesWith;
            }
        }

        public void SwitchOnVBObject(string objsName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);

            if (glObj != null)
                glObj.ViewState = true;
        }


        public void SwitchOffVBObject(string objsName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);

            if (glObj != null)
                glObj.ViewState = false;
        }

        public bool IsVBObjectShown(string objsName)
        {
            var glObj = glObjs.Find(x => x.ObjName == objsName);
            return glObj?.ViewState == true ? true : false;
        }

        public IEnumerable<VBObject> GetVBObjs()
        {
            foreach (var item in glObjs)
            {
                yield return item;
            }
        }
    }
}
