namespace StocksApp.ServicesContracts
{
    public interface IFinnHubService
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
        Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
    }
}
