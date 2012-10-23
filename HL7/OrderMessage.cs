using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace HL7
{
   public enum Sex {
        M,
        F,
        U
    }

    public class OrderMessage
    {
        string mrn;
        string firstName;
        string lastName;
        string orderNumberWithSpecExtension;
        string dob;
        string sex;
        string ward;
        IEnumerable<string> testCodes;
        public OrderMessage(string mrn, string firstName, string lastName, string orderNumberWithSpecExtension, string dob, string ward, Sex sex, IEnumerable<string> testCodes) {
            this.mrn = mrn;
            this.firstName = firstName;
            this.lastName = lastName;
            this.orderNumberWithSpecExtension = orderNumberWithSpecExtension;
            this.testCodes = testCodes;
            this.ward = ward;
            this.dob = dob;
            if (sex == Sex.M) this.sex = "M";
            else if (sex == Sex.F) this.sex = "F";
            else if (sex == Sex.U) this.sex = "U";
        }
        
        private string MSH()
        {
            return "MSH|^~\\&|LAB|SCC||ROCHE|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "||OML^O01|64275384|P|2.3|||AL|NE||8859";
        }

        private string PID()
        {
            return "PID|||" + mrn + "||" + firstName + "^" + lastName + "||" + dob + "|" + sex + "||U";
        }

        private string PV1()
        {
            return "PV1|||" + ward;
        }

        private string SAC()
        {
            return "SAC|||" + orderNumberWithSpecExtension;
        }

        private string ORC()
        {
            return "ORC|XO|" + orderNumberWithSpecExtension + "|||||1^^^^^R^EVER";
        }

       

        public string toHl7() {
         var individualTestCodes = this.testCodes.SelectMany(code => GroupTestToIndividualTest.getIndividualTests(code));
            var index = 0;
            var testList = new List<String>();
            foreach (string code in individualTestCodes) {
                index = index + 1;
                var tco = new TestCodeForOrder(index.ToString(), code, orderNumberWithSpecExtension, "AMPT");
                testList.Add(tco.toHl7());
            }
            var segments = new List<String>(new String[] {MSH(),PID(),PV1(), SAC(),ORC()});
            segments.AddRange(testList);
            return Util.mkString(segments, "\r");
        }

/*
MSH|^~\&|LAB|SCC||ROCHE|20121023151125||OML^O01|64275384|P|2.3|||AL|NE||8859/1<cr>
PID|||000000963359||HIRALDO^ARACELIS||19750527|F||U<cr>
PV1|||AMHS<cr>
SAC|||A623543900<cr>
ORC|XO|A623543900|||||1^^^^^R^EVER<cr>
OBR|1|A623543900||^^^NA^SODIUM|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^NA^SODIUM||||||Y<cr>
OBR|2|A623543900||^^^K^POTASSIUM|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^K^POTASSIUM||||||Y<cr>
OBR|3|A623543900||^^^CL^CHLORIDE|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^CL^CHLORIDE||||||Y<cr>
OBR|4|A623543900||^^^CO2^CO2|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^CO2^CO2||||||Y<cr>
OBR|5|A623543900||^^^GAP^ANION GAP|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^GAP^ANION GAP||||||Y<cr>
OBR|6|A623543900||^^^UN^UREA NITROGEN|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^UN^UREA NITROGEN||||||Y<cr>
OBR|7|A623543900||^^^CREAT^CREATININE|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^CREAT^CREATININE||||||Y<cr>
OBR|8|A623543900||^^^GFRC^GFR,CAUCASIAN|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^GFRC^GFR,CAUCASIAN||||||Y<cr>
OBR|9|A623543900||^^^GFRB^GFR,BLACK|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^GFRB^GFR,BLACK||||||Y<cr>
OBR|10|A623543900||^^^GLU^GLUCOSE|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^GLU^GLUCOSE||||||Y<cr>
OBR|11|A623543900||^^^CA^CALCIUM|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^CA^CALCIUM||||||Y<cr>
OBR|12|A623543900||^^^TP^TOTAL PROTEIN|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^TP^TOTAL PROTEIN||||||Y<cr>
OBR|13|A623543900||^^^ALB^ALBUMIN|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^ALB^ALBUMIN||||||Y<cr>
OBR|14|A623543900||^^^GLOBC^GLOBULIN|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^GLOBC^GLOBULIN||||||Y<cr>
OBR|15|A623543900||^^^TB^T BILI|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^TB^T BILI||||||Y<cr>
OBR|16|A623543900||^^^AST^AST|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^AST^AST||||||Y<cr>
OBR|17|A623543900||^^^ALT^ALT|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^ALT^ALT||||||Y<cr>
OBR|18|A623543900||^^^ALK^ALK PHOS|||20121023000000||||A||||SER|||AMHS  <cr>
TCD|^^^ALK^ALK PHOS||||||Y<cr>
<fs>
*/
       

    }

   public class TestCodeForOrder {

        string orderNumberWithSpecExtension;
        string testCode;
        string testIndex;
        string testName = "";
        string ward;
        public TestCodeForOrder(string testIndex,string testCode, string orderNumberWithSpecExtension, string ward)
        {
            this.testIndex = testIndex;
            this.orderNumberWithSpecExtension = orderNumberWithSpecExtension;
            this.testCode = testCode;
            this.ward = ward;
        }

 

        private string OBR() {
            return "OBR|" + testIndex + "|" + orderNumberWithSpecExtension + "||^^^" + testCode + "^" + testName +
                "|||" + DateTime.Now.ToString("yyyyMMdd") + "000000||||A||||SER|||" + ward + "\r";
        }

        private string TCD() {
           return "TCD|^^^" + testCode + "^" + testName + "||||||Y";
        }

        public string toHl7() {
            return OBR() + TCD();
        }
    }

}
