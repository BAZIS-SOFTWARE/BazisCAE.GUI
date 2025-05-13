
using Geometry;
using Tao.OpenGl;

namespace Scene
{
    public class SceneHorizontalButton
    {
        float[,] viewMatrix;
        Point3D[] backGroundCoords;
        Point3D[] foreGroundCoords;
        Point2D[] pointerCoords;
        public SceneHorizontalButton(float height, float width)
        {
            viewMatrix = new float[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            backGroundCoords = new Point3D[6]
            {
                new Point3D(0.0f, 0.0f, 0.0f),
                new Point3D(0, height - 3, 0.0f),
                new Point3D(2, height, 0.0f),
                new Point3D(width - 2, height, 0),
                new Point3D(width, height - 2, 0.0f),
                new Point3D(width, 0, 0.0f)
            };

            foreGroundCoords = new Point3D[6]
{
                new Point3D(backGroundCoords[0]._x + 1, backGroundCoords[0]._y, 0.0f),
                new Point3D(backGroundCoords[1]._x + 1, backGroundCoords[1]._y - 1, 0.0f),
                new Point3D(backGroundCoords[2]._x, backGroundCoords[2]._y - 1, 0.0f),
                new Point3D(backGroundCoords[3]._x, backGroundCoords[3]._y - 1, 0),
                new Point3D(backGroundCoords[4]._x - 1, backGroundCoords[4]._y, 0.0f),
                new Point3D(backGroundCoords[5]._x - 1, backGroundCoords[5]._y, 0.0f),
};
            pointerCoords = new Point2D[2]
            {
                new Point2D(width / 2 - 5, height / 2 + 1),
                new Point2D(width / 2 + 5, height / 2 - 1)
            };
        }

        public void Display(SceneCamera camera)
        {
            Initialize_GUI_Plane(camera.Width, camera.Height);

            //float[] matrix = Matrix<float>.Build.DenseOfArray(viewMatrix).AsColumnMajorArray();

            //matrix[14] = -6;
            //matrix[12] = camera.Width / 2;
            //matrix[13] = 0;

            //Gl.glLoadMatrixf(matrix);

            Gl.glPushMatrix();
            Gl.glTranslatef(camera.Width / 2, 0, -6);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);

            Gl.glColor3d(0, 0, 0);
            Gl.glRectf(pointerCoords[0]._x, pointerCoords[0]._y, pointerCoords[1]._x, pointerCoords[1]._y);
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glEnd();

            Gl.glColor3d(0.9, 0.9, 0.9);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            for (int i = 0; i < foreGroundCoords.Length; i++)
                Gl.glVertex3f(foreGroundCoords[i]._x, foreGroundCoords[i]._y, foreGroundCoords[i]._z);
            Gl.glEnd();

            Gl.glColor3d(0.4, 0.4, 0.4);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            for (int i = 0; i < backGroundCoords.Length; i++)
                Gl.glVertex3f(backGroundCoords[i]._x, backGroundCoords[i]._y, backGroundCoords[i]._z);
            Gl.glEnd();

            Gl.glPopMatrix();

            Finish_GUI_Plane();
        }

        private void Initialize_GUI_Plane(int width, int height)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
        }

        private void Finish_GUI_Plane()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();
        }
    }
}
