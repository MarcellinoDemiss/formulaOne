using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneWebServices.Models
{
    public class Driver
    {
        public int id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }
        public byte[] helmetImage { get; set; }
        public byte[] image { get; set; }
        public int teamID { get; set; }
        public int podiums { get; set; }
        public string countryCode { get; set; }
    }
}