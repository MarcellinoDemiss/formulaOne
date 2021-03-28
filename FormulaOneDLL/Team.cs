using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Team
    {
        public Team(int id, string teamName, byte[] teamLogo, string baseT, string teamChief, string technicalChief, string powerUnit, byte[] carImage, string countryID, int worldChampionships, int polePositions)
        {
            this.id = id;
            this.teamName = teamName;
            this.teamLogo = teamLogo;
            this.baseT = baseT;
            this.teamChief = teamChief;
            this.technicalChief = technicalChief;
            this.powerUnit = powerUnit;
            this.carImage = carImage;
            this.countryID = countryID;
            this.worldChampionships = worldChampionships;
            this.polePositions = polePositions;

        }

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