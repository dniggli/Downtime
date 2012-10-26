using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7
{
    static class Util
    {
        public static String mkString(List<String> strings, String delimit)
        {
            return mkString(strings, "", "", delimit);
        }

        public static String mkString(List<String> strings, String prepend,
                String append, String delimit)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(prepend);
            foreach (String item in strings)
            {
                builder.Append(item);
                builder.Append(delimit);
            }
            builder.Append(append);
            return builder.ToString();
        }
    }
}
