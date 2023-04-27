using BackitAuto;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BackitAuto;
public class VisaPage
{
    private IWebDriver _driver;
    
    protected static By chooseCountryField = By.XPath("//span[@class = 'select2-selection select2-selection--single']");
    protected static By countrySelectFrom = By.XPath("//select[@id = 'from_country']");
    protected static By countrySelectTo = By.XPath("//select[@id = 'to_country']");
    protected static By todayDate = By.XPath("//td[@class = 'day  active']");
    protected static By submitButton = By.XPath("//button[@id= 'submit']");
    public VisaPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public IList<IWebElement> chooseCountry { get; set; } = new List<IWebElement>()
    { };

    protected static By fromCountryChoose = By.XPath("//span[@class = 'select2-search select2-search--dropdown']");
    protected static By toCountryChoose = By.XPath("//span[@id = 'select2-to_country-container']");
    protected static By Angola = By.XPath("//li[@id = 'select2-from_country-result-spkq-AO']");
    protected static By Argentina = By.XPath("//li[@id = 'select2-to_country-result-boz5-AR']");
    public static By dateField = By.XPath("//input[@id = 'date']");

    public SubmissionFormPageObject ChooseCountryFrom()
    {
        _driver.FindElements(chooseCountryField)[0].Click();
        SelectElement selectFrom = new SelectElement(_driver.FindElement(countrySelectFrom));
        selectFrom.SelectByValue("AF");
        _driver.FindElements(chooseCountryField)[1].Click();
        SelectElement selectTo = new SelectElement(_driver.FindElement(countrySelectTo));
        selectTo.SelectByValue("YE");
        _driver.FindElement(dateField).Click();
        _driver.FindElement(todayDate).Click();
        _driver.FindElement(submitButton).Click();
        return new SubmissionFormPageObject(_driver);
    }

}