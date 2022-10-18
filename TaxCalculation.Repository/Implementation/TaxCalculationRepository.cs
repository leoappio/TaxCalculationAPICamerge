using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TaxCalculation.Entity;
using TaxCalculation.Repository.Contract;

namespace TaxCalculation.Repository.Implementation
{
    public class TaxCalculationRepository : ITaxCalculationRepository
    {
        private HttpClient client;
        private IConfiguration configuration;
        private string taxApiUrl;

        public TaxCalculationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            taxApiUrl = configuration.GetValue<string>("TaxApiURL");
            client = new HttpClient();
        }
        public async Task<Tax> GetInterestRateFromApiAsync()
        {
            Tax tax = null;
            HttpResponseMessage response = await client.GetAsync(taxApiUrl + "/GetInterestRate");
            if (response.IsSuccessStatusCode)
            {
                tax = JsonConvert.DeserializeObject<Tax>(
                        await response.Content.ReadAsStringAsync());
            }

            return tax;
        }
    }
}
