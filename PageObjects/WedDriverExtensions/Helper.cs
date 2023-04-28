using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PageObjects.Helper;

public class Helper
{
    public IWebDriver _driver;
    public void WaitForElementToBeClickable(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    public void WaitForElementToBeVisible(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
    public void WaitForElementToBeVisibleAndClick(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
        _driver.FindElement(locator).Click();
    }
    
    public void Click(By locator)
    {
        WaitForElementToBeClickable(locator);
        _driver.FindElement(locator).Click();
    }
    
    public void Type(By locator, string text)
    {
        WaitForElementToBeVisible(locator);
        _driver.FindElement(locator).Clear();
        _driver.FindElement(locator).SendKeys(text);
    }
    
    public void AssertElementExists(By locator)
    {
        Assert.IsTrue(_driver.FindElements(locator).Count > 0, "Element does not exist.");
    }
}