using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class DriverDetailsDTO
    {
        public DriverDetailsDTO(int number, string name, byte[] image, string teamName, string countryCode, int podiums, DateTime dob)
        {
            this.number = number;
            this.name = name;
            this.image = image;
            this.teamName = teamName;
            this.countryCode = countryCode;
            this.podiums = podiums;
            this.dob = dob;
        }

        public int number { get; set; }
        public string name { get; set; }
        public byte[] image { get; set; }
        public string teamName { get; set; }
        public string countryCode { get; set; }
        public int podiums { get; set; }
        public DateTime dob { get; set; }
        public string countryFlag
        {
            get
            {
                return String.Format("https://www.countryflags.io/{0}/flat/64.png", countryCode.ToLower());
            }
        }
    }
}