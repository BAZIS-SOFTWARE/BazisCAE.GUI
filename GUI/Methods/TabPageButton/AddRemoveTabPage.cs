using BazisGUI.Scene.Interfaces;
using Microsoft.Scripting.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void ShowTabButton(string btnName)
        {
            var max_y = 0;

            for (int i = 0; i < splitContainer3.Panel1.Controls.Count; i++)
            {
                var cntr = splitContainer3.Panel1.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible == true)
                    if (cntr.Location.Y > max_y)
                        max_y = cntr.Location.Y;
            }

            var show = splitContainer3.Panel1.Controls.Find(btnName,false)[0];
            show.Visible = true;
            show.Location = new Point(0,max_y + show.Height + show.Margin.Bottom);
        }

        public void HideTabButton(string btnName)
        {
            var hide = splitContainer3.Panel1.Controls.Find(btnName,false)[0];
            hide.Visible = false;

            for (int i = 0; i < splitContainer3.Panel1.Controls.Count; i++)
            {
                var cntr = splitContainer3.Panel1.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible == true)
                {
                    if(cntr.Location.Y > hide.Location.Y)
                    {
                        var temp_x = cntr.Location.X;
                        var temp_y = cntr.Location.Y;
                        cntr.Location = new Point(temp_x, temp_y -
                            hide.Location.Y);
                    }
                    
                }
            }
        }
    }
}
