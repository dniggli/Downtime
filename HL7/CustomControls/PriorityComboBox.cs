using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FunctionalCSharp;
using CodeBase2.Database;
using downtimeC.LabelPrinting;

namespace downtimeC
{

    public partial class PriorityComboBox : StoredComboBox
    {
        public PriorityComboBox() : base()
        {
            InitializeComponent();
        }

        public override String Text
        {
            get
            {
            
                if (base.Text == "S")
                {
                    return "STAT";
                }
                else 
                {
                    return base.Text;
                }
            }
        }

        public Option<Priority> getPriorityOption
        {
            get
            {
                if (base.Text == "R") {
                    return Option.Some(Priority.Routine);
                }
                else if (base.Text == "S")
                {
                    return Option.Some(Priority.Stat);
                }
                else if (base.Text == "U")
                {
                    return Option.Some(Priority.Urgent);
                }
                else
                {
                   return Option.None<Priority>();
                }
                
            }
        }

    }
}
