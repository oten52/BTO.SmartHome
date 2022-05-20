using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.ComonComon.Extentions
{
    public static class  StringExtentions
    {
        // IsNullOrEmpty - Boş Olup olmadığını Döner
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }



    }
}
