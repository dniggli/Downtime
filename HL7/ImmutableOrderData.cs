using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using HL7;

namespace downtimeC
{
   public class ImmutableOrderData
        {
            public readonly string orderNumber; public readonly string collectionTime;
            public readonly string receiveTime; public readonly string ward;
            public readonly string priority; public readonly string mrn;
            public readonly string dob; public readonly string firstName;
            public readonly string problem; public readonly string calls;
            public readonly string comment; public readonly string lastName;
          public readonly string techId;
          public readonly string billingNumber; public readonly ReadOnlyDictionary<string, bool> tests;

            public ImmutableOrderData(string orderNumber, string collectionTime, string receiveTime,
            string ward, string priority, string mrn, string dob,
            string firstName, string problem, string calls, string comment,
            string lastName, string techId, string billingNumber,
            ReadOnlyDictionary<string, bool> tests)
            {
                this.billingNumber = billingNumber; this.calls = calls; this.collectionTime = collectionTime;
                this.comment = comment; this.dob = dob; this.firstName = firstName;
                this.lastName = lastName; this.mrn = mrn; this.orderNumber = orderNumber;
                this.priority = priority; this.problem = problem; this.receiveTime = receiveTime;
                this.techId = techId; this.tests = tests; this.ward = ward;
            }

            public Priority getPriority
            {
                get
                {
                    if (priority == "R")
                    {
                        return Priority.Routine;
                    }
                    else if (priority == "S")
                    {
                        return Priority.Stat;
                    }
                    else if (priority == "U")
                    {
                        return Priority.Urgent;
                    }
                    else
                    {
                        throw new NotImplementedException("Unknown priority");
                    }
                }
            }

        
                    /// <summary>
            /// update the order with the ordered tests and patient info
            /// </summary>
            public void updateOrder(GetSqlServer getSqlServer)
            {
              
              var testRows = tests.Select(x => "SELECT '" + x.Key + "', '"  + ((x.Value) ? "1" : "0") + "', '" + orderNumber + "'")
                             .mkString(" UNION ALL ");

                getSqlServer.ExecuteNonQuery(String.Format(@"INSERT INTO [ordered] ([ordernumber]
  ,[collectiontime], [receivetime], [ward], [priority], [mrn], [dob], [FIRSTNAME],[PROBLEM],[CALLS]
  ,[ORDERCOMMENT],[LASTNAME],[TRACKING],[TRACKINGCOMMENT],[TECHID],[BILLINGNUMBER])
 VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',
 '{10}','{11}','{12}','{13}','{14}','{15}'); " +

"Insert INTO [testOnOrder] (test,hl7Sent,ordernumber) " + testRows, orderNumber, collectionTime, receiveTime, ward, priority,
mrn, dob, firstName, problem, calls, comment, lastName, "", "", techId, billingNumber));
                                                   
            }
        }
    }


