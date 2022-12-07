using System;
using Queens.Global.Constants;

namespace Queens.Models
{
    [Serializable]
    public class Status
    {
        public int flow { get; set; }
        public int popularity { get; set; }
        public int health { get; set; }
        public int money { get; set; }

        public bool IsValid()
        {
            return flow is > PlayerConstants.MIN_FLOW and < PlayerConstants.MAX_FLOW 
                   && popularity is > PlayerConstants.MIN_POPULARITY and < PlayerConstants.MAX_POPULARITY 
                   && health > PlayerConstants.MIN_HEALTH 
                   && money is > PlayerConstants.MIN_MONEY and < PlayerConstants.MAX_MONEY;
        }
    }
}
