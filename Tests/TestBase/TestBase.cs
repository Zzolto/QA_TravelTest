using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using BackitAuto;
using System.Configuration;

namespace Tests.Common
{
    internal class TestBase
    {
        protected IWebDriver Driver { get; private set; }
        protected MainMenuPageObject MainMenu { get; private set; }
    
        private readonly string _baseurl = "https://phptravels.net/";
        protected readonly By _accountButton = By.XPath("//button[@id='ACCOUNT']");
    
        [SetUp]
        protected void Setup()
        {
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
    
    }
}
