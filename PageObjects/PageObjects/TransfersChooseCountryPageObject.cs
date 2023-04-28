using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjects.Helper;

namespace BackitAuto;

public class TransfersChooseCountryPageObject
{
    private IWebDriver _driver;
    private static By chooseCountriesField = By.XPath("//span[@class = 'select2-selection__rendered']");
    private static By countrField = By.XPath("//input[@class = 'select2-search__field']");
    private static By chooseFirstCountry = By.XPath("//li[@class = 'select2-results__option select2-results__option--highlighted']");
    private static By dateFrom = By.XPath("/input[@id= 'datefrom']");
    private static By dateTo = By.XPath("/input[@id= 'dateto']");
    
    public TransfersChooseCountryPageObject(IWebDriver driver)
    {
        this._driver = driver;
    }

    public TransfersListPageObject chooseCountries()
    {
        var countriesFields = _driver.FindElements(chooseCountriesField);
        countriesFields[0].Click();
        _driver.FindElement(By.XPath("//input[@class = 'select2-search__field']")).SendKeys("Moscow");
        Thread.Sleep(1000);
        _driver.FindElement((chooseFirstCountry)).Click();
        Thread.Sleep(3000);
        countriesFields[1].Click();
        _driver.EnterText(By.XPath("//input[@class = 'select2-search__field']"), "Newport");
        _driver.Click(chooseCountriesField);
        _driver.Click(dateFrom);
        _driver.Click(By.XPath("//td[text() = '30']"));
        _driver.Click(dateTo);
        _driver.Click(By.XPath("//td[text() = '31']"));
        Thread.Sleep(3000);
        Thread.Sleep(3000);
        return new TransfersListPageObject(_driver);
    }
}