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
using System.Text.RegularExpressions;

namespace downtimeC
{

    public partial class OptionTextBox : TextBox, IOption
    {
        public OptionTextBox()
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

        private string regexValidation = "";

        /// <summary>
        /// Regex to use to validate the Textbox
        /// </summary>
        [Browsable(true)]
        public string RegexValidation
        {
            get { return this.regexValidation; }
            set { this.regexValidation = value; }
        }

        private bool isRegexValid(string s)
        {
             return string.IsNullOrEmpty(RegexValidation) ?
                 true //If RegexValidation is empty, then return true
             :
                 new Regex(regexValidation).IsMatch(s) ? true : promptUser();
        }

        private bool promptUser()
        {
            var prompt = string.IsNullOrEmpty(validationPrompt) ? this.Name : validationPrompt;
            MessageBox.Show(prompt, "Validate TextBox", MessageBoxButtons.OK);
            this.Focus();
            return false;
        }

        /// <summary>
        /// Determine if the TextBox is properly filled out.  And prompt the user if not
        /// </summary>
        /// <returns></returns>
          public bool Validate()
        {
            return TextOption.Match()
                // if TextOption has a value, then validate it against Regex              
                    .Some(s => isRegexValid(s))  // if RegexValidation isn't empty then validate it against Regex
                    .None(() =>
                        //if TextOption is has no value AND is required then prompt user and return false
                        Required ? promptUser() : true
                    )
                    .Return<bool>();
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
