namespace StocksApp.ServicesContracts
{
    public interface IFinnHubService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
