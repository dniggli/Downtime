using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using System.Collections;
using CodeBase2.MySql.URMC;
using System.Windows.Forms;
using System.Linq;
namespace downtimeC
{

    public enum Hospital
    {
        Strong,
        Highland

    }

    public enum LabelPrintMode
    {
        Collection,
        Demographic,
        Comment,
        Aliquot
    }

    public enum HL7Destination
    {
        None,
        DI,
        MOLIS
    }


    public enum Priority
    {
        Stat,
        Routine,
        Urgent
    }

    public class LabelData
    {
        public StringBuilder strNecessary = new System.Text.StringBuilder("");


        readonly string orderNumber;
        readonly string ward;
        readonly string lastname;
        readonly string firstname;
        readonly string medreqnum;
     
        readonly string collectiontime = "Collected";
        readonly string todaysdate;

        readonly string priority;
        public LabelData(string _ordernumber, string _PRIORITY, string _medreqnum, string _lastname, string _firstname, string _ward, string _todaysdate)
        {
            orderNumber = _ordernumber;
            lastname = _lastname;
            firstname = _firstname;
            medreqnum = _medreqnum;
            priority = (_PRIORITY == "S") ? "STAT" : _PRIORITY;
            ward = _ward;
            todaysdate = _todaysdate;
        }

        public void AppendTestLabel(Priority priority, LabelPrintMode labelPrintMode, string test, string specimenType, string specimenExtension)
        {
            if (labelPrintMode == LabelPrintMode.Collection)
            {
                this.LabelAppendCollection(test, specimenType, specimenExtension);
            }
            else if (labelPrintMode == LabelPrintMode.Demographic)
            {
                this.LabelAppendDemographic(test, specimenType, specimenExtension);
            }
            else if (labelPrintMode == LabelPrintMode.Comment)
            {
                this.LabelAppendComment(test, specimenType, specimenExtension);
            }
            else if (labelPrintMode == LabelPrintMode.Aliquot)
            {
                if (priority == Priority.Routine)
                {
                    this.LabelAppendAliquotRoutine(test, specimenType, specimenExtension);
                }
                else if (priority == Priority.Stat)
                {
                    this.LabelAppendAliquotStat(test, specimenType, specimenExtension);
                }

            }
            else
            {
                throw new Exception("Unknown LabelPrintMode");
            }
        }

        /// <summary>
        /// THIS PRINTS COLLECTION LABLES FOR TUBES 
        /// </summary>
        /// <param name="ldata"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        internal void LabelAppendCollection(string content, string specimenType, string extension)
        {
            if (content == string.Empty)
                return;
            ArrayList sTemplatelines = new ArrayList();


            string label = null;

            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "-" + extension + "^FS" + Constants.vbNewLine;
            if (priority == "STAT" || priority == "U")
            {
                label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            }
            label += "^FO260, 13,^A0,28         ^FR^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + ward + "^FS" + Constants.vbNewLine;
            if (content.Length > 37)
            {
                label += "^FO  0, 92,^AB            ^FD" + content.Substring(0, 37) + "^FS" + Constants.vbNewLine;

            }
            else
            {
                label += "^FO  0, 92,^AB            ^FD" + content + "^FS" + Constants.vbNewLine;
            }
            label += "^FO  0,107,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            if (content.Length > 74)
            {
                label += "^FO  0, 112,^AB            ^FD" + content.Substring(37, 34) + "...^FS" + Constants.vbNewLine;

            }
            else if (content.Length > 37)
            {
                label += "^FO  0, 112,^AB            ^FD" + content.Substring(37) + "^FS" + Constants.vbNewLine;



            }
            label += "^FO365,100,^A0,40         ^FD*" + specimenType + "*^FS" + Constants.vbNewLine;
            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FO0025,137,^BC,,N,,,A,^FD" + orderNumber + extension + "^FS" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;






            strNecessary.Append(label);


        }


        /// <summary>
        /// THIS PRINTS COMMENT LABLES
        /// </summary>
        /// <param name="ldata1"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        internal void LabelAppendComment(string content, string specimenType, string extension)
        {
            if (content == string.Empty)
                return;

            string label = null;

            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "" + extension + "^FS" + Constants.vbNewLine;
            if (priority == "STAT" || priority == "U")
            {
                label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            }
            label += "^FO260, 13,^A0,28,^FR     ^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + ward + "^FS" + Constants.vbNewLine;
            label += "^FO  0, 92,^AB            ^FD" + content + "^FS" + Constants.vbNewLine;
            label += "^FO  0,107,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO365,100,^A0,40         ^FD*" + specimenType + "*^FS" + Constants.vbNewLine;
            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;





            strNecessary.Append(label);



        }

        /// <summary>
        /// THIS PRINTS DEMOGRAPHIC LABLES FOR REQS
        /// </summary>
        /// <param name="ldata2"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        internal void LabelAppendDemographic(string testlist, string specimenType, string extension)
        {
            if (testlist == string.Empty)
                return;

            string label = null;


            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "" + extension + "^FS" + Constants.vbNewLine;
            if (priority == "STAT" || priority == "U")
            {
                label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            }
            label += "^FO260, 13,^A0,28,^FR     ^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + ward + "^FS" + Constants.vbNewLine;
            label += "^FO  0, 92,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,107,^A0,22,20      ^FD" + collectiontime + " @ " + testlist + " On " + todaysdate + "  ^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO365,100,^A0,40         ^FD*" + specimenType + "*^FS" + Constants.vbNewLine;
            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FO0025,137,^B3,N,72,N,^FD" + orderNumber + extension + "^FS" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;
            strNecessary.Append(label);
        }

        /// <summary>
        /// Prints STAT Aliquot Collection Labels for Tubes(For Aliquotform only)
        /// </summary>
        /// <param name="ldata"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        internal void LabelAppendAliquotStat(string testlist, string specimenType, string extension)
        {
            if (testlist == string.Empty)
                return;

            string label = null;


            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "-" + extension + "^FS" + Constants.vbNewLine;
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            label += "^FO260, 13,^A0,28         ^FR^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + ward + "^FS" + Constants.vbNewLine;
            if (testlist.Length > 37)
            {
                label += "^FO  0, 92,^AB            ^FD" + testlist.Substring(0, 37) + "^FS" + Constants.vbNewLine;

            }
            else
            {
                label += "^FO  0, 92,^AB            ^FD" + testlist + "^FS" + Constants.vbNewLine;
            }
            label += "^FO  0,107,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            if (testlist.Length > 74)
            {
                label += "^FO  0, 112,^AB            ^FD" + testlist.Substring(37, 34) + "...^FS" + Constants.vbNewLine;

            }
            else if (testlist.Length > 37)
            {
                label += "^FO  0, 112,^AB            ^FD" + testlist.Substring(37) + "^FS" + Constants.vbNewLine;



            }
            label += "^FO365,60,^A0B,,22,20    ^FD*" + orderNumber + "*^FS" + Constants.vbNewLine;
            label += "^FO390,40,^A0B,,17,15    ^FD*" + lastname + "," + firstname + "*^FS" + Constants.vbNewLine;

            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FO0025,137,^BC,,N,,,A,^FD" + orderNumber + extension + "^FS" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^BY1,2" + Constants.vbNewLine;
            label += "^FO420,40,^BCB,,N,       ^FD" + orderNumber + "^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;


            strNecessary.Append(label);
        }

        /// <summary>
        /// Print ROUTINE Aliquot Collection Labels for Tubes (For Aliquotform only)
        /// </summary>
        /// <param name="ldata"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        internal void LabelAppendAliquotRoutine(string testlist, string specimenType, string extension)
        {
            if (testlist == string.Empty)
                return;

            string label = null;


            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "-" + extension + "^FS" + Constants.vbNewLine;
            label += "^FO260, 13,^A0,28         ^FR^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + ward + "^FS" + Constants.vbNewLine;
            if (testlist.Length > 37)
            {
                label += "^FO  0, 92,^AB            ^FD" + testlist.Substring(0, 37) + "^FS" + Constants.vbNewLine;

            }
            else
            {
                label += "^FO  0, 92,^AB            ^FD" + testlist + "^FS" + Constants.vbNewLine;
            }
            label += "^FO  0,107,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            if (testlist.Length > 74)
            {
                label += "^FO  0, 112,^AB            ^FD" + testlist.Substring(37, 34) + "...^FS" + Constants.vbNewLine;

            }
            else if (testlist.Length > 37)
            {
                label += "^FO  0, 112,^AB            ^FD" + testlist.Substring(37) + "^FS" + Constants.vbNewLine;



            }

            label += "^FO365,60,^A0B,,22,20    ^FD*" + orderNumber + "*^FS" + Constants.vbNewLine;
            label += "^FO390,40,^A0B,,17,15    ^FD*" + lastname + "," + firstname + "*^FS" + Constants.vbNewLine;

            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FO0025,137,^BC,,N,,,A,^FD" + orderNumber + extension + "^FS" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;

            label += "^BY1,2" + Constants.vbNewLine;
            label += "^FO420,40,^BCB,,N,       ^FD" + orderNumber + "^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;




            strNecessary.Append(label);


        }

        public void doPrint(string printer, SetupTableData setupTableData)
        {           
            string PrinterDNSName = setupTableData.LabelersByIp[printer.ToUpper()].ToString();
            if (!PrinterDNSName.Contains("."))
            {
                printer = CodeBase2.DNS.NameToIPString(PrinterDNSName);
                Send_IP_Printer.PrintLabel(printer, strNecessary.ToString());
            }
            else
            {
                Send_IP_Printer.PrintLabel(setupTableData.LabelersByIp[printer.ToUpper()], strNecessary.ToString());
            }
        }
    }
}
