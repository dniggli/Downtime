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
       public static void ClearAllTextBoxes(this Form form, params TextBox[] except) {
           
        foreach (Control C in form.Controls)
            {
                if (C is TextBox && (!except.Contains(C)))
                {
                    TextBox TB = (TextBox)C;
                    TB.Clear();                    
                }
            }
       }

    }
}
