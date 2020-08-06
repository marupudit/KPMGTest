using KPMGTestAssessment.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace KPMGTestAssessment.StepDefinitions
{
    [Binding]
    public sealed class JohnLewisTestSteps
    {
        /// <summary>
        /// Creating the mapping between the Gherkin steps and actual automation logic using SpecFlow via regular expression along with assertions
        /// </summary>
        JohnLewisTestPage currentPage = null;

        [StepDefinition(@"I launch the John Lewis site using the ""(.*)"" URL")]
        public void GivenILaunchTheJohnLewisSiteUsingTheURL(string url)
        {
            Hooks.driver.Navigate().GoToUrl(url);
            //Object for the page
            currentPage = new JohnLewisTestPage(Hooks.driver);
        }

        [StepDefinition(@"I accept the cookie banner on site")]
        public void GivenIAcceptTheCookieBannerOnSite()
        {
            Assert.That(currentPage.ClickCookiesPopup(), Is.EqualTo(true));
        }

        [StepDefinition(@"I browse for the ""(.*)"" product using the search functionality")]
        public void GivenIBrowseForTheProductUsingTheSearchFunctionality(string productName)
        {
            currentPage.SearchProduct(productName);
        }

        [StepDefinition(@"I browse for a random product under the Gift section")]
        public void WhenIBrowseForRandomProductUnderTheGiftSection()
        {
            currentPage.SelectingGiftSection();
            currentPage.SelectingShopForHimSubSection();
        }


        [StepDefinition(@"I selected '(.*)' quantities of the above product")]
        public void WhenISelectedQuantitiesOfTheAboveProduct(string quantity)
        {
            currentPage.ClickFirstItemInSearchResults();
            currentPage.UpdatingTheQuantity(quantity);
        }

        [StepDefinition(@"I added the selected product to the basket")]
        public void WhenIAddedTheSelectedProductToTheBasket()
        {
            currentPage.AddingItemToBasket();
        }

        [StepDefinition(@"I go to the basket and delete the products from the basket")]
        public void ThenIGoToTheBasketAndDeleteTheProductsFromTheBasket()
        {
            currentPage.GoToYourBasket();
            currentPage.RemovingItemFromBasket();
        }

        [StepDefinition(@"I verified ""(.*)"" text")]
        public void ThenIVerifiedText(string confirmationText)
        {
            Assert.That(currentPage.VerifyBasketEmptyText(confirmationText), Is.EqualTo(true));
        }

        [StepDefinition(@"I clear the cookies")]
        public void ThenIClearTheCookies()
        {
            Hooks.driver.Manage().Cookies.DeleteAllCookies();
        }

    }
}

