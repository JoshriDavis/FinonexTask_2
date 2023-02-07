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
    internal class Booknet_Checkout
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.Id, Using = "customerFirstName")]
        public IWebElement firstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "customerLastName")]
        public IWebElement lastNameField { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement phoneField { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement cityField { get; set; }

        [FindsBy(How = How.Id, Using = "street")]
        public IWebElement streetField { get; set; }

        [FindsBy(How = How.Id, Using = "homenum")]
        public IWebElement streetNumberField { get; set; }

        [FindsBy(How = How.Id, Using = "isConfirm")]
        public IWebElement agreeToTermsCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "shipment")]
        public IWebElement shipmentMethod { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/select/option[3]")]
        public IWebElement shipmentMethodSecondOption { get; set; }

        [FindsBy(How = How.Id, Using = "form-submit-button")]
        public IWebElement payButtun { get; set; }

        public Booknet_Checkout(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void FillInformationAndContinueToPayment(String email, String firstName, String lastName, String phone, String city, String street, String streetNumber)
        {
            emailField.SendKeys(email);
            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            phoneField.SendKeys(phone);
            cityField.SendKeys(city);
            streetField.SendKeys(street);
            streetNumberField.SendKeys(streetNumber);
            shipmentMethod.Click();
            shipmentMethodSecondOption.Click();
            agreeToTermsCheckbox.Click();
            payButtun.Click();
        }
    }
}
