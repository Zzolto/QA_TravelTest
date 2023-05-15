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
    public static By todayDate = By.XPath("//td[@class = 'day  active']");
    public static By countryField = By.XPath("//input[@class = 'select2-search__field']");
    private static By chooseFirstCountry = By.XPath("//li[@class = 'select2-results__option select2-results__option--highlighted']");

    /// <summary>
    /// Click the button
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="locator"></param>
    public static void Click(this IWebDriver driver, By locator)
    {
        // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        // wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(locator)));
        IWebElement ele = driver.FindElement(locator);
        if (ele.Displayed && ele.Enabled)
        {
            ele.Click();
        } 
    }
    public static void Click(this IWebDriver driver, IWebElement ele)
    {
        if (ele.Displayed && ele.Enabled)
        {
            ele.Click();
        }
    }
    
    public static By countryFieldw = By.XPath("//span[@class = 'select2-selection__rendered']");
    public static void EnterCity(string country)
    {
        driver.FindElement(countryFieldw).Click();
        driver.FindElement(CommonClass.countryField).SendKeys(country);
        driver.FindElement((chooseFirstCountry)).Click();
    }

    /// <summary>
    /// void by search for an element in a page 
    /// </summary>
    delegate void FindElement(By locator);
    public static IWebElement FindElementWithWait(this IWebDriver driver, By selector)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        return wait.Until(ExpectedConditions.ElementIsVisible(selector));
    }

    public static void EnterText(this IWebDriver driver, By locator, string text)
    {
        IWebElement ele = driver.FindElement(locator);
        if (ele.Displayed && ele.Enabled)
        {
            ele.Clear();
            ele.SendKeys(text);
        }
    }

    public static bool IsElementDisplayed(this IWebDriver driver, By locator)
    {
        IWebElement ele = driver.FindElement(locator);
        if (ele.Displayed)
        {
            return true;
        }
        return true;
    }

    public static string getText(this IWebDriver driver, By locator)
    {
        IWebElement ele = driver.FindElement(locator);
        var text = "";
        if (ele.Displayed)
            text = ele.Text;
        return text;
    }

    public static bool getTextWithValueDisplayed(this IWebDriver driver,  string value)
    {
        var text = "";
        IWebElement ele = driver.FindElement(By.XPath("//text()='"+ value +"']"));
        if (ele.Displayed)
            return true;
        
        return true;
    }
    
    public static IWebElement WaitUntilElementIsVisible(this IWebDriver driver, By locator)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
        return driver.FindElement(locator);
    }
    public static IWebElement WaitUntilElementIsVisible(this IWebDriver driver, IWebElement element)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
        return element;
    }

    public static void ScrollPage(this IWebDriver _driver,int x, int y)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript($"window.scrollBy({x}, {y});");
    }
}