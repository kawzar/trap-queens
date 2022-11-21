using System;

namespace Queens.Models
{
    [Serializable]
    public class Status
    {
        public float flow { get; set; }
        public float popularity { get; set; }
        public float health { get; set; }
        public float money { get; set; }
    }
}
