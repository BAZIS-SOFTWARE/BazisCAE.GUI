using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangePointProperty(PropertyChangedEventArgs obj, int number)
        {
            if (Enum.TryParse(obj.Key, out PointPropertyKeys key))
                if (key == PointPropertyKeys.ElementSize)
                    SetMeshPoint(number, double.Parse(obj.NewValue));
        }

        private void PrepareDataForSetMeshPoint(string number, string meshSize)
        {
            var valid =
                int.TryParse(number, out var _number) &
                double.TryParse(meshSize, out var _meshSize);
                    if (!valid)
                throw new ArgumentException(Resources.InvalidCommandException);

            SetMeshPoint(_number, _meshSize);
        }

        private void SetMeshPoint(int number, double meshSize) => GmshController.SetSize(number, meshSize);
    }
}
