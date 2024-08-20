using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagLabs;
using FluentAssertions;
using OpenQA.Selenium.Edge;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace SwagLabsTests
{

	[TestClass]
	public class SwagLabsLoginTests
	{
		private IWebDriver _driver;

		public void SetBrowser(string browserName)
		{
			switch (browserName.ToLower())
			{
				case "chrome":
					_driver = new ChromeDriver();
					break;
				case "edge":
					_driver = new EdgeDriver();
					break;

				default: throw new ArgumentException("Unknown browser");
			}
		}

		[DataTestMethod]
		[DynamicData(nameof(TestData.GetSupportedBrowsers), typeof(TestData), DynamicDataSourceType.Method)]
		public void Login_WhenUsernameAndPasswordEmpty_ThenErrorMessageShown(string browserName)
		{
			var givenUsername = "random username";
			var givenPassword = "random password";

			SetBrowser(browserName);
			var loginPage = new SwagLabsLoginPage(_driver);
			loginPage.Navigate();

			loginPage.WhenEnteredUsernameIs(givenUsername);
			loginPage.WhenEnteredPasswordIs(givenPassword);
			
			loginPage.WhenElementCleared(loginPage.Map.UsernameField);
			loginPage.WhenElementCleared(loginPage.Map.PasswordField);
			
			loginPage.WhenLoginButtonPressed();

			loginPage.Validator.ThenErrorMessageShouldBe("Username is required").Should().BeTrue(because: "Should show a valid error logging with empty credentials");
		}

		[DataTestMethod]
		[DynamicData(nameof(TestData.GetSupportedBrowsers), typeof(TestData), DynamicDataSourceType.Method)]
		public void Login_WhenPasswordEmpty_ThenErrorMessageShown(string browserName)
		{
			var givenUsername = "random username";
			var givenPassword = "random password";

			SetBrowser(browserName);
			var loginPage = new SwagLabsLoginPage(_driver);
			loginPage.Navigate();

			loginPage.WhenEnteredUsernameIs(givenUsername);
			loginPage.WhenEnteredPasswordIs(givenPassword);

			loginPage.WhenElementCleared(loginPage.Map.PasswordField);

			loginPage.WhenLoginButtonPressed();

			loginPage.Validator.ThenErrorMessageShouldBe("Password is required").Should().BeTrue(because: "Should show a valid error logging with empty credentials");
		}

		[DataTestMethod]
		[DynamicData(nameof(TestData.GetLoginWithValidCredentials), typeof(TestData), DynamicDataSourceType.Method)]
		public void Login_WhenValidCredentialsEntered_ThenLoginSuccessful(string browserName, string givenUsername)
		{
			string givenPassword = "secret_sauce";

			SetBrowser(browserName);
			SwagLabsLoginPage loginPage = new SwagLabsLoginPage(_driver);
			loginPage.Navigate();
			loginPage.WhenEnteredUsernameIs(givenUsername);
			loginPage.WhenEnteredPasswordIs(givenPassword);
			loginPage.WhenLoginButtonPressed();

			loginPage.Validator.ThenLoginSuccessful().Should().BeTrue( because: "Login should be successful with valid credentials");
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_driver.Quit();
		}
	}
}