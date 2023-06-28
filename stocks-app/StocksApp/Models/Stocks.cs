namespace StocksApp.Models
{
    public class Stocks
    {
        public string? StockSymbol { get; set; }
        public double CurrentPrice { get; set; }
        public double Change { get; set; }
        public double PercentChange { get; set; }
        public double HighPriceOfTheDay { get; set; }
        public double LowPriceOfTheDay { get; set; }
        public double OpenPriceOfTheDay { get; set; }
        public double PreviousClosePrice { get; set; }
    }
}
