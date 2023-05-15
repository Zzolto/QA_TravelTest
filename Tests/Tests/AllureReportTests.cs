using NUnit.Allure.Core;
using NUnit.Framework;
using Tests.Common;
using NUnit.Allure.Attributes;

namespace Tests;

[AllureNUnit]
internal class AllureReportTests:TestBase
{
    [Test]
    [AllureDescription("Test 1st")]
    [AllureIssue("Issue-1")]
    [AllureTms("TMS-1")]
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
    
    [Test]
    public void SearchTours()
    {
        var message =
            MainMenu
                .SubmitToLoginCustomer()
                .DoLogin()
                .redirectToTours()
                .findTours();
    }
}