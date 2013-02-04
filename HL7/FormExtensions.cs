using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using System.Windows.Forms;

namespace downtimeC
{
   public static class FormExtensions
    {
       /// <summary>
       /// Clear all Textboxes of the form except for the given textboxes.
       /// </summary>
       /// <param name="form"></param>
       /// <param name="except"></param>
       public static void ClearAllTextBoxes(this Form form, params TextBox[] except)
       {

           ActionAllControl<TextBox>(form, tb => tb.Clear(), except);
       }

       /// <summary>
       /// Enable all Textboxes of the form except for the given textboxes.
       /// </summary>
       /// <param name="form"></param>
       /// <param name="except"></param>
       public static void EnableAll<T>(this Form form, params T[] except) where T : Control
       {

           ActionAllControl<T>(form, tb => tb.Enabled = true, except);
       }

       /// <summary>
       /// Disable all Textboxes of the form except for the given textboxes.
       /// </summary>
       /// <param name="form"></param>
       /// <param name="except"></param>
       public static void DisableAll<T>(this Form form, params T[] except)  where T:Control
       {
           ActionAllControl<T>(form, tb => tb.Enabled = false, except);
       }

       public static void ActionAllControl<T>(this Form form,Action<T> action, params T[] except) where T:Control
       {
           foreach (Control C in form.Controls)
           {
               if (C is T && (!except.Contains(C)))
               {
                   T TB = (T)C;
                   action(TB);
               }
           }
       }

    }
}
