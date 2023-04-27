using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Channels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using PageObjects.Helper;

namespace BackitAuto;

[TestFixture]
public class MainMenuPageObject
{
    protected IWebDriver driver;
    public MainMenuPageObject(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected readonly By _accountButton = By.XPath("//button[@id='ACCOUNT']");
    protected readonly By _menuProfile = By.XPath("//ul[@class = 'dropdown-menu show']");
    public LoginPage SubmitToLoginCustomer()
    {
        driver.FindElement(_accountButton).Click();
        driver.FindElement(_menuProfile).Click();
        return new LoginPage(driver);
    }
    public VisaPage MoveToVisaPage()
    {
        driver.FindElement(headerListMenu["visa"]).Click();
        return new VisaPage(driver);
    }
    public Dictionary<string, By> accountListInHeader { get; private set; }= new Dictionary<string, By>()
    {
        { "Customer Login",   By.XPath("//a[text()= 'Customer Login']") },
        { "Customer Signup", By.XPath("//a[text()= 'Customer Signup']") },
        { "Agents Login", By.XPath("//a[text()= 'Agents Login']") },
        { "Agents SignUp", By.XPath("//a[text()= 'Agents Signup']") },
        { "Supplier Signup", By.XPath("//a[text()= 'Supplier Signup']") },
        { "Supplier Login", By.XPath("//a[text()= 'Supplier Login']") },
    };

    protected Dictionary<string, By> headerListMenu { get; private set; } = new Dictionary<string, By>()
    {
        {"hotels",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{1}]")},
        {"flights",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{2}]")},
        {"tours",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{3}]")},
        {"transfers",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{4}]")},
        {"visa",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{5}]")},
        {"blog",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{6}]")},
        {"offers",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{7}]")},
        {"company",By.XPath($"//ul[@style = 'padding-top:10px!important']/child::li[{8}]")},
    };
}

