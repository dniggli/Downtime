using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CodeBase2;

namespace HL7
{
   public static class GroupTestToIndividualTest
    {
       static DataTable groupTestsTable = new GetMySQL().FilledTable("SELECT * FROM grouptest");

        /// <summary>
        /// Break down all groups into individual tests.
        /// Given a group test, get all the individual tests.
        /// Given a Group Test in a group test, reduce just to indivudal tests.
        /// If the given test was not a grouptest, the given testCode will be returned in the collection, This means invalid testCodes will not be filtered.
        /// </summary>
        /// <param name="testCode"></param>
        /// <returns></returns>
        public static IEnumerable<String> getIndividualTests(String testCode)
        {
            var rows = groupTestsTable.Select("GROUP_TEST_ID =" + quotequote(testCode));

            List<String> codes = new List<String>();

            foreach (DataRow row in rows)
            {
                int count = int.Parse(row.Field<String>("DIRECT_COMPONENTS"));
                String individualOrGroup = row.Field<String>("TEST_PREFIX");
                for (int x = 0; x < count; x++)
                {
                    String code = row.Field<String>("COMPONENT_CODE" + x);
                    char type = individualOrGroup[x];
                    if (type == 'G')
                        codes.AddRange(getIndividualTests(code));
                    else // type == 'I'
                    {
                        codes.Add(code);
                    }
                }
            }
            return codes.DefaultIfEmpty(testCode);

        }

 
      
    
         private static String quote(String s)
         {
             return quotequote(s) + ", ";
         }

         private static String quote(int s)
         {
             return s + ", ";
         }

         private static String quotequote(String s)
         {
             return " '" + s + "' ";
         }

    }

}
