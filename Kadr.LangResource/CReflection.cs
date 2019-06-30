using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kadr.LangResource
{
    public static class CReflection
    {
        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls
                .OfType<T>()
                .Concat<T>(controls.SelectMany<Control, T>(ctrl => FindAllChildrenByType<T>(ctrl)));
        }

        public static void ProcessAllControls(Control rootControl, Action<Control> action)
        {
            foreach (Control childControl in rootControl.Controls)
            {
                ProcessAllControls(childControl, action);
                action(childControl);
            }
        }

        public static IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);

            return controls;
        }

        public static Control.ControlCollection GetAll(Control control)
        {
            return control.Controls[0].Controls;            
        }

        //public static IEnumerable<Control> GetAllControls(this Control root)
        //{
        //    var queue = new Queue<Control>();
        //    queue.Enqueue(root);
        //    do
        //    {
        //        var control = queue.Dequeue();
        //        yield return control;
        //        foreach (var child in control.Controls.OfType<Control>())
        //            queue.Enqueue(child);
        //    } while (queue.Count > 0);
        //}

        public static IEnumerable<Control> GetAllControls(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static void SetVal()
        {
            //PropertyInfo pi = typeof(BaseEdit).GetProperty("Properties");
            //try
            //{
            //    object properties = pi.GetValue(control, null);
            //    pi = properties.GetType().GetProperty("ReadOnly", BindingFlags.Instance | BindingFlags.Public);
            //    if (pi != null)
            //        pi.SetValue(properties, true, null);
            //}
            //catch
            //{
            //}
        }
    }
}
