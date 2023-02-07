using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using SeleniumExtras.PageObjects;

namespace FinonexTask_2.PageObject.Pages
{
    public class GoogleHomepage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement _searchtxtbox { get; set; }



        public GoogleHomepage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchtxtbox.SendKeys(Keys.Enter);
        }


    }
}