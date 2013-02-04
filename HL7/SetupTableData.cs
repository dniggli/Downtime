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
    /// <summary>
    /// Stores Setup Table Data, Wards etc. So they only need to be queried once
    /// </summary>
  public class SetupTableData
    {

      public readonly String[] wards;

      public readonly Dictionary<string,string> DISpecimenTranslation;

      public SetupTableData(GetMySQL getMySql, GetSqlServer getSqlServer)
      {
          wards = getMySql.FilledColumn("select Clinic_code from dtdb1.CLINIC");

          DISpecimenTranslation = getSqlServer.FilledDictionary("SELECT [type], [translation] FROM [downtime].[dbo].[diTranslation]");
      }

    }
}
