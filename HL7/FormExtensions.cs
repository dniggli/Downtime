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
       public static void ClearAllInputControls(this Form form, params Control[] except)
       {
           ClearAllTextBoxes(form, except.Where(c => c is TextBox).Cast<TextBox>().ToArray());
           ClearAllComboBoxes(form, except.Where(c => c is ComboBox).Cast<ComboBox>().ToArray());
       }

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
       /// Clear all Textboxes of the form except for the given textboxes.
       /// </summary>
       /// <param name="form"></param>
       /// <param name="except"></param>
       public static void ClearAllComboBoxes(this Form form, params ComboBox[] except)
       {
           ActionAllControl<ComboBox>(form, cmb => {
               if (cmb.Items.Count > 0)
               {
                   cmb.SelectedIndex = -1;
               }
           }, except);
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
