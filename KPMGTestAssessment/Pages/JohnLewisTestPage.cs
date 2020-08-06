using KPMGTestAssessment.StepDefinitions;
using OpenQA.Selenium;
using System;
using static KPMGTestAssessment.StepDefinitions.Hooks;

namespace KPMGTestAssessment.Pages
{
    public class JohnLewisTestPage
    {
        private IWebDriver _driver { get; }
        /// <summary>
        /// Defining the page objects/ elements that I need to interact on webpage
        /// </summary>
        private IWebElement _cookiesContinueButton => _driver.FindElement(By.XPath("//button[contains(text(),'Allow all')]"));
        private IWebElement _searchBox => _driver.FindElement(By.XPath("//input[@id='desktopSearch']"));
        private IWebElement _selectGiftSection => _driver.FindElement(By.XPath("(//a[contains(text(),'Gifts')])[3]"));
        private IWebElement _selectShopForHimSubSection => _driver.FindElement(By.XPath("//a[contains(text(),'Shop now')]"));
        private IWebElement _firstItemInSearchResults => _driver.FindElement(By.XPath("//h2/span"));
        private IWebElement _quantityInputBox => _driver.FindElement(By.XPath("//input[@id='quantity']"));
        private IWebElement _addingItemToBasketButton => _driver.FindElement(By.XPath("//button[@id='button--add-to-basket']"));
        private IWebElement _goToYourBasketButton => _driver.FindElement(By.XPath("//a[@class='add-to-basket-view-basket-link mini-basket-trigger-link']"));
        private IWebElement _removeItemFromBasketButton => _driver.FindElement(By.XPath("//button[@class='remove-basket-item-form-button']"));
        private IWebElement _basketEmptyConfirmationText => _driver.FindElement(By.XPath("//h2[@class='u-centred']"));

        // Constructor to initialize objects in the page
        public JohnLewisTestPage(IWebDriver webDriver) => _driver = webDriver;
        /// <summary>
        /// Creating the actions/Methods that I need to perform on webpage
        /// </summary>
        public void ClickFirstItemInSearchResults() => ClickAndWait(_firstItemInSearchResults, WaitTime.LongWait);
        public void AddingItemToBasket() => ClickAndWait(_addingItemToBasketButton, WaitTime.ShortWait);
        public void GoToYourBasket() => ClickAndWait(_goToYourBasketButton, WaitTime.ShortWait);
        public void RemovingItemFromBasket() => ClickAndWait(_removeItemFromBasketButton, WaitTime.ShortWait);
        public void SelectingGiftSection() => ClickAndWait(_selectGiftSection, WaitTime.LongWait);
        public void SelectingShopForHimSubSection() => ClickAndWait(_selectShopForHimSubSection, WaitTime.LongWait);
        public void UpdatingTheQuantity(string quantity)
        {
            ClearAndSetText(_quantityInputBox, quantity);
        }
        public void SearchProduct(string productName)
        {
            ClearAndSetText(_searchBox, productName);
            _searchBox.SendKeys(Keys.Enter);
        }

        public bool VerifyBasketEmptyText(string expectedText)
        {
            string actualText = GetText(_basketEmptyConfirmationText);
            if (actualText.Trim().Equals(expectedText.Trim()))
                return true;
            else
                return false;
        }
        public bool ClickCookiesPopup()
        {
            if (IsElementPresent(_cookiesContinueButton))
            {
                Click(_cookiesContinueButton);
                return true;
            }
            else
            {
                Console.WriteLine("Cookies are not present on this website!");
                return false;
            }
        }


        /// <summary>
        /// Reusable methods for controls on webpage
        /// </summary>
        /// <param name="element"></param>

        public static void ClickAndWait(IWebElement element, WaitTime waitTime)
        {
            Click(element);
            int milliseconds = WaitTimeSetting[waitTime];
            Hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(milliseconds);
        }
        public static void Click(IWebElement element)
        {
            element.Click();

        }
        public static void ClearAndSetText(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Element not present : {0}",element);
                return false;
            }
        }

    }
}

