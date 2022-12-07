using System.Collections.Generic;
using Queens.Global.Constants;
using Queens.Models;
using UnityEngine;

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

        public bool AreStatsValid()
        {
            return Flow is > PlayerConstants.MIN_FLOW and < PlayerConstants.MAX_FLOW 
                   && Popularity is > PlayerConstants.MIN_POPULARITY and < PlayerConstants.MAX_POPULARITY 
                   && Health > PlayerConstants.MIN_HEALTH 
                   && Money is > PlayerConstants.MIN_MONEY and < PlayerConstants.MAX_MONEY;
        }
    }
}