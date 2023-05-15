using OpenQA.Selenium;
using PageObjects.Helper;

namespace BackitAuto;

public delegate void TestDelegate(string param1, string param2);
public class ToursPage
{
    private IWebDriver _driver;

    public ToursPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public MainMenuPageObject findTours()
    {
        //_driver.EnterText("Moscow");
        Thread.Sleep(3000);
        return new MainMenuPageObject(_driver);
    }
    
}