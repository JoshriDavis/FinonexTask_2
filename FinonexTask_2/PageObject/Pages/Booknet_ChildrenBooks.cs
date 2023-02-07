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
    internal class Booknet_ChildrenBooks
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#jumptohere > section > div.categoryitems > div > div:nth-child(6) > div > button")]
        public IWebElement firstBookAddToCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"jumptohere\"]/section/div[3]/div/div[5]/div/button")]
        public IWebElement secondBookAddToCart{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.ec_modal-cover > button")]
        public IWebElement xButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#add2basket-modal > div.body > a")]
        public IWebElement goToPayment { get; set; }

        public Booknet_ChildrenBooks(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AddFirstBookToCart()
        {
            firstBookAddToCart.Click();
            xButton.Click();
        }
        public void AddSecondBookToCartAndGoToPayment()
        {
            secondBookAddToCart.Click();
            goToPayment.Click();
        }
    }
}
