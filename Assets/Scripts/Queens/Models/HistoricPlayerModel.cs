namespace Queens.Models
{
    public class HistoricPlayerModel
    {
        public HistoricPlayerModel(int career, string name)
        {
            this.name = name;
            this.career = career;
        }
        public string name;
        public int career;
    }
}