using OpenQA.Selenium;

namespace BackitAuto;

public class TargetPageObject
{
    private IWebDriver _driver;
    public TargetPageObject(IWebDriver driver)
    {
        this._driver = driver;
    }

    private IWebElement Message => _driver.FindElement(By.XPath("//div[@class ='card-body my-5 text-center']/h2"));
    public string GetMessage()
    {
        Thread.Sleep(1000);
        return Message.Text;
    }

    public void ClickMessage() => Message.Click();

}