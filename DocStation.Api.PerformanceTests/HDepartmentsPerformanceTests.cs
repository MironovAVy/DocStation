using DocStation.Api.PerformanceTests.DTOs;
using RestSharp;

namespace DocStation.Api.PerformanceTests
{
	[TestFixture]
	public class HDepartmentsPerformanceTests : PerformanceTestsBase
	{
		[Test]
		public async Task GetDepartments_CanExecuteMultipleRequests_DoesNotFailInTimeoutException()
		{
            const int threadCount = 100000;
            const int maxConcurrency = 1000; // Ограничение на количество одновременных запросов
            var tasks = new List<Task<RestResponse<List<DepartmentsDto>>>>();
            var semaphore = new SemaphoreSlim(maxConcurrency);

            for (int i = 0; i < threadCount; i++)
            {
                await semaphore.WaitAsync();
                var t = this.ExecuteGetAsync<List<DepartmentsDto>>("/departments").ContinueWith(task =>
                {
                    semaphore.Release();
                    return task.Result;
                });
                tasks.Add(t);
            }

            await Task.WhenAll(tasks);

            var taskResults = tasks.Select(t => t.Result);
            var okCount = taskResults.Count(x => x.StatusCode == System.Net.HttpStatusCode.OK);
            var failedCount = taskResults.Count(x => x.StatusCode != System.Net.HttpStatusCode.OK);
            Assert.That(okCount, Is.EqualTo(threadCount), $"OK = {okCount}, FAILED = {failedCount}");
        }
	}
}