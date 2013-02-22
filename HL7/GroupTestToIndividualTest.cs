using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CodeBase2;

namespace HL7
{
   public class GroupTestToIndividualTest
    {
       readonly DataTable groupTestsTable;

        public GroupTestToIndividualTest(GetSqlServer getSqlServer)
        {
            groupTestsTable = getSqlServer.FilledTable("SELECT * FROM grouptest"); ;
        }

        /// <summary>
        /// break down all given tests into smallest components, make components unique. 
        /// Then remove those that have already been sent
        /// </summary>
        /// <param name="testCode"></param>
        /// <returns></returns>
        public IEnumerable<string> getUniqueUnsentIndividualTests(IEnumerable<Tuple2<string,bool>> testCodes)
        {
            //convert groupTests and Individual tests to only  individual Tests
            var tc = getIndividualTests(testCodes);
            //get all individual tests that have not already been sent.
            var tw = tc.Where(x => !tc.Any(a => (a._1 == x._1) && (a._2)))
                .Select(q=>q._1);
            // and make sure they are distinct
            return tw.Distinct();

        }

        /// <summary>
        /// break down all given tests into smallest components, make components unique.
        /// </summary>
        /// <param name="testCode"></param>
        /// <returns></returns>
        private IEnumerable<Tuple2<string, bool>> getIndividualTests(IEnumerable<Tuple2<string, bool>> testCodes)
        {
            //break down groupTests and Individual tests to only Individual tests
            return testCodes.SelectMany(getIndividualTests);
        }

        /// <summary>
        /// Break down all groups into individual tests.
        /// Given a group test, get all the individual tests.
        /// Given a Group Test in a group test, reduce just to indivudal tests.
        /// If the given test was not a grouptest, the given testCode will be returned in the collection, This means invalid testCodes will not be filtered.
        /// </summary>
        /// <param name="testCode"></param>
        /// <returns></returns>
        private IEnumerable<Tuple2<string, bool>> getIndividualTests(Tuple2<string, bool> testCode)
        {
            var rows = groupTestsTable.Select("GROUP_TEST_ID =" + quotequote(testCode._1));

            List<Tuple2<string, bool>> codes = new List<Tuple2<string, bool>>();

            foreach (DataRow row in rows)
            {
                int count = int.Parse(row.Field<String>("DIRECT_COMPONENTS"));
                String individualOrGroup = row.Field<String>("TEST_PREFIX");
                for (int x = 0; x < count; x++)
                {
                    String code = row.Field<String>("COMPONENT_CODE" + x);
                    var tupleCode = new Tuple2<string,bool>(code, testCode._2);
                    char type = individualOrGroup[x];
                    if (type == 'G')
                        codes.AddRange(getIndividualTests(tupleCode));
                    else // type == 'I'
                    {
                        codes.Add(tupleCode);
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
