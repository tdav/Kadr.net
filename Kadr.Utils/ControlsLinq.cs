using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Apteka.Utils
{
    public static class ControlCollectionExtensions
   {
      public static void ForEach(this Control.ControlCollection ControlCollection, Action<Control> Action)
      {
         for (int i = 0; i < ControlCollection.Count; i++)
         {
            Action.Invoke(ControlCollection[i]);
         }   
      }
      public static void For(this Control.ControlCollection ControlCollection, int Start, int End, int Step, Action<Control> Action)
      {
         for (int i = Start; i < End; i++)
         {
            Action.Invoke(ControlCollection[i]);
         }   
      }
      public static void For(this Control.ControlCollection ControlCollection, int Start, Func<int, bool> End, int Step, Action<Control> Action)
      {
         for (int i = Start; End.Invoke(i); i++)
         {
            Action.Invoke(ControlCollection[i]);
         }
      }
      public static List<Control> Where(this Control.ControlCollection ControlCollection, Func<Control, bool> Condition, bool SearchAllChildren)
      {
         List<Control> lstControls = new List<Control>();
         ControlCollection.ForEach(ctrl => 
         {
            if (SearchAllChildren)
            {
               lstControls.AddRange(ctrl.Controls.Where(Condition, true));
            }
            if (Condition.Invoke(ctrl)) 
               lstControls.Add(ctrl); 
         });
         return lstControls;
      }
      public static List<Control> FindControlsByType(this Control.ControlCollection ControlCollection, Type Type, bool SearchAllChildren)
      {
         List<Control> lstControls = new List<Control>();
         ControlCollection.ForEach(ctrl => 
         {
            if (SearchAllChildren)
            {
               lstControls.AddRange(ctrl.Controls.FindControlsByType(Type, true));
            }
            if (ctrl.GetType() == Type) 
               lstControls.Add(ctrl); 
         });

         return lstControls;
      }
      public static List<Control> ToList(this Control.ControlCollection ControlCollection, bool IncludeChildren)
      {
         List<Control> lstControls = new List<Control>();
         ControlCollection.ForEach(ctrl =>
         {
            if (IncludeChildren)
               lstControls.AddRange(ctrl.Controls.ToList(true));
            lstControls.Add(ctrl);
         });
         return lstControls;
      }
   }
}


                      
////Find control of type RichTextBox
//List<Control> lstControls = this.Controls.FindControlsByType(typeof(RichTextBox), true);

////Where control Name is rtbScratchPad
//List<Control> lstControls1 = this.Controls.Where(ctrl => ctrl.Name == "rtbScratchPad", true);

////For each control in the collection
//this.Controls.ForEach(ctrl => MessageBox.Show(ctrl.Name));

////For every second control in the collection
//this.Controls.For(0, this.Controls.Count - 1, 2, ctrl => MessageBox.Show(ctrl.Name));

////LINQ query on ControlCollection using ToList() extension
//Control c = (from ctrl in this.Controls.ToList(true)
//            where ctrl.Name == "rtbScratchPad"
//            select ctrl).Single();
//}
