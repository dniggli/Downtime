using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FunctionalCSharp;

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
        string dob;
        string sex;
        string ward;
        string messageUniqueIDForAck;
        Dictionary<SpecimenType, IEnumerable<string>> testCodeUniqueIndividual;
        string orderNumber;
        public OrderMessage(string mrn, string firstName, string lastName, string orderNumber,
            string dob, string ward, Sex sex, string messageUniqueIDForAck, Dictionary<SpecimenType, IEnumerable<string>> testCodeUniqueIndividual)
        {
            this.mrn = mrn;
            this.firstName = firstName;
            this.lastName = lastName;
            this.testCodeUniqueIndividual = testCodeUniqueIndividual;
            this.ward = ward;
            this.dob = dob;
            this.orderNumber = orderNumber;
            this.messageUniqueIDForAck = messageUniqueIDForAck;
            if (sex == Sex.M) this.sex = "M";
            else if (sex == Sex.F) this.sex = "F";
            else if (sex == Sex.U) this.sex = "U";
        }

        public OrderMessage(string mrn, string firstName, string lastName, string orderNumber,
            string dob, string ward, Sex sex, Dictionary<SpecimenType, IEnumerable<string>> testCodeUniqueIndividual)
            : this(mrn, firstName, lastName, orderNumber, dob, ward, sex, "00000000", testCodeUniqueIndividual) { }
        
        
        
        private string MSH()
        {
            return "MSH|^~\\&|LAB|SCC||ROCHE|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "||OML^O01|" + messageUniqueIDForAck + "|P|2.3|||AL|NE||8859";
        }

        private string PID()
        {
            return "PID|||" + mrn + "||" + firstName + "^" + lastName + "||" + dob + "|" + sex + "||U";
        }

        private string PV1()
        {
            return "PV1|||" + ward;
        }

        private string orderNumberWithSpecExtension(string extension)
        {
            return orderNumber + extension;
        }

        private string SAC(string extension)
        {
            return "SAC|||" + orderNumberWithSpecExtension(extension);
        }

        private string ORC(string extension)
        {
            return "ORC|XO|" + orderNumberWithSpecExtension(extension) + "|||||1^^^^^R^EVER";
            
        }


        /// <summary>
        /// Returns multiple HL7 messages, one for each specimenType. To be sent to the instrument.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> toHl7()
        {
           // var individualTestCodes = this.testCodes.SelectMany(code => groupTestToIndividualTest.getIndividualTests(code));

           return testCodeUniqueIndividual.Keys.Select(specimenType =>
            {
                var tests = testCodeUniqueIndividual[specimenType];

                var index = 0;

                var testsHL7 = tests.Select(code =>
               {
                   index = index + 1;
                   return new TestCodeForOrder(index.ToString(), code,
                       orderNumberWithSpecExtension(specimenType.extension), ward, specimenType)
                        .toHl7();
               });

                var segments = new List<String>(
                    new String[] { MSH(), PID(), PV1(), SAC(specimenType.extension),
                        ORC(specimenType.extension) });
                segments.AddRange(testsHL7);
                return testsHL7.Count() > 0 ? segments.mkString("\r") : "";
            }).Where(x => x != "");
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
        string testIndex;
        string testName = "";
        string ward;
        string testCode;
        string diSpecimenType;
        SpecimenType specimenType;
        public TestCodeForOrder(string testIndex, string testCode, string orderNumberWithSpecExtension, string ward, SpecimenType SpecimenType)
        {
            this.testIndex = testIndex;
            this.orderNumberWithSpecExtension = orderNumberWithSpecExtension;
            this.testCode = testCode;
            this.ward = ward;
            this.diSpecimenType = specimenType.diSpecimenType;
        }

 

        private string OBR() {
            return "OBR|" + testIndex + "|" + orderNumberWithSpecExtension + "||^^^" + testCode + "^" + testName +
                  "|||" + DateTime.Now.ToString("yyyyMMdd") + "000000||||A||||" + diSpecimenType + "|||" + ward + "\r";
        }

        private string TCD() {
           return "TCD|^^^" + testCode + "^" + testName + "||||||Y";
        }

        public string toHl7() {
            return OBR() + TCD();
        }
    }

}
