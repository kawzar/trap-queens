using System.Collections.Generic;
using Queens.Models;

namespace Queens.ViewModels
{
    public class PlayerViewModel
    {
        public StatsViewModel Stats { get; set; }
        public int Career { get; set; }
        public List<string> ActiveCollections { get; set; }

        public PlayerViewModel(PlayerModel model)
        {
            Stats = new StatsViewModel(model.status);
            Career = model.career;
            ActiveCollections = model.active_collections;
            Name = model.name;
        }
        
        public string Name { get; set; }
    }
}