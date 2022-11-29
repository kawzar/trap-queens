using System;

namespace Queens.Models
{
    [Serializable]
    public class CardModel
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string bearer{ get; set; }
        public string collection{ get; set; }
        public string dialog{ get; set; }
        public int yes_flow{ get; set; }
        public int yes_popularity{ get; set; }
        public int yes_money{ get; set; }
        public int yes_health{ get; set; }
        public int no_flow{ get; set; }
        public int no_popularity{ get; set; }
        public int no_money{ get; set; }
        public int no_health{ get; set; }
        public int level_lock{ get; set; }
    }
}