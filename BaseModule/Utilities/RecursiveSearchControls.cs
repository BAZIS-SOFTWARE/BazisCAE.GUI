using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BaseModule.Utilities
{
    public static class RecursiveSearchControls
    {
        public static void AllTypedControls(Control ctrl, List<Control> controls, Type type)
        {
            // Работаем только с элементами искомого типа   
            if (ctrl.GetType() == type)
            {
                controls.Add(ctrl);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Control ctrlChild in ctrl.Controls)
            {
                AllTypedControls(ctrlChild, controls, type);
            }
        }

        public static void AllTypedControls<T>(Control ctrl, List<T> controls) where T : Control
        {
            // Работаем только с элементами искомого типа   
            if (ctrl.GetType() == typeof(T))
            {
                controls.Add((T)ctrl);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Control ctrlChild in ctrl.Controls)
            {
                AllTypedControls(ctrlChild, controls);
            }
        }

        public static void AllTypedControls(Component comp, List<Component> comps, Type type)
        {
            // Работаем только с элементами искомого типа   
            if (comp.GetType() == type)
            {
                comps.Add(comp);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Component ctrlChild in comp.Container.Components)
            {
                AllTypedControls(ctrlChild, comps, type);
            }
        }

        public static List<Form> AllTypedForms(FormCollection applicForms, Type type)
        {
            var findedForms = new List<Form>();
            foreach (Form form in applicForms)
            {
                foreach (Form formOwned in form.OwnedForms)
                {
                    if (formOwned.GetType() == type)
                        findedForms.Add(formOwned);
                }

            }
            return findedForms;
        }
    }
}
