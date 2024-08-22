using OpenQA.Selenium;

namespace SwagLabs.PageObjects
{
	public interface ILoginPage
	{
		public void Navigate();
		public void WhenEnteredUsernameIs(string username);
		public void WhenEnteredPasswordIs(string password);
		public void WhenElementCleared(IWebElement element);
		public void WhenLoginButtonPressed();
		public IEnumerable<string> GetAvailableUsernames();
	}
}
