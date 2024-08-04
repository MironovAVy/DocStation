using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace DocStation.Api.PerformanceTests
{
	public abstract class PerformanceTestsBase
	{
		protected readonly string _baseUrl;

		protected readonly IRestClient _restClient;

		public static IConfiguration InitConfiguration()
		{
			return new ConfigurationBuilder()
			   .AddJsonFile("appsettings.json")
				.Build();
		}

		public PerformanceTestsBase()
		{
			var configuration = InitConfiguration();
			_baseUrl = configuration.GetSection("BaseUrl").Value!;
			var options = new RestClientOptions(_baseUrl);
			_restClient = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
			TestContext.Progress.WriteLine($"Config params: Host = {_baseUrl}");
		}

		protected async Task<RestResponse<TOutput>> ExecuteGetAsync<TOutput>(string path) where TOutput : new()
		{
			var restRequest = new RestRequest(path);
			var restResult = await _restClient.ExecuteGetAsync<TOutput>(restRequest);
			return restResult;
		}
	}
}