using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class TeamPageDTO
    {
        public TeamPageDTO(string tName, byte[] tLogo, string[] dNames, List<byte[]> dImages, byte[] tImage)
        {
            this.TeamName = tName;
            this.TeamLogo = tLogo;
            this.driversName = dNames;
            this.driversImage = dImages;
            this.carImage = tImage;
        }

        public string TeamName { get; set; }
        public byte[] TeamLogo { get; set; }
        public string[] driversName { get; set; }
        public List<byte[]> driversImage { get; set; }
        public byte[] carImage { get; set; }
    }
}