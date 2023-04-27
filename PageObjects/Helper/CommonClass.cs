using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PageObjects.Helper;

public static class CommonClass
{
    public static IWebDriver driver;
    public static By firstNameField = By.XPath("//input[@name = 'first_name']");
    public static By secondNameField = By.XPath("//input[@name = 'last_name']");
    public static By emailField = By.XPath("//input[@name = 'email']");
    public static By phoneField = By.XPath("//input[@name = 'phone']");
    public static By dateField = By.XPath("//input[@name = 'date']");
    
    public static void ClickOnElement(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        element.Click();
    }
    
    public static void SendKeysToElement( By locator, string text)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        element.Clear();
        element.SendKeys(text);
    }
}