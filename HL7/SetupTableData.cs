using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using HL7;
using CodeBase2.Database;
//using CodeBase2.MySql.URMC;
namespace downtimeC
{
    /// <summary>
    /// Stores Setup Table Data, Wards etc. So they only need to be queried once
    /// </summary>
  public class SetupTableData
    {

      public readonly String[] wards;

      public readonly ReadOnlyDictionary<string, string> DISpecimenTranslation;

      public readonly ReadOnlyDictionary<string, string> LabelersByIp;

      public SetupTableData(GetSqlServer getSqlServer, Hospital hospital)
      {
          wards = getSqlServer.FilledColumn("select Clinic_code from [CLINIC]");

          DISpecimenTranslation = getSqlServer.FilledDictionary("SELECT [type], [translation] FROM [downtime].[dbo].[diTranslation]").ToReadOnly();

#if DEBUG
          var dr = new GetPathDirectory().Labels.GetLabelersListOfIPs_byGroup(string.Format("/{0}/Specimen Management", Enum.GetName(typeof(Hospital), hospital)));
          if (hospital == Hospital.Highland)
          {
              dr.Add("C42", "172.16.60.252");
          }
           LabelersByIp = dr.ToReadOnly();
#else
               LabelersByIp = new GetPathDirectory().Labels.GetLabelersListOfIPs_byGroup(string.Format("/{0}/Specimen Management", Enum.GetName(typeof(Hospital), hospital))).ToReadOnly();
#endif


      }

    }
}
