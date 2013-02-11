using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using CodeBase2.Database;

namespace HL7
{
  public class GetSqlServer : baseSql
    {
        public override System.Data.SqlClient.SqlConnection GetConnection
        {
            get { return new System.Data.SqlClient.SqlConnection(
                "Server=sqllisdw2;Database=downtime;User Id=downtimeUser;Password=uptime;"); }
        }
    }
}
