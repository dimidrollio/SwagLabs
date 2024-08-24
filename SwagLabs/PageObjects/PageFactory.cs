using OpenQA.Selenium;
using SwagLabs.PageObjects.LoginPageObject;

namespace SwagLabs.PageObjects
{
    public class PageFactory : IPageFactory
	{
		public ILoginPage CreateLoginPage(IWebDriver driver)
		{
			return new LoginPage(driver);
		}
	}
}
