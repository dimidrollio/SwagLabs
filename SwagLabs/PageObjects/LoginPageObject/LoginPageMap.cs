using OpenQA.Selenium;

namespace SwagLabs.PageObjects.LoginPageObject
{
    public class LoginPageMap
    {
        private readonly IWebDriver _driver;
        public LoginPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UsernameField => _driver.FindElement(By.XPath("//input[@id ='user-name']"));
        public IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@id='password']"));
        public IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@id='login-button']"));
        public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//h3[@data-test='error']"));
        public IWebElement ValidUsernames => _driver.FindElement(By.XPath("//div[@id='login_credentials']"));
        public IWebElement MainPageTitle => _driver.FindElement(By.XPath("//div[@class = 'app_logo']"));
    }
}
