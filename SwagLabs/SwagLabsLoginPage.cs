using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabs
{
	// Login Page Object Class
	public class SwagLabsLoginPage
	{
		private readonly IWebDriver _driver;
		private const string _url = "https://www.saucedemo.com/";

		private readonly WebDriverWait _waiter;
		public SwagLabsLoginPageMap Map { get; }
		public SwagLabsLoginPageValidator Validator { get; }

		public SwagLabsLoginPage(IWebDriver driver)
		{
			_driver = driver ?? throw new ArgumentNullException(nameof(driver));
			_waiter = new(_driver, TimeSpan.FromSeconds(5));
			Map = new(_driver);
			Validator = new(_driver);
		}
		public void Navigate()
		{
			_driver.Navigate().GoToUrl(_url);

		}
		public void WhenEnteredUsernameIs(string username)
		{
			if (_waiter.Until(c => Map.UsernameField.Enabled))
			{
				Map.UsernameField.SendKeys(username);

			}
		}
		public void WhenEnteredPasswordIs(string password)
		{
			if (_waiter.Until(c => Map.PasswordField.Enabled))
			{
				Map.PasswordField.SendKeys(password);
			}
		}
		public void WhenElementCleared(IWebElement element)
		{
			if (element == null) throw new ArgumentNullException(nameof(element));

			if (_waiter.Until(c => element.Enabled))
			{
				element.Click();
				element.SendKeys(Keys.Control + "a");
				element.SendKeys(Keys.Delete);
			}
		}

		public void WhenLoginButtonPressed()
		{
			if (_waiter.Until(cond => Map.LoginButton.Enabled && Map.LoginButton.Displayed))
			{
				Map.LoginButton.Click();
			}
		}

		public IEnumerable<string> GetAvailableUsernames()
		{
			IEnumerable<string> usernames = Map.ValidUsernames.Text.Split(separator: '\n', options: StringSplitOptions.TrimEntries);
			// Skipping the title
			usernames = usernames.Skip(1);
			return usernames;
		}
	}
}
