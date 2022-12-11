using System.Collections.Generic;
using Queens.Models;
using UniRx;

namespace Queens.ViewModels
{
    public class PlayerViewModel
    {
        public StatsViewModel Stats { get; set; }
        public IntReactiveProperty Career { get; set; }
        public List<string> ActiveCollections { get; set; }

        public PlayerViewModel(PlayerModel model)
        {
            Stats = new StatsViewModel(model.status);
            Career = new IntReactiveProperty(model.career);
            ActiveCollections = model.active_collections ?? new List<string>();
            Name = model.name;
        }
        
        public string Name { get; set; }
    }
}