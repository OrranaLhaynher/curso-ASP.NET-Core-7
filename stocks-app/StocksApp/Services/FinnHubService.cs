using StocksApp.ServicesContracts;
using System.Text.Json;

namespace StocksApp.Services
{
    public class FinnHubService : IFinnHubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FinnHubService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)//string stockSymbol
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration.GetValue<string>("FinnHubKey")}")
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);
                string response = reader.ReadToEnd();

                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary == null)
                {
                    throw new InvalidOperationException("No response from FinnHub");
                }

                if (responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException($"Error {responseDictionary["error"]}");
                }

                return responseDictionary;
            }
        }
    }
}
