using System.Collections.Generic;

namespace Queens.ViewModels
{
    public class StatsViewModel
    {
        public int Flow { get; set; }
        public int Popularity { get; set; }
        public int Money { get; set; }
        public int Health { get; set; }
        
        public int Round { get; set; }
        
        public List<string> ActiveCollections { get; set; }
    }
}