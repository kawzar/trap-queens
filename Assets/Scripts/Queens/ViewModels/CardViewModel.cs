using Queens.Systems.CardFlow;

namespace Queens.ViewModels
{
    public class CardViewModel 
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Bearer { get; set; }
        public string Collection{ get; set; }
        public string Dialog{ get; set; }
        public string Yes_answer{ get; set; }
        public string No_answer{ get; set; }
        
        public int? level_lock{ get; set; }

        public CardFlowEventArgs YesAnswerArgs;
        public CardFlowEventArgs NoAnswerArgs;
    }
}
