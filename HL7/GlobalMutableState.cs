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
                return "abcdefghijklmnopqrstuvwxyz".Substring(ran.Next(0, 25), 1);
            }
        }

        public static string numeric
        {
            get
            {
                return "0123456789".Substring(ran.Next(0, 10), 1);
            }
        }
    }

    public static class RandomString {
        public static string get(int length) {
        
                string ranstring = "";
                for (int x = 0; x <= length; x++)
                {
                    ranstring += RandomLetter.get;
                }
                return ranstring;
        }

        public static string numeric(int length)
        {

            string ranstring = "";
            for (int x = 0; x <= length; x++)
            {
                ranstring += RandomLetter.numeric;
            }
            return ranstring;
        }
    }

           

}
