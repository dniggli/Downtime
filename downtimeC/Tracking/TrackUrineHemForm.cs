using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using HL7;

namespace downtimeC
{
    public partial class TrackUrineHemForm : TrackingBase
    {
        public TrackUrineHemForm(GetSqlServer getSqlServer)
            : base(getSqlServer)
        {
          InitializeComponent();
        }

        protected override int RequiredTagLength()
        {
            return 4;
        }

        protected override string IncrementTrackingTag(string tracktag)
        {
            int subTRACKTAG = int.Parse(Strings.Right(tracktag, 3));
            string subtracktag1 = Strings.Left(tracktag, 1);
            subTRACKTAG += 1;


            string subTRACKTAG_increment = subTRACKTAG.ToString();

            while (subTRACKTAG_increment.ToString().Length < 3)
            {
                subTRACKTAG_increment = "0" + subTRACKTAG_increment;
            }


            return subtracktag1 + subTRACKTAG_increment;
        }
    }
}
