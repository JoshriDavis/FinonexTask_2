using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.Extensions;

namespace FinonexTask_2.PageObject.Pages
{
    internal class IsstaSearchResults
    {
        // Create Global Driver
        private IWebDriver _driver;

        // Elements
        [FindsBy(How = How.CssSelector, Using = "#hotelsResult1 > div.results.hotels-results > div:nth-child(1) > div.result-price > div > a")]
        public IWebElement orderNowButtonFirstResult { get; set; }

        // Create Page Factory
        public IsstaSearchResults(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Functions
        public void orderFirstResult()
        {
            orderNowButtonFirstResult.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        }

    }
}
