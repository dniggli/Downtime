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

namespace downtimeC.LabelPrinting
{

    public class LabelData
    {
        public string orderNumber;
        public string location;
        public string lastname;
        public string firstname;
        public string medreqnum;
        public string testlist;
        public string extension;
        public string specimenType;
        public string collectiontime;
        public string todaysdate;

        public string priority;
        public LabelData(string _ordernumber, string _tests, string _extension, string _specimentype, string _PRIORITY, string _medreqnum, string _lastname, string _firstname, string _location, string _collectiontime,
        string _todaysdate)
        {
            orderNumber = _ordernumber;
            lastname = _lastname;
            firstname = _firstname;
            medreqnum = _medreqnum;
            extension = _extension;
            specimenType = _specimentype;
            priority = _PRIORITY;
            location = _location;
            collectiontime = _collectiontime;
            todaysdate = _todaysdate;
            testlist = _tests;



        }

        public LabelData(string _ordernumber, string _tests, string _extension, string _specimentype, string _PRIORITY, string _medreqnum, string _lastname, string _firstname, string _location)
        {
            orderNumber = _ordernumber;
            extension = _extension;
            specimenType = _specimentype;
            priority = _PRIORITY;
            testlist = _tests;
            medreqnum = _medreqnum;
            lastname = _lastname;
            firstname = _firstname;
            location = _location;
        }

        public LabelData(string _ordernumber, string _PRIORITY, string _medreqnum, string _lastname, string _firstname, string _location)
        {
            orderNumber = _ordernumber;
            extension = "";
            specimenType = "";
            priority = _PRIORITY;
            testlist = "";
            medreqnum = _medreqnum;
            lastname = _lastname;
            firstname = _firstname;
            location = _location;
        }

        /// <summary>
        /// THIS PRINTS COLLECTION LABLES FOR TUBES 
        /// </summary>
        /// <param name="ldata"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        public void LabelPrint(string printer)
        {
            if (testlist == string.Empty)
                return;
            ArrayList sTemplatelines = new ArrayList();


            string label = null;

            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "-" + extension + "^FS" + Constants.vbNewLine;
            if (priority == "STAT")
            {
                label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            }
            label += "^FO260, 13,^A0,28         ^FR^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + location + "^FS" + Constants.vbNewLine;
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
            label += "^FO365,100,^A0,40         ^FD*" + specimenType + "*^FS" + Constants.vbNewLine;
            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FO0025,137,^BC,,N,,,A,^FD" + orderNumber + extension + "^FS" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;






            OrderEntryForm.strNecessary.Append(label);


        }


        /// <summary>
        /// THIS PRINTS COMMENT LABLES
        /// </summary>
        /// <param name="ldata1"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        public void LabelPrint1(string printer)
        {
            if (testlist == string.Empty)
                return;
            ArrayList sTemplatelines = new ArrayList();


            string label = null;

            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "" + extension + "^FS" + Constants.vbNewLine;
            if (priority == "STAT")
            {
                label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            }
            label += "^FO260, 13,^A0,28,^FR     ^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + location + "^FS" + Constants.vbNewLine;
            label += "^FO  0, 92,^AB            ^FD" + testlist + "^FS" + Constants.vbNewLine;
            label += "^FO  0,107,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO365,100,^A0,40         ^FD*" + specimenType + "*^FS" + Constants.vbNewLine;
            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;





            OrderEntryForm.strNecessary.Append(label);



        }

        /// <summary>
        /// THIS PRINTS DEMOGRAPHIC LABLES FOR REQS
        /// </summary>
        /// <param name="ldata2"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        public void LabelPrint2(string printer)
        {
            if (testlist == string.Empty)
                return;

            ArrayList sTemplatelines = new ArrayList();


            string label = null;


            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "" + extension + "^FS" + Constants.vbNewLine;
            if (priority == "STAT")
            {
                label += "^FO260, 3                 ^GB 60, 13,35,,100^FS";
            }
            label += "^FO260, 13,^A0,28,^FR     ^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + location + "^FS" + Constants.vbNewLine;
            label += "^FO  0, 92,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO  0,107,^A0,22,20      ^FD" + collectiontime + " @ " + testlist + " On " + todaysdate + "  ^FS" + Constants.vbNewLine;
            label += "^FO  0,122,^AB            ^FD^FS" + Constants.vbNewLine;
            label += "^FO365,100,^A0,40         ^FD*" + specimenType + "*^FS" + Constants.vbNewLine;
            label += Constants.vbNewLine;
            label += "^BY2,2,80" + Constants.vbNewLine;
            label += "^FO0025,137,^B3,N,72,N,^FD" + orderNumber + extension + "^FS" + Constants.vbNewLine;
            label += "^FT370,160,^AD             ^FD^FS" + Constants.vbNewLine;
            label += "^XZ" + Constants.vbNewLine;
            OrderEntryForm.strNecessary.Append(label);
        }

        /// <summary>
        /// Prints STAT Aliquot Collection Labels for Tubes(For Aliquotform only)
        /// </summary>
        /// <param name="ldata"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        public void LabelPrintal1(string printer)
        {
            if (testlist == string.Empty)
                return;
            ArrayList sTemplatelines = new ArrayList();


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
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + location + "^FS" + Constants.vbNewLine;
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


            OrderEntryForm.strNecessary.Append(label);
        }

        /// <summary>
        /// Print ROUTINE Aliquot Collection Labels for Tubes (For Aliquotform only)
        /// </summary>
        /// <param name="ldata"></param>
        /// <param name="printer"></param>
        /// <remarks></remarks>
        public void LabelPrintal2(string printer)
        {
            if (testlist == string.Empty)
                return;
            ArrayList sTemplatelines = new ArrayList();


            string label = null;


            label = "^XA" + Constants.vbNewLine;
            label += "^FX COLLECTION LABEL ^FS" + Constants.vbNewLine;
            label += "^FO  0, 15,^A0B,29        ^FD" + orderNumber.Substring(4) + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 13,^A0,29         ^FD" + orderNumber + "-" + extension + "^FS" + Constants.vbNewLine;
            label += "^FO260, 13,^A0,28         ^FR^FD" + priority + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 42,^A0,28,25      ^FD" + lastname + "," + firstname + "^FS" + Constants.vbNewLine;
            label += "^FO 30, 75,^AB            ^FDM#^FS" + Constants.vbNewLine;
            label += "^FO 55, 70,^A0,22,20      ^FD" + medreqnum + "^FS" + Constants.vbNewLine;
            label += "^FO200, 70,^A0,22,20      ^FD*" + specimenType + "*/" + location + "^FS" + Constants.vbNewLine;
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




            OrderEntryForm.strNecessary.Append(label);


        }


        public LabelData setTestsExtensionSpecimenType(string tests, string extension, string st)
        {
            return new LabelData(orderNumber, tests, extension, st, priority, medreqnum, lastname, firstname, location, collectiontime,
            todaysdate);
        }





    }
}
