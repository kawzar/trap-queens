using System;

namespace Queens.Models
{
    [Serializable]
    public class Card 
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string bearer{ get; set; }
        public string collection{ get; set; }
        public string dialog{ get; set; }
        public string yes_answer{ get; set; }
        public string no_answer{ get; set; }
        public float? yes_flow{ get; set; }
        public float? yes_popularity{ get; set; }
        public float? yes_money{ get; set; }
        public float? yes_health{ get; set; }
        public float? no_flow{ get; set; }
        public float? no_popularity{ get; set; }
        public float? no_money{ get; set; }
        public float? no_health{ get; set; }
        public int? level_lock{ get; set; }
    }
}