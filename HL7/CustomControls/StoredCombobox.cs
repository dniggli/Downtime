﻿using System;
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

    public partial class StoredComboBox : OptionComboBox, IStoredControl
    {
        public StoredComboBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private string dataColumnName = "";

        [Browsable(true)]
        public string DataColumnName
        {
            get { return this.dataColumnName; }
            set { this.dataColumnName = value; }
        }

        public void setValue(string value)
        {
            this.Text = value;
        }
    }
}
