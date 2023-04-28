using BackitAuto;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Common;

namespace Tests;

internal class WebFormTests:TestBase
{
    private IWebDriver _driver;
    private SubmissionFormPageObject _targetPageObject;
    [Test]
    public void DoByCustom()
    {
        var successfulText = "Your visa form has been submitted";
        var message = 
            MainMenu
                .SubmitToLoginCustomer()
                .DoLogin()
                .MoveToVisaPage()
                .ChooseCountryFrom()
                .TargetPage()
                .GetMessage();
        Assert.That(message, Is.EqualTo(successfulText));
        MainMenu
            .transferPageTo()
            .chooseCountries();
    }

    
    public void DoTransfer()
    {
        MainMenu
            .transferPageTo();
    }
    
}