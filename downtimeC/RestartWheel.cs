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
using MySql.Data.MySqlClient;
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

        readonly GetMySQL getMySql;
        public RestartWheel(GetMySQL getMySql)
        {
            InitializeComponent();
            this.getMySql = getMySql;
        }

    string monthday = "";
    string ordernumber = "";
    string TDate = "";

    Dictionary<string, string> dict = new Dictionary<string, string>();

 
    public void Deleteoldinfo()
    {


        MySqlCommand comm1 = new MySqlCommand("truncate table dtdb1.ordernumber", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));

        comm1.Connection.Open();
        comm1.ExecuteNonQuery();
        comm1.Connection.Close();

    }



    public void Deleteoldtrackinfo()
    {
        MySqlCommand comm = new MySqlCommand("truncate table dtdb1.dttracking", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));

        comm.Connection.Open();
        comm.ExecuteNonQuery();
        comm.Connection.Close();

    }



    public void submitneworder()
    {
        MySqlCommand comm2 = new MySqlCommand("truncate table dtdb1.Table1", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));

        comm2.Connection.Open();
        comm2.ExecuteNonQuery();
        comm2.Connection.Close();



        TDate = DateTimeFunctions.datetomysql(System.DateTime.Now.ToString());

        //..........//////use to reinstate alpha-neumaric(also un-comment line items 540-547 in orderentry)\\\\\\\\.........


        MySqlCommand comm = new MySqlCommand("insert into dtdb1.ordernumber (Ordernumber, Date) VALUES ('" + ordernumber + "', '" + TDate + "');", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));

        //Dim comm As New MySqlCommand("insert into dtdb1.ordernumber (Ordernumber, Date) VALUES ('5000', '" & TDate & "');", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
        comm.Connection.Open();
        comm.ExecuteNonQuery();
        comm.Connection.Close();

    }


    private void Button1_Click(System.Object sender, System.EventArgs e)
    {


        if (ComboBoxNewOrderNumber.SelectedIndex.ToString().Length > 1) {
            string msg1 = null;
            string title1 = null;
            MsgBoxStyle style1 = default(MsgBoxStyle);
            MsgBoxResult response1 = default(MsgBoxResult);

            msg1 = "Ordernumber has not been selected.  Please select Ordernubmer";
            // Define message.
            style1 = MsgBoxStyle.OkOnly;
            title1 = "MsgBox";
            // Define title.
            // Display message.
            response1 = Interaction.MsgBox(msg1, style1, title1);
            if (response1 == MsgBoxResult.Ok) {
                return;
            }

        }


        string msg = null;
        string title = null;
        MsgBoxStyle style = default(MsgBoxStyle);
        MsgBoxResult response = default(MsgBoxResult);

        msg = "Are you Sure you Want to Clear ALL DATA????";
        // Define message.
        style = MsgBoxStyle.YesNo;
        title = "MsgBox";
        // Define title.
        // Display message.
        response = Interaction.MsgBox(msg, style, title);
        if (response == MsgBoxResult.Yes) {
            Deleteoldinfo();
            submitneworder();

        }
        if (response == MsgBoxResult.No) {
            return;
        }



        msg = "Old Data Has Been Cleard and Ordernumber Has Been Reset.";
        // Define message.
        style = MsgBoxStyle.OkOnly;
        title = "MsgBox";
        // Define title.
        // Display message.
        response = Interaction.MsgBox(msg, style, title);

        if (response == MsgBoxResult.Ok) {
        }


    }

    private void Buttondelettrack_Click(System.Object sender, System.EventArgs e)
    {
        string msg = null;
        string title = null;
        MsgBoxStyle style = default(MsgBoxStyle);
        MsgBoxResult response = default(MsgBoxResult);

        msg = "Are you Sure you Want to reset tracking?";
        // Define message.
        style = MsgBoxStyle.YesNo;
        title = "MsgBox";
        // Define title.
        // Display message.
        response = Interaction.MsgBox(msg, style, title);
        if (response == MsgBoxResult.Yes) {
            Deleteoldtrackinfo();

        }
        if (response == MsgBoxResult.No)
            return;

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







        //.......................///////////// Create Alpha-neumaric OrderNumber \\\\\\\\\\\\\\\\\........................



        MySqlDataAdapter DatabaseNumber = new MySqlDataAdapter("select * from dtdb1.NumberWheel;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;");

        DataTable dt = new DataTable();
        DatabaseNumber.Fill(dt);

        DataRow dr = dt.Rows[0];

        string datanumber = dr["OrderNumberAlpha"].ToString();
        string lownumber = dr["OrderNumberNumer"].ToString();




        int n = Convert.ToInt32(lownumber);

        while (n < 8001) {
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

        MySqlDataAdapter ch = new MySqlDataAdapter("SELECT Date FROM dtdb1.ordernumber order BY Date DESC lIMIT 1;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;");
        DataTable dtble = new DataTable();
        ch.Fill(dtble);

        DataRow q = dtble.Rows[0];
        System.DateTime datestring = q.Field<DateTime>("Date");

        System.DateTime checkdate = System.DateTime.Now.Date;



        if (!(checkdate == datestring)) {
            MySqlCommand comm1 = new MySqlCommand("truncate table dtdb1.ordernumber", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));

            comm1.Connection.Open();
            comm1.ExecuteNonQuery();
            comm1.Connection.Close();

            submitneworder();

            string msg1 = null;
            string title1 = null;
            MsgBoxStyle style1 = default(MsgBoxStyle);
            MsgBoxResult response1 = default(MsgBoxResult);

            msg1 = "Order Number Has Been Reset";
            // Define message.
            style1 = MsgBoxStyle.OkOnly;
            title1 = "MsgBox";
            // Define title.
            // Display message.
            response1 = Interaction.MsgBox(msg1, style1, title1);



        } else {
            string msg = null;
            string title = null;
            MsgBoxStyle style = default(MsgBoxStyle);
            MsgBoxResult response = default(MsgBoxResult);

            msg = "Order Number has already been reset for today.  Would you like to reset it again?";
            // Define message.
            style = MsgBoxStyle.YesNo;
            title = "MsgBox";
            // Define title.
            // Display message.
            response = Interaction.MsgBox(msg, style, title);

            if (response == MsgBoxResult.No) {

            } else if (response == MsgBoxResult.Yes) {
                MySqlCommand comm1 = new MySqlCommand("truncate table dtdb1.ordernumber", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));

                comm1.Connection.Open();
                comm1.ExecuteNonQuery();
                comm1.Connection.Close();

                submitneworder();

                string msg1 = null;
                string title1 = null;
                MsgBoxStyle style1 = default(MsgBoxStyle);
                MsgBoxResult response1 = default(MsgBoxResult);

                msg1 = "Order Number Has Been Reset";
                // Define message.
                style1 = MsgBoxStyle.OkOnly;
                title1 = "MsgBox";
                // Define title.
                // Display message.
                response1 = Interaction.MsgBox(msg1, style1, title1);
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
