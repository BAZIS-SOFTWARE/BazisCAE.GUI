using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void показатьСопряженныеItem_Click(object sender, EventArgs e)
        {
            try
            {
                var objTypeStr = SelectedObjects;

                foreach (var item in GetModelObjects(objTypeStr).
            Where(x => x.Color == settingsConfig.SelectObjectColor))
                {
                    // TO DO ввести понятие размерности объекта чтобы избежать
                    // ненужных преобразований

                    var dim = (int)item.ObjType;
                    ShowAdg(dim, item.Number, 1);
                    ShowAdg(dim, item.Number, 2);

                    ObjType objType;

                    if(dim + 1 == 3)
                        objType = (ObjType)(dim);
                    else
                        objType = (ObjType)(dim + 1);

                    var setU = project.GetModelSetInfo(objType, objType.ToString());
                    PresentSet(setU);

                    if (dim - 1 != -1)
                    {
                        objType = (ObjType)(dim - 1);
                        var setD = project.GetModelSetInfo(objType, objType.ToString());
                        PresentSet(setD);
                    }

                }
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
            
        }
    }
}
