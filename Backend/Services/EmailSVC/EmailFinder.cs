using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using DataAccessTier.DataAccessController;
using DataAccessTier.DataAccessModel;


namespace Services
{
    public class EmailFinder
    {
        DataAccessCompany dataAccess = new DataAccessCompany();
        private static readonly string apiKey = "471b6cfed78bb8683f784ac832a332c5e177f9c7";
        private static readonly string baseUrl = "https://api.hunter.io/v2/domain-search";
        public async Task FindEmailsAsync(List<Company> companies)
        {
            using (var client = new HttpClient())
            {
                foreach (var company in companies)
                {
                        if (string.IsNullOrWhiteSpace(company.Website))
                            continue;

                        var domain = company.Website;
                        var url = $"{baseUrl}?domain={domain}&api_key={apiKey}";
                        var response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            var json = await response.Content.ReadAsStringAsync();
                            var data = JObject.Parse(json);

                            var emails = data["data"]?["emails"];
                            if (emails != null && emails.Any())
                            {
                                var firstEmail = emails.First()?["value"]?.ToString();
                                if (!string.IsNullOrWhiteSpace(firstEmail))
                                {
                                    company.Email = firstEmail;
                                    dataAccess.UpdateEmail(company);
                                }
                            }
                        }
                    
                }
            }
        }

    }
}
