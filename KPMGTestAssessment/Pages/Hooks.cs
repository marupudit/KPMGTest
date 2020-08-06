using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace KPMGTestAssessment.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        //Creating the private parameters that holds performance/execution time metrics       
        private long _start { get; set; }
        private long _end { get; set; }
        private long _startTotal { get; set; }
        private long _endTotal { get; set; }
        private long _totalDuration { get; set; }
        private ScenarioContext _scenarioContext { get; }

        //Created the Enum to standardize the parameters and eliminate the free text/type errors
        public enum WaitTime
        {
            // Wait times
            MediumWait,
            LongWait,
            ShortWait,
            LongTimeOut
        }

        //Defined the wait time, usually, I keep it under the run settings file.
        public static readonly Dictionary<WaitTime, int> WaitTimeSetting = new Dictionary<WaitTime, int>
        {
            { WaitTime.MediumWait, 4000 },
            { WaitTime.LongWait, 5000 },
            { WaitTime.ShortWait, 3000 },
            { WaitTime.LongTimeOut, 1000 }
        };
        //Creating the web driver object
        public static IWebDriver driver { get; set; }

        //Created this constructor as specflow depricated the scenario context
        public Hooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        [BeforeStep]
        public void BeforeStep()
        {
            //Capturing this metrics to calculate the overall duration for each step
            _start = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        [AfterStep]
        public void AfterStep()
        {
            _end = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine((_end - _start) + " : Milliseconds took to load this step : " + _scenarioContext.StepContext.StepInfo.Text);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _startTotal = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //Initializing the driver object and assigning chrome browser and configuring the drive with some settings.
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _endTotal = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _totalDuration = (_endTotal - _startTotal) / 1000;
            Console.WriteLine(_totalDuration + " : Seconds took to test this scenario");
            //Baseline test execution time is around 50 seconds, so benchmarking the performance to 62.5 seconds [25% contingency on top of baseline] 
            //and failing test if the overall test execution time breaches
            Assert.LessOrEqual(_totalDuration, 62.5);
            driver.Close();
            driver.Quit();
        }
    }
}

