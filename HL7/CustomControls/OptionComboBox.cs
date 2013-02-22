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

namespace downtimeC
{

    public partial class OptionComboBox : ComboBox, IOption
    {
        public OptionComboBox()
            : base()
        {
            InitializeComponent();
        }

        public Option<string> TextOption
        {
            get
            {
                string v = this.Text.Trim();
                return (string.IsNullOrEmpty(v)) ? Option.None<String>() : Option.Some(v);
            }
            set
            {
                value.forEach(v => this.Text = v);
            }
        }


        private string validationPrompt = "";

        [Browsable(true)]
        public string ValidationPrompt
        {
            get { return this.validationPrompt; }
            set { this.validationPrompt = value; }
        }

        /// <summary>
        /// Determine if the ComboBox is properly filled out.  And prompt the user if not
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (this.TextOption.isEmpty && Required)
            {
                var prompt = string.IsNullOrEmpty(validationPrompt) ? this.Name : validationPrompt;
                MessageBox.Show(prompt, "Validate Combobox", MessageBoxButtons.OK);
                this.Focus();
            }
            return this.TextOption.isDefined;
        }

        private bool required = false;

        [Browsable(true)]
        public bool Required
        {
            get { return this.required; }
            set { this.required = value; }
        }
    }
}
