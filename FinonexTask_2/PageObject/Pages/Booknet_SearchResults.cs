using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using SeleniumExtras.PageObjects;
using System.Linq;

namespace FinonexTask_2.PageObject.Pages
{
    internal class Booknet_SearchResults
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#jumptohere > section > div.categoryitems > div > div > div > a:nth-child(1) > h3")]
        public IWebElement firstResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#jumptohere > section > div.categoryitems > div > div > div > button")]
        public IWebElement firstResultAddToCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#add2basket-modal > div.body > a")]
        public IWebElement goToPayment { get; set; }

        public Booknet_SearchResults(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AddToCartDesiredBook(String bookToAdd)
        {
            Assert.IsTrue(firstResult.Text.Contains(bookToAdd), "First result is not the expected book.");
            if (firstResult.Text.Contains(bookToAdd))
            {
                firstResultAddToCart.Click();
                goToPayment.Click();
            }
        }

    }
}
