using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace downtimeC
{
    public interface IStoredControl
    {
        string DataColumnName
        {
            get;
            set;
        }

        void setValue(string value);
    }
}