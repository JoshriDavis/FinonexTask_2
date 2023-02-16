using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using FinonexTask_2.PageObject.Pages;
using OpenQA.Selenium.Support.Extensions;

namespace FinonexTask_2.Test.Scripts
{
    public class Tests
    {
        public IWebDriver driver;

        // setup the web driver + maximize the screen size
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            // the following few steps handle issues related to "automated program is using this browser"
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-extensions");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddExcludedArguments("excludeSwitches", ("enable-automation"));
            options.AddArgument("enable-automation");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test, Order(1)]
        public void Test1()
        {
            // Open Issta
            driver.Navigate().GoToUrl("https://www.issta.co.il/");
            // Search a deal
            IsstaHomepage isstaHomepage = new IsstaHomepage(driver);
            isstaHomepage.findDeal("אמסטרדם, הולנד");
            // Click on "Order Now" for the first result
            IsstaSearchResults isstaSearchResults = new IsstaSearchResults(driver);
            isstaSearchResults.orderFirstResult();  
            // Choose a room and go to checkout
            IsstaDealPage isstaDealPage = new IsstaDealPage(driver);
            isstaDealPage.chooseRoomAndGoToCheckout();
            // Verify that the user is in the checkout
            Assert.IsTrue(driver.Title == "אישור פרטי הזמנה | איסתא", "You are not in the checkout screeen!");
        }

        // closes the web driver after finishing the tests
        [OneTimeTearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}