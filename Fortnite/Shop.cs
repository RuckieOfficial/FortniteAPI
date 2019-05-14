using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortnite {
    public class Shop {
        public string vbucks { get; set; }
        public string date_layout { get; set; }
        public string date { get; set; }
        public int lastupdate { get; set; }
        public string language { get; set; }
        public int rows { get; set; }
        public List<Item> items { get; set; }
    }

    public class Featured {
        public string transparent { get; set; }
    }

    public class Images {
        public string transparent { get; set; }
        public string background { get; set; }
        public string information { get; set; }
        public Featured featured { get; set; }
    }

    public class Item2 {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Images images { get; set; }
        public string captial { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public string obtained_type { get; set; }
    }

    public class Ratings {
        public double avgStars { get; set; }
        public int totalPoints { get; set; }
        public int numberVotes { get; set; }
    }

    public class Item {
        public string itemid { get; set; }
        public string name { get; set; }
        public string cost { get; set; }
        public int featured { get; set; }
        public int refundable { get; set; }
        public int lastupdate { get; set; }
        public Item2 item { get; set; }
        public Ratings ratings { get; set; }
    }
}
