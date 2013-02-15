using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunctionalCSharp;
namespace HL7
{
    public struct SpecimenType
    {
       public String extension;
       public String diSpecimenType;
    }

  //public class SpecimenType {
  //public readonly String extension;
  //  public readonly String softName;
  //  /// <summary>
  //  /// From AAOUT interface translation table in Soft
  //  /// </summary>
  //  /// <remarks></remarks>
  //  public readonly Option<String> diName;

  //  public SpecimenType(String extension, String softName, Option<String> diName)
  //  {
  //      this.extension = extension;
  //      this.softName = softName;
  //      this.diName = diName;
  //      }

  //        private static Option<string> Some(String s) {
  //            return Option.Some(s);
  //        }
  //     private static readonly Option<string> None = Option.None<string>();

  //    public static SpecimenType Comment =  new SpecimenType("", "CMT", None);
  //    public static SpecimenType Red = new SpecimenType("00", "SST", Some("SER"));
  //      public static SpecimenType Blue = new SpecimenType("23", "BLU", None);
  //      public static SpecimenType Green = new SpecimenType("40", "GRN", Some("SER"));
  //      public static SpecimenType LavChem = new SpecimenType("79", "LAV", Some("WB"));
  //      public static SpecimenType LavHem = new SpecimenType("18", "LAV", Some("WB"));
  //      public static SpecimenType Gray = new SpecimenType("19", "GRY", None);
  //      public static SpecimenType UrineChem = new SpecimenType("27", "URC", Some("UR"));
  //      public static SpecimenType UrineHem = new SpecimenType("UA", "UAC", None);
  //      public static SpecimenType BloodGas = new SpecimenType("20", "SYR", None);
  //      public static SpecimenType SendOut = new SpecimenType("05", "REF", None);
  //      public static SpecimenType Ser = new SpecimenType("41", "SRL", None);
  //      public static SpecimenType Hepp = new SpecimenType("42", "SHP", None);
  //      public static SpecimenType Csf = new SpecimenType("26", "CSF", Some("CSF"));
  //      public static SpecimenType Fluid = new SpecimenType("38", "FLD", Some("FL"));
  //      public static SpecimenType Viral = new SpecimenType("74", "LAV", Some("WB"));
  //      public static SpecimenType Other = new SpecimenType("", "OTH", None);
  //      public static SpecimenType Immuno = new SpecimenType("2R", "SST", Some("SER"));
  //  }

}
