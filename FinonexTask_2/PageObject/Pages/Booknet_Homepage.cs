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
    public class Booknet_Homepage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "#nav-icon2-title")]
        public IWebElement hamburgerMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/header/div[3]/div/ul/li[7]/a")]
        public IWebElement childrenBooksCategory { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#sub-categories-container > div:nth-child(7) > a:nth-child(2)")]
        public IWebElement childrenBooks { get; set; }

        [FindsBy(How = How.Id, Using = "top-search")]
        public IWebElement searchBar { get; set; }

        public Booknet_Homepage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenHamburgerMenu()
        {
            hamburgerMenu.Click();
        }

        public void OpenChildrenBooksCategory()
        {
            childrenBooksCategory.Click();
            childrenBooks.Click();
        }
        public void Search(String textToSearch)
        {
            searchBar.SendKeys("מעשה בחמישה בלונים קשה");
            searchBar.SendKeys(Keys.Enter);
        }

    }
}
