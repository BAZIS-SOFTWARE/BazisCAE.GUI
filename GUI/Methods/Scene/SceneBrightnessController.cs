using Model.Interfaces;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        /// <summary>
        /// Применяет затемнение и лёгкую десатурацию ко всем объектам указанного типа, за исключением объектов, помеченных как выделенные.
        /// </summary>
        /// <param name="objType">Тип объектов, к которым будет применено затемнение.</param>
        private void ApplyDim(ObjType objType)
        {
            var modelObjs = project.GetModelObjects(objType).Where(obj => obj.Color != settingsConfig.SelectObjectColor);

            foreach (var item in modelObjs)
                item.Color = ApplyBrightness(item.Color, 0.6f, 0.85f);
        }

        /// <summary>
        /// Применяет затемнение и частичную десатурацию к одному объекту указанного типа по его номеру.
        /// </summary>
        /// <param name="objType">Тип объекта, к которому будет применено затемнение.</param>
        /// <param name="number">Номер (идентификатор) объекта в коллекции данного типа.</param>
        private void ApplyDimElement(ObjType objType, int number)
        {
            var modelObj = project.GetModelObject(objType, number);
            modelObj.Color = ApplyBrightness(modelObj.Color, 0.6f, 0.85f);
        }

        /// <summary>
        /// Применяет к заданному цвету затемнение и частичную десатурацию.
        /// </summary>
        /// <param name="color">Исходный цвет, включая компонент альфа.</param>
        /// <param name="dimFactor">
        /// Коэффициент затемнения. Значение 1.0 оставляет яркость без изменений,
        /// значения меньше 1.0 затемняют цвет (например, 0.6 уменьшит яркость до 60%).
        /// Ожидается обычно в диапазоне [0, 1], но пользователь может передать и другие значения — результат будет зафиксирован через приведение и клиппинг.
        /// </param>
        /// <param name="desaturateFactor">
        /// Коэффициент десатурации (смешивания с серым). Значение 0.0 — без десатурации,
        /// 1.0 — полное смешивание с вычисленным серым (максимальная десатурация).
        /// Обычно находится в диапазоне [0, 1].
        /// </param>
        /// <returns>
        /// Новый экземпляр <see cref="Color"/>, унаследующий значение <see cref="Color.A"/> от исходного цвета,
        /// и с компонентами R/G/B, сначала масштабированными на <paramref name="dimFactor"/>, затем частично смешанными с серым
        /// в соответствии с <paramref name="desaturateFactor"/>. Компоненты R/G/B приводятся к целым и ограничиваются диапазоном [0,255].
        /// </returns>
        /// <remarks>
        /// Алгоритм:
        /// 1. Умножает R, G, B на <paramref name="dimFactor"/> (затемнение).
        /// 2. Вычисляет среднюю яркость (серый) как среднее R, G, B.
        /// 3. Смещает каждую компоненту в сторону серого на долю <paramref name="desaturateFactor"/>.
        /// 4. Осуществляет приведение к целому и клиппинг в диапазоне [0,255].
        /// Метод чистый (не изменяет входной цвет) и не затрагивает альфа-канал.
        /// </remarks>
        private Color ApplyBrightness(Color color, float dimFactor, float desaturateFactor)
        {
            // затемнение
            float r = color.R * dimFactor;
            float g = color.G * dimFactor;
            float b = color.B * dimFactor;

            // лёгкая десатурация (смешивание с серым)
            float gray = (r + g + b) * 0.33333334f;

            r += (gray - r) * desaturateFactor;
            g += (gray - g) * desaturateFactor;
            b += (gray - b) * desaturateFactor;

            int Clamp(float v) => Math.Max(0, Math.Min(255, (int)v));

            return Color.FromArgb(
                color.A,
                Clamp(r),
                Clamp(g),
                Clamp(b));
        }

    }
}
