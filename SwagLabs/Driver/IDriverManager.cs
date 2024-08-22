using OpenQA.Selenium;

namespace SwagLabs.Driver
{
	public interface IDriverManager
	{
		public IWebDriver CreateDriver();
		public IWebDriver GetDriver();
		public void QuitDriver();
		
	}
}
