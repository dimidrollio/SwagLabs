using OpenQA.Selenium.Chrome;
using SwagLabs;
namespace SwagLabsTests
{
	// Data for tests execution
	public static class TestData
	{
		private static IEnumerable<string> SupportedBrowsers => ["chrome", "edge"];

		public static IEnumerable<object[]> GetSupportedBrowsers()
		{
			List<object[]> data = [];

			foreach (string browser in SupportedBrowsers)
			{
				data.Add([browser]);
			}

			return data;
		}

		public static IEnumerable<object[]> GetLoginWithValidCredentials()
		{
			using (var driver = new ChromeDriver())
			{
				List<object[]> data = [];

				var loginPage = new SwagLabsLoginPage(driver);
				loginPage.Navigate();

				IEnumerable<string> availableUsernames = loginPage.GetAvailableUsernames();

				foreach (string browser in SupportedBrowsers)
				{
					foreach (string username in availableUsernames)
					{
						data.Add([browser, username]);
					}
				}

				return data;
			}
		}
	}
}
