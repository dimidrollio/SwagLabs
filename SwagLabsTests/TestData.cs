using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagLabs;
namespace SwagLabsTests
{
	// Data for tests execution
	public static class TestData
	{
		private static IWebDriver driver = new ChromeDriver();
		private static SwagLabsLoginPage loginPage = new(driver);
		private static IEnumerable<string> SupportedBrowsers => ["chrome", "edge"];

		public static IEnumerable<object[]> GetSupportedBrowsers()
		{
			List<object[]> data = [];

			foreach (string browser in SupportedBrowsers)
			{
				data.Add([browser]);
			}
			driver.Quit();
			return data;
		}

		public static IEnumerable<object[]> GetLoginWithValidCredentials()
		{
			loginPage.Navigate();

			List<object[]> data = [];
			IEnumerable<string> availableUsernames = loginPage.GetAvailableUsernames();

			foreach (string browser in SupportedBrowsers)
			{
				foreach (string username in availableUsernames)
				{
					data.Add([browser, username]);
				}
			}
			driver.Quit();
			return data;
		}
	}
}
