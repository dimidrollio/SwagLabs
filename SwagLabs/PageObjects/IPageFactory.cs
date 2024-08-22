using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects
{
    public interface IPageFactory
	{
		public ILoginPage CreateLoginPage(IWebDriver driver);
	}
}
