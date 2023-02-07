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
    internal class Booknet_Cart
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#jumptohere > section > div.categoryitems > div:nth-child(2) > p:nth-child(1) > a > img")]
        public IWebElement goToCheckout { get; set; }

        public Booknet_Cart(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToCheckout()
        {
            goToCheckout.Click();
        }
    }
}
