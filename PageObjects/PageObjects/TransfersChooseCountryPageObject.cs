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
    private static By dateFrom = By.XPath("//input[@id = 'datefrom']");
    private static By dateTo = By.XPath("//input[@id = 'dateto']");
    private static By travellersButton = By.XPath("//a[@class = 'dropdown-toggle dropdown-btn travellers']");
    private static By plusButton = By.XPath("//i[@class = 'la la-plus']");
    private static By searchButton = By.XPath("//div[@class = 'btn-search text-center']");
    public static string MoscowCity = "Moscow";

    public TransfersChooseCountryPageObject(IWebDriver driver)
    {
        this._driver = driver;
    }
    
    public static string GetCity()
    {
        return MoscowCity.ToLower();
    }

    public IWebElement fromCountry;
    public IWebElement toCountry;

    public TransfersListPageObject chooseCountries()
    {
        var countriesFields = _driver.FindElements(chooseCountriesField);
        countriesFields[0].Click();
        fromCountry = _driver.FindElement(By.XPath("//input[@class = 'select2-search__field']"));
        fromCountry.SendKeys(MoscowCity);
        Thread.Sleep(1000);
        _driver.FindElement((chooseFirstCountry)).Click();
        Thread.Sleep(3000);
        countriesFields[1].Click();
        toCountry = _driver.FindElement(By.XPath("//input[@class = 'select2-search__field']"));
        toCountry.SendKeys("Newport");
        var countriesTo =_driver.FindElements(By.XPath("//li[@class = 'select2-results__option']"));
        countriesTo[0].Click();
        _driver.Click(dateFrom);
        _driver.Click(By.XPath("//td[text() = '30']"));
        _driver.Click(dateTo);
        //_driver.Click(By.XPath("//td[text() = '31']"));
        _driver.Click(travellersButton);
        var pluses = _driver.FindElements(plusButton);
        _driver.Click(pluses[0]);
        _driver.Click(pluses[1]);
        _driver.Click(plusButton);
        _driver.Click(searchButton);
        Thread.Sleep(4000);
        return new TransfersListPageObject(_driver);
    }
}