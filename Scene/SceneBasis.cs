using Scene.Interfaces;
using Tao.OpenGl;


namespace Scene
{
    public class SceneBasis
    {
        public Transform Position { get; internal set; }

        public void Display(SceneCamera camera, float scaleFactor)
        {
            var quadObj = Glu.gluNewQuadric();

            // draw "Z line"
            Gl.glPushMatrix();
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Gl.glColor3d(0, 0, 1);
            Glu.gluCylinder(quadObj, 0.0015, 0.0015, 0.025, 10, 10); // рисуем цилиндр
            Gl.glPopMatrix();

            //draw "Y line"
            Gl.glPushMatrix();
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Gl.glColor3d(0, 1, 0);
            Gl.glRotatef(-90, 1, 0, 0);
            Glu.gluCylinder(quadObj, 0.0015, 0.0015, 0.025, 10, 10); // рисуем цилиндр
            Gl.glPopMatrix();


            // draw "X line"
            Gl.glPushMatrix();
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Gl.glRotatef(90, 0, 1, 0);
            Gl.glColor3d(1, 0.5f, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
            Glu.gluCylinder(quadObj, 0.0015, 0.0015, 0.025, 10, 10); // рисуем цилиндр
            Gl.glPopMatrix();


            //draw "X tip"
            Gl.glPushMatrix();
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Gl.glColor3d(1, 0.5f, 0);
            Gl.glTranslatef(0.025f, 0, 0);
            Gl.glRotatef(90, 0, 1, 0);
            Glu.gluCylinder(quadObj, 0.0025, 0, 0.01, 10, 10); // рисуем цилиндр
            Gl.glPopMatrix();

            //draw "Y tip"
            Gl.glPushMatrix();
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Gl.glColor3d(0, 1, 0);
            Gl.glTranslatef(0, 0.025f, 0);
            Gl.glRotatef(-90, 1, 0, 0);
            Glu.gluCylinder(quadObj, 0.0025, 0, 0.01, 10, 10); // рисуем цилиндр
            Gl.glPopMatrix();

            //draw "Z tip"
            Gl.glPushMatrix();
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Gl.glColor3d(0, 0, 1);
            Gl.glTranslatef(0, 0, 0.025f);
            Glu.gluCylinder(quadObj, 0.0025, 0, 0.01, 10, 10); // рисуем цилиндр
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
            Gl.glColor3f(1, 1, 0);

            Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
            Glu.gluSphere(quadObj, 0.002, 10, 10); // рисуем сферу
            Gl.glPopMatrix();

            Glu.gluDeleteQuadric(quadObj);
        }
    }
}
