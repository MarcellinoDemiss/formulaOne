using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Country
    {
        public Country(string isoCode, string decr)
        {
            countryCode = isoCode;
            countryName = decr;
        }
        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
}
