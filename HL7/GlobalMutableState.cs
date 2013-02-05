using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;

namespace downtimeC
{
   public static class GlobalMutableState
    {
       public static string userName = "";
       public static DateTime StartupDate;
    }
}
