using System.Configuration;
using System.Threading;
using BackitAuto;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BackitAuto;
public class DoLogin:MainMenuPageObject
{
    public DoLogin(IWebDriver driver):base(driver) {}

}