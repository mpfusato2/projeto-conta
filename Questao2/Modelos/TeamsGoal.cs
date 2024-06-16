namespace Questao2.Modelos
{
    public class TeamsGoal
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public IEnumerable<Data> Data { get; set; }
    }
}