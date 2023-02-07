using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using FinonexTask_2.PageObject.Pages;

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
            options.AddArguments("--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        // Steps 1-9 - order 2 children books
        [Test, Order(1)]
        public void Test1()
        {
            // step 1
            driver.Navigate().GoToUrl("https://www.google.com/");
            // step 2
            GoogleHomepage googleHompage = new GoogleHomepage(driver);
            googleHompage.Search("צומת ספרים");
            GoogleSearchResults googleSearchResults = new GoogleSearchResults(driver);
            Assert.IsTrue(googleSearchResults.OpenFirstResult("צומת ספרים"), "First result is not the expected site.");
            // step 3
            Booknet_Homepage booknetHomepage = new Booknet_Homepage(driver);
            booknetHomepage.OpenHamburgerMenu();
            booknetHomepage.OpenChildrenBooksCategory();
            // step 4
            Booknet_ChildrenBooks booknetChildrenBooks = new Booknet_ChildrenBooks(driver);
            booknetChildrenBooks.AddFirstBookToCart();
            booknetChildrenBooks.AddSecondBookToCartAndGoToPayment();
            // step 5
            Booknet_Cart booknetCart = new Booknet_Cart(driver);
            booknetCart.GoToCheckout();
            // steps 6-9
            Booknet_Checkout booknetCheckout = new Booknet_Checkout(driver);
            booknetCheckout.FillInformationAndContinueToPayment("test@email.com", "טסט", "טסט", "0555555555", "תל אביב - יפו", "נעמן", "1");
            Booknet_Payment booknetPayment = new Booknet_Payment(driver);
            Assert.IsTrue(booknetPayment.VerifyPageTitle("דף תשלום מאובטח"), "You are not in the checkout screen!");
            driver.Quit();
        }

        // Steps 10-13 - search for a specific book and order it
        [Test, Order(2)]
        public void test2()
        {
            // step 10
            driver.Navigate().GoToUrl("https://www.booknet.co.il/");
            // step 11
            Booknet_Homepage booknetHomepage = new Booknet_Homepage(driver);
            booknetHomepage.Search("מעשה בחמישה בלונים קשה");
            // step 12
            Booknet_SearchResults booknetSearchResults = new Booknet_SearchResults(driver);
            booknetSearchResults.AddToCartDesiredBook("מעשה בחמישה בלונים קשה");
            // step 13
            Booknet_Cart booknetCart = new Booknet_Cart(driver);
            booknetCart.GoToCheckout();
            Booknet_Checkout booknetCheckout = new Booknet_Checkout(driver);
            booknetCheckout.FillInformationAndContinueToPayment("test@email.com", "טסט", "טסט", "0555555555", "תל אביב - יפו", "נעמן", "1");
            Booknet_Payment booknetPayment = new Booknet_Payment(driver);
            Assert.IsTrue(booknetPayment.VerifyPageTitle("דף תשלום מאובטח"), "You are not in the checkout screen!");
        }

        // closes the web driver after finishing the tests
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}