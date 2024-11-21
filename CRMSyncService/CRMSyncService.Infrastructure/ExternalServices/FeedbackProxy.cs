using DummyDb.Application.Dto;
using DummyDb.Application.IQueries;
using System.Net.Http.Json;
using System.Net.Http;

namespace DummyDb.Infrastructure.ExternalServices
{
    public class FeedbackProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ISchoolClassQuery _query;

        public FeedbackProxy(IHttpClientFactory clientFactory, ISchoolClassQuery query) 
        { 
            _query = query;
            _clientFactory = clientFactory;
        }

        public async Task SeedData()
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7250"); // Localhost? Indtil Dockerized
            var endpoint = "/api/fake-feedback";
            var content = _query.GetSchoolClasses().ToList();

            try
            {
                var postResponse = await client.PostAsJsonAsync(endpoint, content);

                if (!postResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Failed to Seed FeedbackService: {postResponse.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                // Implementer 'Logging'
            }
        }
    }
}