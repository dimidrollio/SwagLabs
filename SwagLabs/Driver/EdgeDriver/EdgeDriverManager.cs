using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SwagLabs.Driver.Edge
{
    public class EdgeDriverManager : IDriverManager
    {
        private EdgeDriver? _driver;
        public IWebDriver CreateDriver()
        {
            if (_driver is null)
            {
                _driver = new EdgeDriver();
                return _driver;

            }
            else
            {
                return GetDriver();
            }
        }

        public IWebDriver GetDriver()
        {
            if (_driver is null)
            {
                CreateDriver();
            }

            return _driver;
        }

        public void QuitDriver()
        {
            if (_driver is not null)
            {
				_driver.Quit();
				_driver = null;
			}           
        }
    }
}
