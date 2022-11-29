using System;

namespace Queens.Models
{
    [Serializable]
    public class Status
    {
        public int flow { get; set; }
        public int popularity { get; set; }
        public int health { get; set; }
        public int money { get; set; }
    }
}
