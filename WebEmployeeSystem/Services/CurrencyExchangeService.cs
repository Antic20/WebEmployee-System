using Newtonsoft.Json;
using WebEmployeeSystem.Models;

namespace WebEmployeeSystem.Services
{
    public class CurrencyExchangeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://www.exchangerate-api.com/docs";

        public CurrencyExchangeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CurrencyExchangeRate>> GetExchangeRatesAsync()
        {
            try
            {
                string response = await _httpClient.GetStringAsync(ApiUrl);

                if (!string.IsNullOrEmpty(response))
                {
                    var rates = JsonConvert.DeserializeObject<List<CurrencyExchangeRate>>(response);
                    return rates;
                }
            }
            catch (HttpRequestException)
            {

            }


            return null;
        }
    }

}
