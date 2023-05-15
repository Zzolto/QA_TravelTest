using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using BackitAuto;
using System.Configuration;
using NUnit.Framework.Interfaces;
using Utils;
using System;

namespace Tests.Common
{
    internal class TestBase
    {
        protected IWebDriver Driver { get; private set; }
        protected MainMenuPageObject MainMenu { get; private set; }
    
        private readonly string _baseurl = "https://phptravels.net/";
        protected readonly By _accountButton = By.XPath("//button[@id='ACCOUNT']");
        protected AllureReporting AllureReporting { get; private set; }
        
        [SetUp]
        protected void Setup()
        {
            AllureReporting = new AllureReporting();
            string url = ConfigurationManager.AppSettings["Url"];
            Driver = new ChromeDriver();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl(_baseurl);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            MainMenu = new MainMenuPageObject(Driver);
        }
    
        [TearDown]
        protected void DoAfterEach()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
        

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    break;
            }
        }
    }
}
