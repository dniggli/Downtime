using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunctionalCSharp;

namespace downtimeC
{
    interface IOption
    {
        Option<string> TextOption  {   get;  }


        string ValidationPrompt
        {
            get;
            set;
        }

        /// <summary>
        /// Determine if the Control is properly filled out.  And prompt the user if not
        /// </summary>
        /// <returns></returns>
        bool Validate();


        bool Required
        {
            get;
            set;
        }
    }
}
