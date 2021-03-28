using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Driver
    {
        public Driver(int id, int number, string name, DateTime dob, byte[] helmetImage, byte[] image, int teamID, int podiums, string countryCode)
        {
            this.id = id;
            this.number = number;
            this.name = name;
            this.dob = dob;
            this.helmetImage = helmetImage;
            this.image = image;
            this.teamID = teamID;
            this.podiums = podiums;
            this.countryCode = countryCode;

        }

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