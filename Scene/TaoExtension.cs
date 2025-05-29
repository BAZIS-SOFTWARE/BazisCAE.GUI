using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Scene
{
    /// <summary>
    /// Класс для вытягивания из видеодрайвера несуществующих в Tao функций, аббривиатура класса Gle = Gl extension
    /// </summary>
    public static class Gle
    {
        private const string Library = "opengl32.dll";
        [DllImport(Library, EntryPoint = "wglGetProcAddress")]
        private static extern IntPtr wglGetProcAddress(string name);
        /// <summary>
        /// Одна компонента цвета 32 бита
        /// </summary>
        public const int GL_R32F = 33326;
        /// <summary>
        /// Создает внеэкранные фреймбуфферы и записывает в массив сгенерированные идентификаторы
        /// </summary>
        /// <param name="n">[In]Количество фрейбуфферов</param>
        /// <param name="ids">[In]Массив для заполнения</param>
        public delegate void glGenFramebuffersFun(uint n, uint[] ids);///
        public static glGenFramebuffersFun glGenFramebuffers;
        /// <summary>
        /// Привязывает текущий id фреймбуффера, для манипуляций с ним
        /// </summary>
        /// <param name="target">[In]Режим фреймбуффера [GL_FRAMEBUFFER,GL_DRAW_FRAMEBUFFER,GL_READ_FRAMEBUFFER]</param>
        /// <param name="framebuffer">[In]Идентификатор</param>
        public delegate void glBindFramebufferFun(int target, uint framebuffer);///
        public static glBindFramebufferFun glBindFramebuffer;
        /// <summary>
        /// Привязывает 2D-текстуру к фреймбуфферу
        /// </summary>
        /// <param name="target">[In]Режим фреймбуффера [GL_FRAMEBUFFER,GL_DRAW_FRAMEBUFFER,GL_READ_FRAMEBUFFER]</param>
        /// <param name="attachment">[In]Текстурная привязка цвета [GL_DEPTH_ATTACHMENT, GL_COLOR_ATTACHMENTi, ...]</param>
        /// <param name="textarget">[In]Режим текстуры [GL_TEXTURE_RECTANGLE_ARB, GL_TEXTURE_2D, ...]</param>
        /// <param name="texture">[In]Идентификатор текстуры</param>
        /// <param name="level">[In]Уровень mip-map текстуры</param>
        public delegate void glFramebufferTexture2DFun(int target, int attachment, int textarget, uint texture, uint level);///
        public static glFramebufferTexture2DFun glFramebufferTexture2D;
        /// <summary>
        /// Удаляет существующие фреймбуфферы
        /// </summary>
        /// <param name="n">[In]Количество фрейбуфферов</param>
        /// <param name="framebuffers">[In]Массив фреймбуфферов</param>
        public delegate void glDeleteFramebuffersFun(uint n, uint[] framebuffers);///
        public static glDeleteFramebuffersFun glDeleteFramebuffers;
        /// <summary>
        /// Копирует содержимое read-фреймбуффера в draw-фреймбуффер
        /// </summary>
        /// <param name="srcX0">[In]Левая нижняя X-координата источника</param>
        /// <param name="srcY0">[In]Левая нижняя Y-координата источника</param>
        /// <param name="srcX1">[In]Правая верхняя X-координата источника</param>
        /// <param name="srcY1">[In]Правая верхняя Y-координата источника</param>
        /// <param name="dstX0">[In]Левая нижняя X-координата приемника</param>
        /// <param name="dstY0">[In]Левая нижняя Y-координата приемника</param>
        /// <param name="dstX1">[In]Правая верхняя X-координата приемника</param>
        /// <param name="dstY1">[In]Правая верхняя Y-координата приемника</param>
        /// <param name="mask">[In]Битовая комбинация маски буфферов для копирования [GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT...]</param>
        /// <param name="filter">[In]Фильтрация текстур согласно замечаниям OpenGL API [GL_NEAREST,GL_LINEAR]</param>
        public delegate void glBlitFramebufferFun(int srcX0, int srcY0, int srcX1, int srcY1,
                                                  int dstX0, int dstY0, int dstX1, int dstY1,
                                                  int mask, int filter);///
        public static glBlitFramebufferFun glBlitFramebuffer;
        /// <summary>
        /// Возвращает числовое значение заданного параметра фреймбуффера
        /// </summary>
        /// <param name="target">[In]Режим фреймбуффера [GL_FRAMEBUFFER,GL_DRAW_FRAMEBUFFER,GL_READ_FRAMEBUFFER]</param>
        /// <param name="attachment">[In]Текстурная привязка цвета [GL_DEPTH_ATTACHMENT, GL_COLOR_ATTACHMENTi, ...]</param>
        /// <param name="pname">[In]Запрашиваемый параметр согласно спецификации OpenGL API [GL_DEPTH, GL_DEPTH_STENCIL_ATTACHMENT,...]</param>
        /// <param name="param">[In]Вовращаемое числовое значение</param>
        public delegate void glGetFramebufferAttachmentParameterivFun(int target, int attachment, int pname, ref int param);///
        public static glGetFramebufferAttachmentParameterivFun glGetFramebufferAttachmentParameteriv;
        /// <summary>
        /// Устанавливает для указанных имен переменных(в шейдере) режим TransformFeedback
        /// </summary>
        /// <param name="program">[In]Программа</param>
        /// <param name="count">[In]Количество переменных</param>
        /// <param name="varyings">[In]Указатель на массив ANSI-строк</param>
        /// <param name="bufferMode">[In]Режим буффера GL_INTERLEAVED_ATTRIBS или GL_SEPARATE_ATTRIBS</param>
        public delegate void glTransformFeedbackVaryingsFun(uint program, uint count, IntPtr varyings, int bufferMode);///
        public static glTransformFeedbackVaryingsFun glTransformFeedbackVaryings;
        /// <summary>
        /// Биндинг буффера (GL_TRANSFORM_FEEDBACK_BUFFER, GL_UNIFORM_BUFFER,...). 
        /// </summary>
        /// <param name="target">[In]Тип цели буффера GL_TRANSFORM_FEEDBACK_BUFFER, GL_UNIFORM_BUFFER, ...</param>
        /// <param name="index">[In]Индекс буффера</param>
        /// <param name="buffer">[In]Идентификатор буффера</param>
        public delegate void glBindBufferBaseFun(int target, uint index, uint buffer);///
        public static glBindBufferBaseFun glBindBufferBase;
        /// <summary>
        /// Начать вытягивание данных из шейдера механизмом TransformFeedback
        /// </summary>
        /// <param name="primitiveMode">Типы примитива Gl_POINTS, GL_LINES, GL_TRIANGLES...</param>
        public delegate void glBeginTransformFeedbackFun(int primitiveMode);///
        public static glBeginTransformFeedbackFun glBeginTransformFeedback;
        /// <summary>
        /// Закончить вытягивание данных из шейдера механизмом TransformFeedback
        /// </summary>
        public delegate void glEndTransformFeedbackFun();///
        public static glEndTransformFeedbackFun glEndTransformFeedback;
        /// <summary>
        /// Подгружает делегат OpenGL для вызова
        /// </summary>
        /// <typeparam name="T">[In]Сигнатура делегата</typeparam>
        /// <param name="name">[In]Имя функции в OpenGL API</param>
        /// <returns>Делегат для вызова</returns>
        public static T GetProcAddress<T>(string name)
        {
            var ptr = wglGetProcAddress(name);
            return Marshal.GetDelegateForFunctionPointer<T>(ptr);
        }
        /// <summary>
        /// Загрузка всех указанных делегатов из видеодрайвера
        /// </summary>
        public static void Load()
        {
            glGenFramebuffers = GetProcAddress<glGenFramebuffersFun>("glGenFramebuffers");
            glBindFramebuffer = GetProcAddress<glBindFramebufferFun>("glBindFramebuffer");
            glFramebufferTexture2D = GetProcAddress<glFramebufferTexture2DFun>("glFramebufferTexture2D");
            glDeleteFramebuffers = GetProcAddress<glDeleteFramebuffersFun>("glDeleteFramebuffers");
            glBlitFramebuffer = GetProcAddress<glBlitFramebufferFun>("glBlitFramebuffer");
            glGetFramebufferAttachmentParameteriv = GetProcAddress<glGetFramebufferAttachmentParameterivFun>("glGetFramebufferAttachmentParameteriv");
            //Подключение механизма TransformFeedback
            glTransformFeedbackVaryings = GetProcAddress<glTransformFeedbackVaryingsFun>("glTransformFeedbackVaryings");
            glBindBufferBase = GetProcAddress<glBindBufferBaseFun>("glBindBufferBase");
            glBeginTransformFeedback = GetProcAddress<glBeginTransformFeedbackFun>("glBeginTransformFeedback");
            glEndTransformFeedback = GetProcAddress<glEndTransformFeedbackFun>("glEndTransformFeedback");
        }
        /// <summary>
        /// Устанавливает для указанных имен переменных(в шейдере) режим TransformFeedback
        /// </summary>
        /// <param name="program"></param>
        /// <param name="count"></param>
        /// <param name="varyings"></param>
        /// <param name="bufferMode"></param>
        public static void TransformFeedbackVaryings(uint program, uint count, string[] varyings, int bufferMode)
        {
            var ptr = MarshalStringArrayToPtr(varyings);
            glTransformFeedbackVaryings(program, count, ptr, bufferMode);
            MarshalFreeArrayString(ptr, varyings.Length);
        }

        private static IntPtr MarshalStringArrayToPtr(string[] str_array)
        {
            IntPtr intPtr = IntPtr.Zero;
            intPtr = Marshal.AllocHGlobal(str_array.Length * IntPtr.Size);
            for (var i = 0; i < str_array.Length; ++i)
            {
                IntPtr val = MarshalStringToPtr(str_array[i]);
                Marshal.WriteIntPtr(intPtr, i * IntPtr.Size, val);
            }
            return intPtr;
        }

        private static IntPtr MarshalStringToPtr(string str)
        {
            str = str + char.MinValue;
            var bytes = Encoding.UTF8.GetBytes(str);
            IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length);

            Marshal.Copy(bytes, 0, intPtr, bytes.Length);
            return intPtr;
        }

        private static void MarshalFreeArrayString(IntPtr ptr, int length)
        {
            for (int i = 0; i < length; ++i)
                Marshal.FreeHGlobal(Marshal.ReadIntPtr(ptr, i * IntPtr.Size));
            Marshal.FreeHGlobal(ptr);
        }
    }
}
