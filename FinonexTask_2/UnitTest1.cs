using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace FinonexTask_2
{
    public class Tests
    {
        public IWebDriver driver;
        IWebElement goToPayment;
        IWebElement goToCheckout;
        IWebElement emailField;
        IWebElement firstNameField;
        IWebElement lastNameField;
        IWebElement phoneField;
        IWebElement cityField;
        IWebElement streetField;
        IWebElement streetNumberField;
        IWebElement agreeToTermsCheckbox;
        IWebElement shipmentMethod;
        IWebElement shipmentMethodSecondOption;
        IWebElement payButtun;
        IWebElement checkoutTitle;

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

        // *** No children under discounts ***

        // Steps 1-9 - order 2 children books
        [Test, Order(1)]
        public void Test1()
        {
            // step 1
            driver.Navigate().GoToUrl("https://www.google.com/");
            // step 2
            IWebElement googleSearchBar = driver.FindElement(By.Name("q"));
            googleSearchBar.SendKeys("צומת ספרים");
            googleSearchBar.SendKeys(Keys.Enter);
            IWebElement googleFirstResult = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div > div > div > div > div > div.yuRUbf > a > h3"));
            Assert.IsTrue(googleFirstResult.Text.Contains("צומת ספרים"), "First result is not the expected site.");
            googleFirstResult.Click();
            // step 3
            IWebElement hamburgerMenu = driver.FindElement(By.CssSelector("#nav-icon2-title"));
            hamburgerMenu.Click();
            IWebElement childrenBooksCategory = driver.FindElement(By.XPath("/html/body/header/div[3]/div/ul/li[7]/a"));
            childrenBooksCategory.Click();
            IWebElement childrenBooks = driver.FindElement(By.CssSelector("#sub-categories-container > div:nth-child(7) > a:nth-child(2)"));
            childrenBooks.Click();
            // step 4
            IWebElement firstBookAddToCart = driver.FindElement(By.CssSelector("#jumptohere > section > div.categoryitems > div > div:nth-child(6) > div > button"));
            IWebElement secondBookAddToCart = driver.FindElement(By.XPath("//*[@id=\"jumptohere\"]/section/div[3]/div/div[5]/div/button"));
            firstBookAddToCart.Click();
            IWebElement xButton = driver.FindElement(By.CssSelector("body > div.ec_modal-cover > button"));
            xButton.Click();
            secondBookAddToCart.Click();
            // step 5
            goToPayment = driver.FindElement(By.CssSelector("#add2basket-modal > div.body > a"));
            goToPayment.Click();
            goToCheckout = driver.FindElement(By.CssSelector("#jumptohere > section > div.categoryitems > div:nth-child(2) > p:nth-child(1) > a > img"));
            goToCheckout.Click();
            // step 6
            emailField = driver.FindElement(By.Id("email"));
            firstNameField = driver.FindElement(By.Id("customerFirstName"));
            lastNameField = driver.FindElement(By.Id("customerLastName"));
            phoneField = driver.FindElement(By.Id("phone"));
            cityField = driver.FindElement(By.Id("city"));
            streetField = driver.FindElement(By.Id("street"));
            streetNumberField = driver.FindElement(By.Id("homenum"));
            agreeToTermsCheckbox = driver.FindElement(By.Id("isConfirm"));
            shipmentMethod = driver.FindElement(By.Id("shipment"));
            shipmentMethodSecondOption = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/select/option[3]"));
            payButtun = driver.FindElement(By.Id("form-submit-button"));
            emailField.SendKeys("test@email.com");
            firstNameField.SendKeys("טסט");
            lastNameField.SendKeys("טסט");
            phoneField.SendKeys("0555555555");
            cityField.SendKeys("תל אביב - יפו");
            streetField.SendKeys("נעמן");
            streetNumberField.SendKeys("1");
            // step 7
            shipmentMethod.Click();
            shipmentMethodSecondOption.Click();
            // step 8
            agreeToTermsCheckbox.Click();
            // step 9
            payButtun.Click();
            checkoutTitle = driver.FindElement(By.CssSelector("body > div.container > h1"));
            Assert.IsTrue(checkoutTitle.Text == "דף תשלום מאובטח", "You are not in the checkout screen!");
            driver.Quit();
        }

        // Steps 10-13 - search for a specific book and order it
        [Test, Order(2)]
        public void test2()
        {
            // step 10
            driver.Navigate().GoToUrl("https://www.booknet.co.il/");
            // step 11
            IWebElement searchBar = driver.FindElement(By.Id("top-search"));
            searchBar.SendKeys("מעשה בחמישה בלונים קשה");
            searchBar.SendKeys(Keys.Enter);
            IWebElement firstResult = driver.FindElement(By.CssSelector("#jumptohere > section > div.categoryitems > div > div > div > a:nth-child(1) > h3"));
            Assert.IsTrue(firstResult.Text.Contains("מעשה בחמישה בלונים קשה"), "First result is not the expected book.");
            // step 12
            IWebElement firstResultAddToCart = driver.FindElement(By.CssSelector("#jumptohere > section > div.categoryitems > div > div > div > button"));
            firstResultAddToCart.Click();
            // step 13
            goToPayment = driver.FindElement(By.CssSelector("#add2basket-modal > div.body > a"));
            goToPayment.Click();
            goToCheckout = driver.FindElement(By.CssSelector("#jumptohere > section > div.categoryitems > div:nth-child(2) > p:nth-child(1) > a > img"));
            goToCheckout.Click();
            emailField = driver.FindElement(By.Id("email"));
            firstNameField = driver.FindElement(By.Id("customerFirstName"));
            lastNameField = driver.FindElement(By.Id("customerLastName"));
            phoneField = driver.FindElement(By.Id("phone"));
            cityField = driver.FindElement(By.Id("city"));
            streetField = driver.FindElement(By.Id("street"));
            streetNumberField = driver.FindElement(By.Id("homenum"));
            agreeToTermsCheckbox = driver.FindElement(By.Id("isConfirm"));
            shipmentMethod = driver.FindElement(By.Id("shipment"));
            shipmentMethodSecondOption = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/select/option[3]"));
            payButtun = driver.FindElement(By.Id("form-submit-button"));
            emailField.SendKeys("test@email.com");
            firstNameField.SendKeys("טסט");
            lastNameField.SendKeys("טסט");
            phoneField.SendKeys("0555555555");
            cityField.SendKeys("תל אביב - יפו");
            streetField.SendKeys("נעמן");
            streetNumberField.SendKeys("1");
            agreeToTermsCheckbox.Click();
            shipmentMethod.Click();
            shipmentMethodSecondOption.Click();
            payButtun.Click();
            checkoutTitle = driver.FindElement(By.CssSelector("body > div.container > h1"));
            Assert.IsTrue(checkoutTitle.Text == "דף תשלום מאובטח", "You are not in the checkout screen!");
        }

        // closes the web driver after finishing the tests
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}