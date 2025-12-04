/// <summary>
/// У какого объекта визуализировать BoundingBox?
/// </summary>
/// <param name="vboObj">Имя вбо-объекта</param>
private void ShowBoundingBox(string vboObj)
{
    var obj = BasePage.bf.VBOController.FindVBObj(vboObj);
    if (obj != null)
    {
        var bbObjStr = vboObj + "_BoundingBox";
        var bboxObj = BasePage.bf.VBOController.FindVBObj(bbObjStr);
        if (bboxObj == null)
        {
            var bb = obj.BoundingBox;

            var indices = new int[] { 0, 1, 1, 2, 2, 3, 3, 0, 4, 5, 5, 6, 6, 7, 7, 4, 0, 6, 1, 7, 2, 4, 3, 5 };
            var coords = new float[] { bb.LeftUpNear._x, bb.LeftUpNear._y, bb.LeftUpNear._z,
                                       bb.RightDownFar._x, bb.LeftUpNear._y, bb.LeftUpNear._z,
                                       bb.RightDownFar._x, bb.LeftUpNear._y, bb.RightDownFar._z,
                                       bb.LeftUpNear._x, bb.LeftUpNear._y, bb.RightDownFar._z,

                                       bb.RightDownFar._x, bb.RightDownFar._y, bb.RightDownFar._z,
                                       bb.LeftUpNear._x, bb.RightDownFar._y, bb.RightDownFar._z,
                                       bb.LeftUpNear._x, bb.RightDownFar._y, bb.LeftUpNear._z,
                                       bb.RightDownFar._x, bb.RightDownFar._y, bb.LeftUpNear._z,
                                     };
            var colors = new float[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
                                       0, 1, 0, 1 , 0, 1, 0, 1 , 0, 1, 0, 1 , 0, 1, 0, 1 };
            var normals = new float[] { 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
            var edges = new bool[] { false, false, false, false, false, false, false, false };
            
            BasePage.bf.VBOController.CreateLineVBObjects(indices, coords, colors, normals, edges, bbObjStr);
        }
    }
}