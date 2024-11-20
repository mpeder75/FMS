using DummyDb.Application.Dto;
using System.Net.Http.Json;

namespace DummyDb.Infrastructure.ExternalServices
{
    public class FMSServiceProxy
    {
        async Task<List<SchoolClassDto>> FetchSchoolClassAsync(IHttpClientFactory clientFactory)
        {
            var client = clientFactory.CreateClient();
            //client.BaseAddress 

            // Send a GET request
            var response = await client.GetAsync("https://run.mocky.io/v3/66695b6d-dcf5-4117-973b-824d6d907898");

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response body to a SchoolClassDto
                var schoolClasses = await response.Content.ReadFromJsonAsync<List<SchoolClassDto>>();
                return schoolClasses;
            }

            // Return null if the request failed
            return null;
        }
    }
}
