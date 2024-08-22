using SwagLabs.Driver;
using SwagLabs.Driver.Chrome;
using SwagLabs.Driver.Edge;

namespace SwagLabs.Driver
{
	public class DriverFactory : IDriverFactory
	{
		public IDriverManager CreateDriverManager(string browserName)
		{
			switch (browserName)
			{
				case SupportedBrowsers.CHROME:
					return new ChromeDriverManager();
				case SupportedBrowsers.EDGE: 
					return new EdgeDriverManager();
				default:
					throw new NotSupportedException();
			}
		}

	}
}
