using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabs
{
	// Validator for Login Page Object
	public class SwagLabsLoginPageValidator
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _waiter;
		
		protected SwagLabsLoginPageMap _map;
        public SwagLabsLoginPageValidator(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
			_waiter = new(_driver, TimeSpan.FromSeconds(5));
			_map = new(_driver);
		}

		public bool ThenErrorMessageShouldBe(string expectedMessage)
		{
			_waiter.Until(c => _map.PasswordField.Displayed);
			return _map.ErrorMessage.Text.Contains(expectedMessage);
		}

		public bool ThenLoginSuccessful()
		{
			if (_waiter.Until(c => _map.MainPageTitle.Displayed) 
				&& _map.MainPageTitle.Text == "Swag Labs")
			{
				return true;
			}

			return false;
		}
	}
}
