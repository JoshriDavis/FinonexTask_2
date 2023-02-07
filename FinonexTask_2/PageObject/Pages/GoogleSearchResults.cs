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
    public class GoogleSearchResults
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#rso > div:nth-child(1) > div > div > div > div > div > div > div > div.yuRUbf > a > h3")]
        public IWebElement _googleFirstResult { get; set; }

        public GoogleSearchResults(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public Boolean OpenFirstResult(String textToVerify)
        {
            if(_googleFirstResult.Text.Contains(textToVerify))
            {
                _googleFirstResult.Click();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
