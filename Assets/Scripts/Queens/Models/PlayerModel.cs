using System.Collections.Generic;

namespace Queens.Models
{
    public class PlayerModel
    {
        public Status status { get; set; }
        public List<string> active_collections { get; set; }
        public int career { get; set; }
    }
}