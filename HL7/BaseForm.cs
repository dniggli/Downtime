using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace downtimeC
{
    public partial class BaseForm : Form
    {
       protected readonly DateTime StartupTime;

        /// <summary>
        /// Required for Visual Studio Designer to work.
        /// </summary>
       protected BaseForm()
       {
           InitializeComponent();
       }

        public BaseForm(DateTime StartupTime)
        {
            this.StartupTime = StartupTime;
            InitializeComponent();
        }
    }
}
