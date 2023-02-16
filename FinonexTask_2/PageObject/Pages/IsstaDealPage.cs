using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.Extensions;

namespace FinonexTask_2.PageObject.Pages
{
    internal class IsstaDealPage
    {
        // Create Global Driver
        private IWebDriver _driver;

        // Elements
        [FindsBy(How = How.CssSelector, Using = "#wrapper > div.container.body-content > main > div > div.ancors-container > div > div:nth-child(2) > div.price-ancor-action > a")]
        public IWebElement chooseRoomButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#roomsForm > div:nth-child(9) > div.room-options-container > div.room-options > div.room-option.room-option-visible > div.room-option-actions-wrapper > div > div > div > a")]
        public IWebElement chooseTheFirstRoom { get; set; }

        // Create Page Factory
        public IsstaDealPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Functions
        public void chooseRoomAndGoToCheckout()
        {
            // Click on "Choose a room"
            chooseRoomButton.Click();
            Thread.Sleep(1500);
            // Choose a room and go to checkout
            chooseTheFirstRoom.Click();
        }
    }
}
