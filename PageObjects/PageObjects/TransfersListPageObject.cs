using OpenQA.Selenium;

namespace BackitAuto;

public class TransfersListPageObject
{
    private IWebDriver _driver;

    public TransfersListPageObject(IWebDriver driver)
    {
        _driver = driver;
    }
}