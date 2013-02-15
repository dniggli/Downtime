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
using FunctionalCSharp;

namespace downtimeC
{
    public class OrderNumberForComobBox
    {
        public readonly string AlphaVersion;
        public readonly string IntVersion;

        public OrderNumberForComobBox(string AlphaVersion, string IntVersion)
        {
            this.IntVersion = IntVersion;
            this.AlphaVersion = AlphaVersion;
        }

        public override string ToString()
        {
            return AlphaVersion;
        }
    }

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

        string TDate;
        public void submitneworder(string ordernumber)
        {
            getSqlServer.ExecuteNonQuery("truncate table [ordered]");


            TDate = DateTimeFunctions.datetomysql(System.DateTime.Now.ToString());

            //..........//////use to reinstate alpha-numeric(also un-comment line items 540-547 in orderentry)\\\\\\\\.........


            getSqlServer.ExecuteNonQuery("insert into ordernumber (OrderLast,Ordernumber, Date) VALUES (0," + ordernumber + ", '" + TDate + "');");
        }


        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            getIntOrderNumber().forEach(ordernumber =>
            {
                if (ComboBoxNewOrderNumber.SelectedIndex.ToString().Length > 1)
                {
                    Interaction.MsgBox("Ordernumber has not been selected.  Please select Ordernubmer", MsgBoxStyle.OkOnly, "MsgBox");
                    return;
                }

                var response = Interaction.MsgBox("Are you Sure you Want to Clear ALL DATA????", MsgBoxStyle.YesNo, "MsgBox");
                if (response == MsgBoxResult.Yes)
                {
                    getSqlServer.ExecuteNonQuery("truncate table ordernumber");
                    submitneworder(ordernumber);
                    Interaction.MsgBox("Old Data Has Been Cleard and Ordernumber Has Been Reset.", MsgBoxStyle.OkOnly, "MsgBox");
                }
            });
        }

        private void Buttondelettrack_Click(System.Object sender, System.EventArgs e)
        {
            var response = Interaction.MsgBox("Are you Sure you Want to reset tracking?", MsgBoxStyle.YesNo, "MsgBox");
            if (response == MsgBoxResult.Yes)
            {
                getSqlServer.ExecuteNonQuery("truncate table dttracking");
            }
        }

        public string date2ordernumber(string dates)
        {
            string ordend = dates;

            System.Text.RegularExpressions.Match dateend = Regex.Match(ordend, "([0-9]+)/([0-9]+)/([0-9]+)");
            string endmonth = dateend.Groups[1].Value;
            string endday = dateend.Groups[2].Value;
            string endyear = dateend.Groups[3].Value;
            while (endday.Length < 2)
            {
                endday = "0" + endday;
            }



            int endmnth = int.Parse(endyear) - 2004;
            endmnth = endmnth * 12;


            string monthend = Convert.ToString(Convert.ToInt32(endmonth) + Convert.ToInt32(endmnth));

            if (int.Parse(monthend) > 99)
            {
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
            //load combobox and Dictionary
            var dr = getSqlServer.FilledRow("select * from NumberWheel;");

            string datanumber = dr["OrderNumberAlpha"].ToString();
            string lownumber = dr["OrderNumberNumer"].ToString();
            //int n = Convert.ToInt32(lownumber);


            //while (n < 8001)
            //{
            //    string nonalphaordernumber = (date2ordernumber(System.DateTime.Now.ToString()) + n.ToString());
            //    ComboBoxNewOrderNumber.Items.Add(
            //        new OrderNumberForComobBox(nonalphaordernumber, n.ToString()));// nonalphaordernumber);

            //    n = n + 500;
            //}

            string ordernums = Strings.Right(datanumber, 3);
            char letters = Strings.Chr(int.Parse(Strings.Left(datanumber, 2)));

            string alphanum = date2ordernumber(System.DateTime.Now.ToString()) + letters + ordernums;

            ComboBoxNewOrderNumber.Items.Add(
                new OrderNumberForComobBox(alphanum, datanumber));
        }

        private void resetOrderNumber(string ordernumber)
        {
            getSqlServer.ExecuteNonQuery("truncate table ordernumber");

            submitneworder(ordernumber);

            Interaction.MsgBox("Order Number Has Been Reset", MsgBoxStyle.OkOnly, "MsgBox");
        }

        private void ButtonNumberReset_Click(System.Object sender, System.EventArgs e)
        {
            getIntOrderNumber().forEach(ordernumber =>
            {
                Option<DataRow> drOption = getSqlServer.FilledRowOption("SELECT TOP 1 Date FROM ordernumber ORDER BY Date DESC;");

                var reset = drOption.map(dr =>
                {
                    if (DateTime.Now.Date == dr.Field<DateTime>("Date"))
                    {
                        var response = Interaction.MsgBox(
                            "Order Number has already been reset for today.  Would you like to reset it again?"
                             , MsgBoxStyle.YesNo, "MsgBox");

                        if (response == MsgBoxResult.No) return false;
                    }

                    return true;
                });

                if (reset.getOrElse(() => true)) resetOrderNumber(ordernumber);
            });
        }

        private void ComboBoxNewOrderNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        /// <summary>
        /// Get the version of the ordernumber that represents the CHAR in the number as Int
        /// </summary>
        /// <returns></returns>
        private Option<string> getIntOrderNumber()
        {
            if (ComboBoxNewOrderNumber.SelectedIndex.ToString().Length > 1)
            {
                Interaction.MsgBox("Ordernumber has not been selected.  Please select Ordernubmer", MsgBoxStyle.OkOnly, "MsgBox");
                return Option.None<string>();
            }

            return Option.Some(((OrderNumberForComobBox)ComboBoxNewOrderNumber.SelectedItem).IntVersion);
        }

    }

}
