using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Scene
{
    /// <summary>
    /// Класс - GLSL программа для хранения шейдеров
    /// </summary>
    public class ShaderProgramCreator : IDisposable
    {
        /// <summary>
        /// Идентификатор сгенерированного вершинного шейдера
        /// </summary>
        public int Vertex { get; set; }
        /// <summary>
        /// Идентификатор сгенерированного фрагментного шейдера
        /// </summary>
        public int Fragment { get; set; }
        /// <summary>
        /// Идентификатор сгенерированного геометрического шейдера
        /// </summary>
        public int Geometry { get; set; }
        /// <summary>
        /// Идентификатор сгенерированной программы
        /// </summary>
        public int Program { get; private set; }
        /// <summary>
        /// Конструктор GLSL программы
        /// </summary>
        public ShaderProgramCreator(){}
        /// <summary>
        /// Делает активной текущую GLSL программу
        /// </summary>
        public void Bind() => Gl.glUseProgram(Program);
        /// <summary>
        /// Делает активной программу по умолчанию
        /// </summary>
        public void Unbind() => Gl.glUseProgram(0);
        /// <summary>
        /// Активирует текстурный слот для переменной с именем name в шейдере
        /// </summary>
        /// <param name="name">Строковое имя переменной в шейдере</param>
        /// <param name="texId">Идентификатор сгенерированной текстуры</param>
        /// <param name="texUnit">Номер текстурного слота</param>
        public void BindTextureRect(string name, int texId, int texUnit)
        {
            Gl.glActiveTexture(Gl.GL_TEXTURE0 + texUnit);
            Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, texId);
            var id = Gl.glGetUniformLocation(Program, name);
            Gl.glUniform1i(id, texUnit);
        }
        /// <summary>
        /// Связывает пользовательские аттрибуты с программой
        /// </summary>
        /// <param name="buffer">Идентификатор буффера пользовательских данных</param>
        /// <param name="variable">Имя аттрибута в шейдере</param>
        /// <param name="attribsCount">Число аттрибутов</param>
        /// <param name="usedType">Используемый тип данных</param>
        public void SetCustomAttributes(int buffer, string variable, int attribsCount = 3, int usedType = Gl.GL_FLOAT)
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);
            var location = Gl.glGetAttribLocation(Program, variable);
            Gl.glBindAttribLocation(Program, location, variable);
            Gl.glEnableVertexAttribArray(location);
            Gl.glVertexAttribPointer(location, attribsCount, usedType, Gl.GL_FALSE, 0, IntPtr.Zero);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
        }
        /// <summary>
        /// Отвязывает пользовательские аттрибуты от программы
        /// </summary>
        /// <param name="variable">Имя аттрибута в шейдере</param>
        public void UnsetCustomAttributes(string variable)
        {
            var location = Gl.glGetAttribLocation(Program, variable);
            Gl.glDisableVertexAttribArray(location);
        }

        /// <summary>
        /// Передать значение в переменную шейдера с именем name
        /// </summary>
        /// <param name="name">Имя переменной в шейдере</param>
        /// <param name="values">Массив значений переменной</param>
        public void SetUniform(string name, float[] values)
        {
            var id = Gl.glGetUniformLocation(Program, name);
            var count = values.Length;
            if (id == -1)
                return;
            if (count == 1)
                Gl.glUniform1f(id, values[0]);
            else if (count == 2)
                Gl.glUniform2f(id, values[0], values[1]);
            else if (count == 3)
                Gl.glUniform3f(id, values[0], values[1], values[2]);
            else if (count == 4)
                Gl.glUniform4f(id, values[0], values[1], values[2], values[3]);
            else
                Gl.glUniformMatrix4fv(id, 1, Gl.GL_FALSE, values);//Передача матрицы в шейдер
        }
        /// <summary>
        /// Передать значение в переменную шейдера с именем name, вариант целочисленных переменных
        /// </summary>
        /// <param name="name">Имя переменной в шейдере</param>
        /// <param name="values">Массив значений переменной</param>
        public void SetUniform(string name, int[] values)
        {
            var id = Gl.glGetUniformLocation(Program, name);
            var count = values.Length;
            if (id == -1)
                return;
            if (count == 1)
                Gl.glUniform1i(id, values[0]);
            else if (count == 2)
                Gl.glUniform2i(id, values[0], values[1]);
            else if (count == 3)
                Gl.glUniform3i(id, values[0], values[1], values[2]);
            else if (count == 4)
                Gl.glUniform4i(id, values[0], values[1], values[2], values[3]);
        }
        /// <summary>
        /// Подгружает из файла исходный код шейдера, указанного типа, компилирует и привязывает к идентификатору шейдера
        /// </summary>
        /// <param name="type">Тип шейдера (вершинный, фрагментный и т.д)</param>
        /// <param name="path">Путь до файла</param>
        public void CreateShaderFromFile(int type, string path)
        {
            var data = new List<string>();
            using (var reader = new StreamReader(path))
            {
                data.Add(reader.ReadToEnd());
            }
            CreateShaderFromString(type, data.ToArray());
        }
        /// <summary>
        /// Принимает массив строк(исходного кода шейдера) указанного типа шейдера и привязывает к идентификатору шейдера
        /// </summary>
        /// <param name="type">Тип шейдера (вершинный, фрагментный и т.д)</param>
        /// <param name="data">Массив строк исходного кода шейдера</param>
        public void CreateShaderFromString(int type, string[] data)
        {
            var shader = Gl.glCreateShader(type);
            Gl.glShaderSource(shader, data.Length, data, null);
            try
            {
                Gl.glCompileShader(shader);
                int status;
                Gl.glGetShaderiv(shader, Gl.GL_COMPILE_STATUS, out status);
                if (status == Gl.GL_FALSE)
                    throw new Exception();
                if (type == Gl.GL_VERTEX_SHADER)
                    Vertex = shader;
                else if (type == Gl.GL_FRAGMENT_SHADER)
                    Fragment = shader;
                else if (type == Gl.GL_GEOMETRY_SHADER_EXT)
                    Geometry = shader;
            }
            catch
            {
                var sb = new StringBuilder(1024);
                Gl.glGetShaderInfoLog(shader, 1024, null, sb);
                if (MessageBox.Show(sb.ToString(), "Compile shader exception",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    Environment.Exit(1);
            }
        }
        /// <summary>
        /// Связывает все шейдеры с указанной программой
        /// </summary>
        /// <param name="tfNames">Перечисление переменных для механизма TransformFeedback</param>
        /// <exception cref="Exception">Исключение, если связывание не удалось</exception>
        public void Link(IEnumerable<string> tfNames = null)
        {
            Program = Gl.glCreateProgram();
            if(Vertex != 0)
                Gl.glAttachShader(Program, Vertex);
            if (Fragment != 0)
                Gl.glAttachShader(Program, Fragment);
            if (Geometry != 0)
                Gl.glAttachShader(Program, Geometry);
            try
            {
                ApplyTransformFeedback(tfNames);
                Gl.glLinkProgram(Program);
                int status;
                Gl.glGetProgramiv(Program, Gl.GL_LINK_STATUS, out status);
                if(status == Gl.GL_FALSE)
                    throw new Exception();
            }
            catch
            {
                var sb = new StringBuilder(1024);
                Gl.glGetProgramInfoLog(Program, 1024, null, sb);
                if (MessageBox.Show(sb.ToString(), "Link program exception", 
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    Environment.Exit(1);
            }
        }
        /// <summary>
        /// Освобождает все ресурсы, выделенные программой (шейдер и сама программа)
        /// </summary>
        public void Dispose()
        {
            Gl.glDetachShader(Program, Vertex);
            Gl.glDeleteShader(Vertex);
            Gl.glDetachShader(Program, Fragment);
            Gl.glDeleteShader(Fragment);
            Gl.glDetachShader(Program, Geometry);
            Gl.glDeleteShader(Geometry);
            Gl.glDeleteProgram(Program);
        }

        private void ApplyTransformFeedback(IEnumerable<string> tfNames)
        {
            if (tfNames != null)
            {
                var tfVars = tfNames.ToArray();
                Gle.TransformFeedbackVaryings((uint)Program, (uint)tfVars.Length, tfVars, Gl.GL_SEPARATE_ATTRIBS_NV);
            }
        }
    }
}
