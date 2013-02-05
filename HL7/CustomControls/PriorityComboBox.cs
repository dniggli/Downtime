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
                    return "Stat";
                }
                else 
                {
                    return base.Text;
                }
            }
        }

        public Priority getPriority
        {
            get
            {
                if (base.Text == "R") {
                    return Priority.Routine;
                }
                else if (base.Text == "S")
                {
                    return Priority.Stat;
                }
                else if (base.Text == "U")
                {
                    return Priority.Urgent;
                }
                else
                {
                    throw new NotImplementedException("Undefined Priority");
                }
                
            }
        }

    }
}
