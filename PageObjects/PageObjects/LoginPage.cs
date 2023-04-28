using System.Threading;
using OpenQA.Selenium;
using PageObjects.Helper;
using System.Configuration;



namespace BackitAuto;
public class LoginPage:MainMenuPageObject
{
    public LoginPage(IWebDriver driver):base(driver){}
    
    protected readonly By login = By.XPath("//span[text()= 'Login']");
    protected readonly By emailField = By.XPath($"//input[@type = 'email']");
    protected readonly By passwordField = By.XPath("//input[@type = 'password']");
    protected readonly By button = By.XPath("//buttoon[@type = 'submit']");
    public MainMenuPageObject DoLogin()
    {
        string _email = ConfigurationManager.AppSettings.Get("email");

        driver.FindElement(_accountButton).Click();
        driver.FindElement(accountListInHeader["Customer Login"]).Click();
        driver.FindElement(emailField).SendKeys("zolto_gunzenov@mail.ru");
        driver.FindElement(passwordField).SendKeys("12345678");
        driver.FindElement(login).Click();
        return new MainMenuPageObject(driver);
    }
}