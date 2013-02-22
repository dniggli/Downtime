using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using HL7;


namespace downtimeC
{
    public partial class TrackCoagForm : TrackingBase
    {
        public TrackCoagForm(GetSqlServer getSqlServer)
            : base(getSqlServer)
        {
            InitializeComponent();
        }

        protected override int RequiredTagLength()
        {
            return 5;
        }

        protected override string IncrementTrackingTag(string tracktag)
        {
            //DIFFERENCE FROM TRACKINGBASE
            string subTRACKTAG_increment = (int.Parse(Strings.Right(tracktag, 2)) + 1).ToString();

            while (subTRACKTAG_increment.ToString().Length < 2)
            {
                subTRACKTAG_increment = "0" + subTRACKTAG_increment;
            }

           return Strings.Left(tracktag, 4) + subTRACKTAG_increment;
        }
 
    }
}
