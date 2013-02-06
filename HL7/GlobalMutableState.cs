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

    public static class RandomLetter {
    static Random ran = new Random();
        public static string get {
            get
            {
                string alphabet = "abcdefghijklmnopqrstuvwxyz";

                int length = ran.Next(0, 20);
                // get a random length

                return alphabet.Substring(ran.Next(0, 25), 1);
            }
        }
    }

}
