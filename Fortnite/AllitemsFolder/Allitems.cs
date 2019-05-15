using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortnite.AllitemsFolder {
    class Allitems {
        public string identifier { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public int upcoming { get; set; }
        public Images images { get; set; }
        public string obtained { get; set; }
        public string obtained_type { get; set; }
        public Ratings ratings { get; set; }
        public string lastupdate { get; set; }
    }

    public class Featured {
        public string transparent { get; set; }
    }

    public class Images {
        public string transparent { get; set; }
        public Featured featured { get; set; }
        public string background { get; set; }
        public string info { get; set; }
    }

    public class Ratings {
        public double avgStars { get; set; }
        public int totalPoints { get; set; }
        public int numberVotes { get; set; }
    }
}
