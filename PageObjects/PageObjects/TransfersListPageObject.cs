using OpenQA.Selenium;

namespace BackitAuto;

public class TransfersListPageObject
{
    private IWebDriver _driver;
    public TransfersListPageObject(IWebDriver driver)
    {
        _driver = driver;
    }
    private IWebElement Message => _driver.FindElement(By.XPath("//h2[@class = 'sec__title_list']"));
    public string GetMessageFromTransfer()
    {
        return Message.Text;
    }
}