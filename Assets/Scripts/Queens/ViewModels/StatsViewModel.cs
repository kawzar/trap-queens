using System.Collections.Generic;
using Queens.Models;

namespace Queens.ViewModels
{
    public class StatsViewModel
    {
        public int Flow { get; set; }
        public int Popularity { get; set; }
        public int Money { get; set; }
        public int Health { get; set; }

        public StatsViewModel()
        {
        }

        public StatsViewModel(Status model)
        {
            Flow = model.flow;
            Popularity = model.popularity;
            Money = model.money;
            Health = model.health;
        }
    }
}