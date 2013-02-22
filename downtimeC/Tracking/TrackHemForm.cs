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
    public partial class TrackHemForm : TrackingBase
    {
        public TrackHemForm(GetSqlServer getSqlServer)
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
            int subTRACKTAG = int.Parse(Strings.Right(tracktag, 4));
            string subtracktag1 = Strings.Left(tracktag, 1);
            subTRACKTAG += 1;


            string subTRACKTAG_increment = subTRACKTAG.ToString();

            while (subTRACKTAG_increment.ToString().Length < 4)
            {
                subTRACKTAG_increment = "0" + subTRACKTAG_increment;
            }

            return subtracktag1 + subTRACKTAG_increment;
        }
    }
}

