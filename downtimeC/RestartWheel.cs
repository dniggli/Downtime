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

using System.Text.RegularExpressions;
using HL7;

namespace downtimeC
{
    public partial class RestartWheel : Form
    {
        protected RestartWheel()
        {
            InitializeComponent();
        }

        readonly GetSqlServer getSqlServer;
        public RestartWheel(GetSqlServer getSqlServer)
        {
            InitializeComponent();
            this.getSqlServer = getSqlServer;
        }

        string ordernumber = "";
        string TDate = "";

        Dictionary<string, string> dict = new Dictionary<string, string>();

    public void submitneworder()
    {
        getSqlServer.ExecuteNonQuery("truncate table dtdb1.Table1");


        TDate = DateTimeFunctions.datetomysql(System.DateTime.Now.ToString());

        //..........//////use to reinstate alpha-numeric(also un-comment line items 540-547 in orderentry)\\\\\\\\.........


        getSqlServer.ExecuteNonQuery("insert into dtdb1.ordernumber (Ordernumber, Date) VALUES ('" + ordernumber + "', '" + TDate + "');");
    }


    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        if (ComboBoxNewOrderNumber.SelectedIndex.ToString().Length > 1) {
           Interaction.MsgBox("Ordernumber has not been selected.  Please select Ordernubmer", MsgBoxStyle.OkOnly, "MsgBox"); 
           return;
        }

       var response = Interaction.MsgBox("Are you Sure you Want to Clear ALL DATA????", MsgBoxStyle.YesNo, "MsgBox");
        if (response == MsgBoxResult.Yes) {
            getSqlServer.ExecuteNonQuery("truncate table dtdb1.ordernumber");
            submitneworder();
            Interaction.MsgBox("Old Data Has Been Cleard and Ordernumber Has Been Reset.", MsgBoxStyle.OkOnly, "MsgBox");
        }
    }

    private void Buttondelettrack_Click(System.Object sender, System.EventArgs e)
    {
       var response = Interaction.MsgBox("Are you Sure you Want to reset tracking?", MsgBoxStyle.YesNo, "MsgBox");
        if (response == MsgBoxResult.Yes) {
            getSqlServer.ExecuteNonQuery("truncate table dtdb1.dttracking");
        }
    }

    public string date2ordernumber(string dates)
    {
        string ordend = dates;

        System.Text.RegularExpressions.Match dateend = Regex.Match(ordend, "([0-9]+)/([0-9]+)/([0-9]+)");
        string endmonth = dateend.Groups[1].Value;
        string endday = dateend.Groups[2].Value;
        string endyear = dateend.Groups[3].Value;
        while (endday.Length < 2) {
            endday = "0" + endday;
        }



        int endmnth = int.Parse(endyear)  - 2004;
        endmnth = endmnth * 12;


        string monthend = Convert.ToString(Convert.ToInt32(endmonth) + Convert.ToInt32(endmnth));

        if (int.Parse(monthend) > 99) {
            int newmonthstart = int.Parse(Strings.Left(monthend, 2));
            string newmonthend = Strings.Right(monthend, 1);
            newmonthstart = newmonthstart + 55;
            monthend = Microsoft.VisualBasic.Strings.Chr(newmonthstart) + newmonthend;
        }
        string monthday = monthend + endday;
        return (monthday);

    }


    private void restartwheel_Load(System.Object sender, System.EventArgs e)
    {
            var dr = getSqlServer.FilledRow("select * from dtdb1.NumberWheel;");
     
            string datanumber = dr["OrderNumberAlpha"].ToString();
            string lownumber = dr["OrderNumberNumer"].ToString();
            int n = Convert.ToInt32(lownumber);

            while (n < 8001)
            {
                string nonalphaordernumber = (date2ordernumber(System.DateTime.Now.ToString()) + n.ToString());
                ComboBoxNewOrderNumber.Items.Add(nonalphaordernumber);

                dict.Add(nonalphaordernumber, n.ToString());

                n = n + 500;
            }



            string ordernums = Strings.Right(datanumber, 3);
            char letters = Strings.Chr(int.Parse(Strings.Left(datanumber, 2)));



            string alphanum = date2ordernumber(System.DateTime.Now.ToString()) + letters + ordernums;
            string ordnumend = letters + ordernums;

            ComboBoxNewOrderNumber.Items.Add(alphanum);

            dict.Add(alphanum, ordnumend);

        
    }


    private void ButtonNumberReset_Click(System.Object sender, System.EventArgs e)
    {

        if (ComboBoxNewOrderNumber.SelectedIndex.ToString().Length > 1) {

          var response1 = Interaction.MsgBox("Ordernumber has not been selected.  Please select Ordernubmer", MsgBoxStyle.OkOnly, "MsgBox");
            if (response1 == MsgBoxResult.Ok) {
                return;
            }

        }

        DataRow q = getSqlServer.FilledRow("SELECT lIMIT 1 Date FROM dtdb1.ordernumber order BY Date DESC;");
        System.DateTime datestring = q.Field<DateTime>("Date");

        System.DateTime checkdate = System.DateTime.Now.Date;



        if (!(checkdate == datestring)) {

            getSqlServer.ExecuteNonQuery("truncate table dtdb1.ordernumber");
        

            submitneworder();

            Interaction.MsgBox("Order Number Has Been Reset",  MsgBoxStyle.OkOnly, "MsgBox");

        } else {
     
           var response = Interaction.MsgBox("Order Number has already been reset for today.  Would you like to reset it again?"
                , MsgBoxStyle.YesNo, "MsgBox");

           if (response == MsgBoxResult.Yes) {
                getSqlServer.ExecuteNonQuery("truncate table dtdb1.ordernumber");

                submitneworder();

                Interaction.MsgBox("Order Number Has Been Reset", MsgBoxStyle.OkOnly, "MsgBox");
            }




        }


    }

    private void ComboBoxNewOrderNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        e.SuppressKeyPress = true;
    }


    private void ComboBoxNewOrderNumber_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        ordernumber = dict[ComboBoxNewOrderNumber.SelectedItem.ToString()];

    }

}

}
