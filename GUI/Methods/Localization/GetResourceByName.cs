using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public static string GetStringResourceByName(string name)
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString(name);
        }

        public static string GetStringResourceByName(Type componentType, string name)
        {
            var resources = new ComponentResourceManager(componentType);
            return resources.GetString(name);
        }

        public static string GetFileMissingCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("FileAbsenceCaption");
        }

        public static string GetErrorCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("ErrorCaption");
        }

        public static string GetAttentionCaption()
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return resources.GetString("AttentionCaption");
        }

        public static string GetErrorWithStackMessage(Exception ex)
        {
            var resources = new ComponentResourceManager(typeof(BaseForm));
            return $"{ex.Message} {resources.GetString("StackTrace")}:{ex.StackTrace}";
        }
    }
}
