using DummyDb.Application.IQueries;
using System.Net.Http.Json;

namespace DummyDb.Infrastructure.ExternalServices
{
    public class FeedbackProxy : IFeedbackProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICRMClusterQuery _query;

        public FeedbackProxy(IHttpClientFactory clientFactory, ICRMClusterQuery query)
        {
            _query = query;
            _clientFactory = clientFactory;
        }

        async Task IFeedbackProxy.SeedData()
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("http://feedbackserviceapi:7001");
            var endpoint = "/api/seeding";
            var content = _query.GetCluster().ToList();

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