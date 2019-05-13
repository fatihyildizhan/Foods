namespace Foods.Data.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Symbol { get; set; }

        public string WithSymbol
        {
            get
            {
                return $"{ Abbr } ({ Symbol })";
            }
        }
    }
}
