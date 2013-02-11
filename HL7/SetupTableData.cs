﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using HL7;
using CodeBase2.MySql.URMC;
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

      public SetupTableData(GetMySQL getMySql, GetSqlServer getSqlServer, Hospital hospital)
      {
          wards = getMySql.FilledColumn("select Clinic_code from dtdb1.CLINIC");

          DISpecimenTranslation = getSqlServer.FilledDictionary("SELECT [type], [translation] FROM [downtime].[dbo].[diTranslation]").ToReadOnly();

          LabelersByIp = Send_IP_Printer.GetLabelersListOfIPs_byGroup(string.Format("/{0}/Specimen Management",Enum.GetName(typeof(Hospital),hospital))).ToReadOnly();
          
      }

    }
}