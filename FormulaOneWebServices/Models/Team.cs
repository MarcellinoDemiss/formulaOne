using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneWebServices.Models
{
    public class Team
    {
        public int id { get; set; }
        public string teamName { get; set; }
        public byte[] teamLogo { get; set; }
        public string baseT { get; set; }
        public string teamChief { get; set; }
        public string technicalChief { get; set; }
        public string powerUnit { get; set; }
        public byte[] carImage { get; set; }
        public string countryID { get; set; }
        public int worldChampionships { get; set; }
        public int polePositions { get; set; }
    }
}