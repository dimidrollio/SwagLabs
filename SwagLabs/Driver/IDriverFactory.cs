namespace SwagLabs.Driver
{
	public interface IDriverFactory
	{
		public IDriverManager CreateDriverManager(string browserName);
	}
}
