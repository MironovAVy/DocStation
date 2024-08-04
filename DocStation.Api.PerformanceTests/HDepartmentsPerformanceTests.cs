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
			const int threadCount = 10000;
			var tasks = new List<Task<RestResponse<List<DepartmentsDto>>>>();

			for(int i = 0; i < threadCount; i++)
			{
				var t = this.ExecuteGetAsync<List<DepartmentsDto>>("/departments");
				tasks.Add(t);
			}
			await Task.WhenAll(tasks);

			var taskResutls = tasks.Select(t => t.Result);
			var okCount = taskResutls.Count(x => x.StatusCode == System.Net.HttpStatusCode.OK);
			var failedCount = taskResutls.Count(x => x.StatusCode != System.Net.HttpStatusCode.OK);
			Assert.That(okCount, Is.EqualTo(threadCount), $"OK = {okCount}, FAILED = {failedCount}");
		}
	}
}