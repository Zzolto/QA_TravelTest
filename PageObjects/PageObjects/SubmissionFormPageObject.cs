using OpenQA.Selenium;
using PageObjects.Helper;

namespace BackitAuto;

public class SubmissionFormPageObject
{
    private IWebDriver _driver;
    private IWebElement firstName;
    public SubmissionFormPageObject(IWebDriver driver) { this._driver = driver;}
    protected static By todayDate = By.XPath("//td[@class = 'day  active']");
    public static By _firstNameField = By.XPath("//input[@name = 'first_name']");
    protected static By submitButton = By.XPath("//i[@class ='mdi mdi-search']");
    
    protected MainMenuPageObject helper()
    {
        TargetPage();
        return new MainMenuPageObject(_driver);
    }
    public TargetPageObject TargetPage()
    {
        _driver.FindElement(_firstNameField).SendKeys("Zolto");
        _driver.FindElement(CommonClass.secondNameField).SendKeys("Gunzenov");
        _driver.FindElement(CommonClass.phoneField).SendKeys("79834320108");
        _driver.FindElement(CommonClass.emailField).SendKeys("qw@mail.ru");
        _driver.FindElement(CommonClass.dateField).Click();
        _driver.FindElement(todayDate).Click();
        Thread.Sleep(1000);
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        
        js.ExecuteScript("window.scrollBy(0, 500);");
        Thread.Sleep(1000);
        _driver.FindElement(submitButton).Click();
        return new TargetPageObject(_driver);
    }
    
}