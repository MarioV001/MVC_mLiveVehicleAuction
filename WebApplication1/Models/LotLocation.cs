using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace mVehAuction.Models
{
    public class LotLocation
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public string LocationName { get; set; } = "";
        public float MapX { get; set; } 
        public float MapY { get; set; }
        public string MapLocation { get; set; } = "";
        public TimeSpan StartTimeOfLot { get; set; }
        public int LotPhoneNum { get; set; }
        public string GeneralManager { get; set; } = "";

    }
}
