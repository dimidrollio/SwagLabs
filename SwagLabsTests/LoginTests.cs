using OpenQA.Selenium;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwagLabs.Driver.Chrome;
using SwagLabs.Driver;
using SwagLabs.PageObjects.LoginPageObject;
using SwagLabs;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace SwagLabsTests
{

	[TestClass]
	public class LoginTests
	{
		private IDriverManager driverManager;
		private static IEnumerable<object[]> CredentialsTestData {
			get
			{
				var driver = new ChromeDriverManager();
				var lPage = new LoginPage(driver.GetDriver());
				lPage.Navigate();

				var res = LoginTestData.GetLoginWithValidCredentials(lPage.GetAvailableUsernames());
				
				driver.QuitDriver();
				return res;
			}
		}

		[DataTestMethod]
		[DynamicData(nameof(LoginTestData.GetSupportedBrowsers), typeof(LoginTestData), DynamicDataSourceType.Property)]
		public void Login_WhenUsernameAndPasswordEmpty_ThenErrorMessageShown(string browserName)
		{
			driverManager = new DriverFactory().CreateDriverManager(browserName);
			var driver = driverManager.CreateDriver();
			
			if (driver is null) throw new Exception("Driver not set");

			var givenUsername = "random username";
			var givenPassword = "random password";

			var loginPage = new LoginPage(driver);
			loginPage.Navigate();

			loginPage.WhenEnteredUsernameIs(givenUsername);
			loginPage.WhenEnteredPasswordIs(givenPassword);
			
			loginPage.WhenElementCleared(loginPage.Map.UsernameField);
			loginPage.WhenElementCleared(loginPage.Map.PasswordField);
			
			loginPage.WhenLoginButtonPressed();

			loginPage.Validator.ThenErrorMessageShouldBe("Username is required").Should().BeTrue(because: "Should show a valid error logging with empty credentials");
		}

		[DataTestMethod]
		[DynamicData(nameof(LoginTestData.GetSupportedBrowsers), typeof(LoginTestData), DynamicDataSourceType.Property)]
		public void Login_WhenPasswordEmpty_ThenErrorMessageShown(string browserName)
		{
			driverManager = new DriverFactory().CreateDriverManager(browserName);
			var driver = driverManager.CreateDriver();

			if (driver is null) throw new Exception("Driver not set");

			var givenUsername = "random username";
			var givenPassword = "random password";

			var loginPage = new LoginPage(driver);
			loginPage.Navigate();

			loginPage.WhenEnteredUsernameIs(givenUsername);
			loginPage.WhenEnteredPasswordIs(givenPassword);

			loginPage.WhenElementCleared(loginPage.Map.PasswordField);

			loginPage.WhenLoginButtonPressed();

			loginPage.Validator.ThenErrorMessageShouldBe("Password is required").Should().BeTrue(because: "Should show a valid error logging with empty credentials");
		}

		[DataTestMethod]
		[DynamicData(nameof(CredentialsTestData), DynamicDataSourceType.Property)]
		public void Login_WhenValidCredentialsEntered_ThenLoginSuccessful(string browserName, string givenUsername)
		{
			driverManager = new DriverFactory().CreateDriverManager(browserName);
			var driver = driverManager.CreateDriver();

			if (driver is null) throw new Exception("Driver not set");

			string givenPassword = "secret_sauce";
			
			var loginPage = new LoginPage(driver);
			loginPage.Navigate();
			loginPage.WhenEnteredUsernameIs(givenUsername);
			loginPage.WhenEnteredPasswordIs(givenPassword);
			loginPage.WhenLoginButtonPressed();

			loginPage.Validator.ThenLoginSuccessful().Should().BeTrue( because: "Login should be successful with valid credentials");
		}

		[TestCleanup]
		public void TestCleanup()
		{
			driverManager.QuitDriver();
		}
	}
}