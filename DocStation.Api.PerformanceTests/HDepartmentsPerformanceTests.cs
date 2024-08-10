using DocStation.Api.PerformanceTests.DTOs;
using RestSharp;
using System.Diagnostics;

namespace DocStation.Api.PerformanceTests
{
	[TestFixture]
	public class HDepartmentsPerformanceTests : PerformanceTestsBase
	{
		[Test]
		public async Task GetDepartments_CanExecuteMultipleRequests_DoesNotFailInTimeoutException()
		{
            const int threadCount = 10000;
            const int maxConcurrency = 1000; // Ограничение на количество одновременных запросов

			var tasks = new List<Task<(RestResponse<List<DepartmentsDto>> Result, long ElapsedMs)>>();
			var semaphore = new SemaphoreSlim(maxConcurrency);

			for (int i = 0;i < threadCount;i++)
			{
				var t = this.ExecuteAsync(semaphore);
				tasks.Add(t);
			}

			var taskResults = tasks.Select(t => t.Result);
            var okCount = taskResults.Count(x => x.Result.StatusCode == System.Net.HttpStatusCode.OK);
            var failedCount = taskResults.Count(x => x.Result.StatusCode != System.Net.HttpStatusCode.OK);
            Assert.That(okCount, Is.EqualTo(threadCount), $"OK = {okCount}, FAILED = {failedCount}");
			var metrcis = taskResults.Select(x => x.ElapsedMs);
			Console.WriteLine($"METRICS. MAX = {metrcis.Max()} ms, MIN = {metrcis.Min()} ms, AVG = {metrcis.Average()} ms");
        }

		private async Task<(RestResponse<List<DepartmentsDto>> Result, long ElapsedMs)> ExecuteAsync(SemaphoreSlim slim)
		{
			await slim.WaitAsync();
			try
			{
				Stopwatch sw = Stopwatch.StartNew();
				var result = await this.ExecuteGetAsync<List<DepartmentsDto>>("/departments");
				sw.Stop();
				return (result, sw.ElapsedMilliseconds);
			}
			finally
			{
				slim.Release();
			}
		}
	}
}