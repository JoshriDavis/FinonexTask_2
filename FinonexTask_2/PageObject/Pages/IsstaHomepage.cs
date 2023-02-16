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
    internal class IsstaHomepage
    {
        // Create Global Driver
        private IWebDriver _driver;

        // Elements
        [FindsBy(How = How.CssSelector, Using = "#packages_search_dynamic > se-abroad-dynamic-packages-form > form > div > div:nth-child(1) > div > div > div.ng-form-controls > se-abroad-dynamic-packages-autocomplete > input")]
        public IWebElement destination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#start_date")]
        public IWebElement when { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#packages_search_dynamic > se-abroad-dynamic-packages-form > form > div > div:nth-child(2) > div.ng-form-actions.offset-lg-4.offset-xl-4.ng-star-inserted > div > form-button > button")]
        public IWebElement findDealButton { get; set; }

        // Create Page Factory
        public IsstaHomepage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Functions
        public void findDeal(String requiredDestination)
        {
            // choose a destination
            destination.SendKeys(requiredDestination);
            Thread.Sleep(2000);
            // choose start day
            _driver.ExecuteJavaScript("(document.querySelector('#datepicker_widget > div > div.month-wrapper > table.month1.current > tbody > tr:nth-child(5) > td:nth-child(1) > div > span')).click()");
            // choose end day
            _driver.ExecuteJavaScript("(document.querySelector('#datepicker_widget > div > div.month-wrapper > table.month2 > tbody > tr:nth-child(2) > td:nth-child(1) > div')).click()");
            // show results
            findDealButton.Click();
            Assert.IsTrue(true);
        }
    }
}
