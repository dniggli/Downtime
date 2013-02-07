using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;
using HL7;

namespace downtimeC
{
    public partial class StatOrderQueryForm : Form
    {
       protected StatOrderQueryForm()
        {
            InitializeComponent();
        }

    string QUERY;
    string QUERYName;
    readonly GetMySQL getMySql;
    public StatOrderQueryForm(string query, string queryName, GetMySQL getMySql)
    {
        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call.
        this.QUERY = query;
        this.QUERYName = queryName;
        this.getMySql = getMySql;
    }

    private void Form2_Load(System.Object sender, System.EventArgs e)
    {
        
        
        this.Text = QUERYName;
         getMySql.Async(this).FilledTable(QUERY, dt => {
             this.DataGridView1.DataSource = dt;
        });
    }



    private StringFormat oStringFormat;
    private StringFormat oStringFormatComboBox;
    private Button oButton;
    private CheckBox oCheckbox;

    private ComboBox oComboBox;
    private int nTotalWidth;
    private int nRowPos;
    private bool NewPage;
    private int nPageNo;
    private string Header = "Header Test";

    private string sUserName = "Will";

    private void PrintDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        oStringFormat = new StringFormat();
        oStringFormat.Alignment = StringAlignment.Near;
        oStringFormat.LineAlignment = StringAlignment.Center;
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter;

        oStringFormatComboBox = new StringFormat();
        oStringFormatComboBox.LineAlignment = StringAlignment.Center;
        oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap;
        oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter;

        oButton = new Button();
        oCheckbox = new CheckBox();
        oComboBox = new ComboBox();

        nTotalWidth = 0;

        foreach (DataGridViewColumn oColumn in DataGridView1.Columns) {
            nTotalWidth += oColumn.Width;

        }
        nPageNo = 1;
        NewPage = true;
        nRowPos = 0;

    }
    readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_PrintDocument1_PrintPage_oColumnLefts_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();
    List<int> static_PrintDocument1_PrintPage_oColumnLefts;
    readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_PrintDocument1_PrintPage_oColumnWidths_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();
    List<int> static_PrintDocument1_PrintPage_oColumnWidths;
    readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_PrintDocument1_PrintPage_oColumnTypes_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();
    List<Type> static_PrintDocument1_PrintPage_oColumnTypes;


    int static_PrintDocument1_PrintPage_nHeight;
    private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        lock (static_PrintDocument1_PrintPage_oColumnLefts_Init) {
            try {
                if (InitStaticVariableHelper(static_PrintDocument1_PrintPage_oColumnLefts_Init)) {
                    static_PrintDocument1_PrintPage_oColumnLefts = new List<int>();
                }
            } finally {
                static_PrintDocument1_PrintPage_oColumnLefts_Init.State = 1;
            }
        }
        lock (static_PrintDocument1_PrintPage_oColumnWidths_Init) {
            try {
                if (InitStaticVariableHelper(static_PrintDocument1_PrintPage_oColumnWidths_Init)) {
                    static_PrintDocument1_PrintPage_oColumnWidths = new List<int>();
                }
            } finally {
                static_PrintDocument1_PrintPage_oColumnWidths_Init.State = 1;
            }
        }
        lock (static_PrintDocument1_PrintPage_oColumnTypes_Init) {
            try {
                if (InitStaticVariableHelper(static_PrintDocument1_PrintPage_oColumnTypes_Init)) {
                    static_PrintDocument1_PrintPage_oColumnTypes = new List<Type>();
                }
            } finally {
                static_PrintDocument1_PrintPage_oColumnTypes_Init.State = 1;
            }
        }


        int i = 0;
        int nRowsPerPage = 0;
        int nTop = e.MarginBounds.Top;
        int nLeft = e.MarginBounds.Left;


        if (nPageNo == 1) {

            foreach (DataGridViewColumn oColumn in DataGridView1.Columns) {
                int nWidth = (int)Math.Floor((double)(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)));

                static_PrintDocument1_PrintPage_nHeight = (int)e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11;

                static_PrintDocument1_PrintPage_oColumnLefts.Add(nLeft);
                static_PrintDocument1_PrintPage_oColumnWidths.Add(nWidth);
                static_PrintDocument1_PrintPage_oColumnTypes.Add(oColumn.GetType());
                nLeft += nWidth;

            }

        }


        while (nRowPos < DataGridView1.Rows.Count - 1) {
            DataGridViewRow oRow = DataGridView1.Rows[nRowPos];


            if (nTop + static_PrintDocument1_PrintPage_nHeight >= e.MarginBounds.Height + e.MarginBounds.Top) {
                DrawFooter(e, nRowsPerPage);

                NewPage = true;
                nPageNo += 1;
                e.HasMorePages = true;
                return;


            } else {

                if (NewPage) {
                    // Draw Header
                    e.Graphics.DrawString(Header, new Font(DataGridView1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, new Font(DataGridView1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                    // Draw Columns
                    nTop = e.MarginBounds.Top;
                    i = 0;

                    foreach (DataGridViewColumn oColumn in DataGridView1.Columns) {
                        e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.LightGray), new Rectangle(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop, static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop, static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight));
                        e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, new SolidBrush(oColumn.InheritedStyle.ForeColor), new RectangleF(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop, static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight), oStringFormat);
                        i += 1;

                    }
                    NewPage = false;

                }

                nTop += static_PrintDocument1_PrintPage_nHeight;
                i = 0;

                foreach (DataGridViewCell oCell in oRow.Cells) {

                    if (object.ReferenceEquals(static_PrintDocument1_PrintPage_oColumnTypes[i], typeof(DataGridViewTextBoxColumn)) || object.ReferenceEquals(static_PrintDocument1_PrintPage_oColumnTypes[i], typeof(DataGridViewLinkColumn))) {
                        e.Graphics.DrawString(oCell.Value.ToString(), oCell.InheritedStyle.Font, new SolidBrush(oCell.InheritedStyle.ForeColor), new RectangleF(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop, static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight), oStringFormat);


                    } else if (object.ReferenceEquals(static_PrintDocument1_PrintPage_oColumnTypes[i], typeof(DataGridViewButtonColumn))) {
                        oButton.Text = oCell.Value.ToString();
                        oButton.Size = new Size(static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight);
                        Bitmap oBitmap = new Bitmap(oButton.Width, oButton.Height);
                        oButton.DrawToBitmap(oBitmap, new Rectangle(0, 0, oBitmap.Width, oBitmap.Height));
                        e.Graphics.DrawImage(oBitmap, new Point(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop));


                    } else if (object.ReferenceEquals(static_PrintDocument1_PrintPage_oColumnTypes[i], typeof(DataGridViewCheckBoxColumn))) {
                        oCheckbox.Size = new Size(14, 14);
                        oCheckbox.Checked = Convert.ToBoolean(oCell.Value);
                        Bitmap oBitmap = new Bitmap(static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight);
                        Graphics oTempGraphics = Graphics.FromImage(oBitmap);
                        oTempGraphics.FillRectangle(Brushes.White, new Rectangle(0, 0, oBitmap.Width, oBitmap.Height));
                        oCheckbox.DrawToBitmap(oBitmap, new Rectangle((Int32)(oBitmap.Width - oCheckbox.Width) / 2, (Int32)(oBitmap.Height - oCheckbox.Height) / 2, oCheckbox.Width, oCheckbox.Height));
                        e.Graphics.DrawImage(oBitmap, new Point(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop));


                    } else if (object.ReferenceEquals(static_PrintDocument1_PrintPage_oColumnTypes[i], typeof(DataGridViewComboBoxColumn))) {
                        oComboBox.Size = new Size(static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight);
                        Bitmap oBitmap = new Bitmap(oComboBox.Width, oComboBox.Height);
                        oComboBox.DrawToBitmap(oBitmap, new Rectangle(0, 0, oBitmap.Width, oBitmap.Height));
                        e.Graphics.DrawImage(oBitmap, new Point(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop));
                        e.Graphics.DrawString(oCell.Value.ToString(), oCell.InheritedStyle.Font, new SolidBrush(oCell.InheritedStyle.ForeColor), new RectangleF(static_PrintDocument1_PrintPage_oColumnLefts[i] + 1, nTop, static_PrintDocument1_PrintPage_oColumnWidths[i] - 16, static_PrintDocument1_PrintPage_nHeight), oStringFormatComboBox);


                    } else if (object.ReferenceEquals(static_PrintDocument1_PrintPage_oColumnTypes[i], typeof(DataGridViewImageColumn))) {
                        Rectangle oCellSize = new Rectangle(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop, static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight);
                        Size oImageSize = ((Image)oCell.Value).Size;
                        e.Graphics.DrawImage((Image)oCell.Value, new Rectangle(static_PrintDocument1_PrintPage_oColumnLefts[i] + (Int32)((oCellSize.Width - oImageSize.Width) / 2), nTop + (Int32)((oCellSize.Height - oImageSize.Height) / 2), ((Image)oCell.Value).Width, ((Image)oCell.Value).Height));

                    }

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(static_PrintDocument1_PrintPage_oColumnLefts[i], nTop, static_PrintDocument1_PrintPage_oColumnWidths[i], static_PrintDocument1_PrintPage_nHeight));

                    i += 1;

                }

            }

            nRowPos += 1;
            nRowsPerPage += 1;

        }

        DrawFooter(e, nRowsPerPage);

        e.HasMorePages = false;

    }


    private void DrawFooter(System.Drawing.Printing.PrintPageEventArgs e, Int32 RowsPerPage)
    {
        string sPageNo = nPageNo.ToString() + " of " + Math.Ceiling((double)(DataGridView1.Rows.Count / RowsPerPage)).ToString();

        // Right Align - User Name
        e.Graphics.DrawString(sUserName, DataGridView1.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridView1.Font, e.MarginBounds.Width).Width), e.MarginBounds.Top + e.MarginBounds.Height + 7);

        // Left Align - Date/Time
        e.Graphics.DrawString(DateAndTime.Now.ToLongDateString() + " " + DateAndTime.Now.ToShortTimeString(), DataGridView1.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 7);

        // Center  - Page No. Info
        e.Graphics.DrawString(sPageNo, DataGridView1.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridView1.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 31);

    }


    private void PrintDocument1_PrintPage_1(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
    }

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        PrintPreviewDialog dlg = new PrintPreviewDialog();

        dlg.Document = PrintDocument1;

        dlg.ShowDialog();



        //This code gives you the page setup form...

        PageSetupDialog psDlg = new PageSetupDialog();










    }


    private void PrintPreviewDialog1_Load(System.Object sender, System.EventArgs e)
    {
    }


    public void Button2_Click(System.Object sender, System.EventArgs e)
    {



        MySqlDataAdapter db = new MySqlDataAdapter(QUERY, new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));
        DataTable dt = new DataTable();

        db.Fill(dt);

        try {
            StreamWriter sw1 = new StreamWriter("C:\\Program Files\\downtime\\Testlist.csv", false);
            sw1.Close();

        } catch {

           var response1 = Interaction.MsgBox("file must be colsed", MsgBoxStyle.DefaultButton1, "MsgBox");


            AutoItHelper.AutoItX.WinActivate("Microsoft Excel - Testlist.csv");

            Thread.Sleep(2000);
            AutoItHelper.AutoItX.WinActivate("MsgBox");
            AutoItHelper.AutoItX.WinWaitClose("Microsoft Excel - Testlist.csv");


        }
        StreamWriter sw = new StreamWriter("C:\\Program Files\\downtime\\Testlist.csv", false);

        //Write line 1 for column names
        string columnnames = "";
        foreach (DataColumn dc in dt.Columns) {
            columnnames += "\"" + dc.ColumnName + "\",";
        }
        columnnames = columnnames.TrimEnd(',');
        sw.WriteLine(columnnames);
        //Write out the rows
        foreach (DataRow dr in dt.Rows) {
            string row = "";
            foreach (DataColumn dc in dt.Columns) {

                if ((dr[dc.ColumnName]) is byte[]) {
                    row += "\"" + getstring((byte[])dr[dc.ColumnName]) + "\",";
                } else {
                    row += "\"" + dr[dc.ColumnName].ToString() + "\",";
                }


            }
            row = row.TrimEnd(',');
            sw.WriteLine(row);
        }
        //Done writing

        sw.Close();


        string msg = null;
        string title = null;
        MsgBoxStyle style = default(MsgBoxStyle);
        MsgBoxResult response = default(MsgBoxResult);

        msg = "Your file is done. Would you like to open?";
        // Define message.
        style = MsgBoxStyle.YesNo;
        title = "MsgBox";
        // Define title.
        //Display message.
        response = Interaction.MsgBox(msg, style, title);
        if (response == MsgBoxResult.Yes) {
            Microsoft.Office.Interop.Excel.Application excel = default(Microsoft.Office.Interop.Excel.Application);

            Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);


            try {
                excel = new Microsoft.Office.Interop.Excel.Application();
                wb = excel.Workbooks.Open("C:\\Program Files\\downtime\\Testlist.csv");
                excel.Visible = true;
                wb.Activate();

            } catch (Exception ex) {
                MessageBox.Show("Error accessing Excel: " + ex.ToString());



            }
        }
        if (response == MsgBoxResult.Yes) {
            return;
        }

    }
    public string getstring(byte[] value)
    {
        System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
        return enc.GetString(value);
    }
    static bool InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
    {
        if (flag.State == 0) {
            flag.State = 2;
            return true;
        } else if (flag.State == 2) {
            throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
        } else {
            return false;
        }
    }
}
    }

