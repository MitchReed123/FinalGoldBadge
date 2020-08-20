using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge
{
    public class Badge
    {
        public Badge()
        {

        }
        public Badge(int badgeId, List<string> doorNames, string badgeName)
        {
            BadgeID = badgeId;
            DoorName = doorNames;
            BadgeName = badgeName;
        }

        public int BadgeID { get; }
        //public string DoorNames { get; set; }
        public string BadgeName { get; set; }
        public List<string> DoorName { get; set; }
    
    }
}
