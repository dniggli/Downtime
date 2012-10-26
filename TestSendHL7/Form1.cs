using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL7;

namespace TestSendHL7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set the IP and port to send to
            var sendhl = new SendHl7("lis-s22104-9000", 52345);

            //create the HL7 message
            var codes = new List<string>();
            codes.Add("CMP");
            
            var co = new OrderMessage("mrn", "firstName", "lastName", "orderNumber00","20121023", "ward",Sex.U, codes);
            var hl = co.toHl7();

            //send the hl7 message
            sendhl.SendHL7(hl);

        }
    }
}
