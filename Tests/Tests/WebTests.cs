using BackitAuto;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Common;

namespace Tests;

[TestFixture]
internal class WebFormTests:TestBase
{
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
    }

    [Test]
    public void DoTransfer()
    {
        var successfulText = "Search Tours in"+ " moscow";
        var message =
        MainMenu
            .SubmitToLoginCustomer()
            .DoLogin()
            .transferPageTo()
            .chooseCountries()
            .GetMessageFromTransfer();
        Assert.That(message, Is.EqualTo(successfulText.ToUpper()));
    }
}