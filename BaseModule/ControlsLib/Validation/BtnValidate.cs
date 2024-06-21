using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public partial class BtnValidate : Button, IControlGroupValidator
    {
        public BtnValidate()
        {
            InitializeComponent();
            ControlsValidatingMethods = new List<Func<bool>>();
        }

        public BtnValidate(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ControlsValidatingMethods = new List<Func<bool>>();
        }

        public List<Func<bool>> ControlsValidatingMethods { get; }

        public void AddControlValidatingMethod(Func<bool> method) => ControlsValidatingMethods.Add(method);

        public void RemoveControlValidatingMethod(Func<bool> method) => ControlsValidatingMethods.Remove(method);

        public void AddRangeControlValidatingMethod(IEnumerable<Func<bool>> methods) =>
            ControlsValidatingMethods.AddRange(methods);

        /// <summary>
        /// Проходит всегда по всем валидаторам контроллов, проверяя их и выводя ошибку.
        /// </summary>
        /// <returns></returns>
        public bool ValidateControls() 
        {
            var result = true;
            foreach(var method in ControlsValidatingMethods)
            {
                if (!method())
                    result = false;
            }
            return result;
        }

        public bool ValidateControl_OnClick_IsValuesValid(object sender, CancelEventArgs cea)
        {
            if (!ValidateControls())
            {
                cea.Cancel = true;
                return false;
            }
            return true;
        }
    }
}
