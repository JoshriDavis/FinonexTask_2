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
    internal class Booknet_Payment
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "body > div.container > h1")]
        public IWebElement checkoutTitle { get; set; }

        public Booknet_Payment(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public Boolean VerifyPageTitle(String textToVerify)
        {
            if (checkoutTitle.Text.Contains(textToVerify))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
