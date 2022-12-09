using Queens.Global.Constants;
using Queens.Models;
using UniRx;

namespace Queens.ViewModels
{
    public class StatsViewModel
    {
        public IntReactiveProperty Flow { get; set; }
        public IntReactiveProperty Popularity { get; set; }
        public IntReactiveProperty Money { get; set; }
        public IntReactiveProperty Health { get; set; }

        public StatsViewModel()
        {
        }

        public StatsViewModel(Status model)
        {
            Flow = new IntReactiveProperty(model.flow);
            Popularity = new IntReactiveProperty( model.popularity);
            Money = new IntReactiveProperty(model.money);
            Health = new IntReactiveProperty(model.health);
        }

        public bool AreStatsValid()
        {
            return Flow.Value is > PlayerConstants.MIN_FLOW and < PlayerConstants.MAX_FLOW 
                   && Popularity.Value is > PlayerConstants.MIN_POPULARITY and < PlayerConstants.MAX_POPULARITY 
                   && Health.Value > PlayerConstants.MIN_HEALTH 
                   && Money.Value is > PlayerConstants.MIN_MONEY and < PlayerConstants.MAX_MONEY;
        }
    }
}