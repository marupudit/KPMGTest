using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KPMGTestAssessment
{
    [TestFixture]
    public class JohnLewisTest
    {
        
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        protected IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            //Set ChromeDriver
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void SimpleNUnitApproachForJohnLewisTest()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("");
            driver.Navigate().GoToUrl("https://www.johnlewis.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            if (IsElementPresent(By.XPath("//button[contains(text(),'Allow all')]")))
            {
                driver.FindElement(By.XPath("//button[contains(text(),'Allow all')]")).Click();
            }
            driver.FindElement(By.Id("desktopSearch")).Click();
            driver.FindElement(By.Id("desktopSearch")).Clear();
            driver.FindElement(By.Id("desktopSearch")).SendKeys("Apple Watch");
            driver.FindElement(By.Id("desktopSearch")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//h2/span")).Click();
            driver.FindElement(By.Id("quantity")).Click();
            driver.FindElement(By.Id("quantity")).Clear();
            driver.FindElement(By.Id("quantity")).SendKeys("2");
            driver.FindElement(By.Id("button--add-to-basket")).Click();
            driver.FindElement(By.LinkText("Go to your basket")).Click();
            driver.FindElement(By.XPath("(//button[@type='submit'])[4]")).Click();
            driver.FindElement(By.XPath("//main[@id='main']/div[2]")).Click();
            Assert.AreEqual("Your basket is empty.", driver.FindElement(By.XPath("//main[@id='main']/div[2]/div/h2")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
