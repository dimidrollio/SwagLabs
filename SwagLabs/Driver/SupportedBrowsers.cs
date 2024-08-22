namespace SwagLabs.Driver
{
	public static class SupportedBrowsers
	{
		public static IEnumerable<string> Browsers => [CHROME, EDGE];
		public const string CHROME = "chrome";
		public const string EDGE = "edge";
	}
}
