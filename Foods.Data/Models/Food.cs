namespace Foods.Data.Models
{
    public class Food
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public int CountryId { get; set; }
    }

    public class FoodFull : Food
    {
        public int UpvotesCount { get; set; }
        public int DownvotesCount { get; set; }
        public string CurrencyName { get; set; }
        public string CountryName { get; set; }
        public string Abbrv { get; set; }

        public string Full
        {
            get
            {
                return $"{ Name }, { Price }, { CurrencyName }, { CountryName }";
            }
        }
    }
}
