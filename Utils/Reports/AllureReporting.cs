using NUnit.Allure.Attributes;

namespace Utils
{
    public class AllureReporting
    {
        [AllureStep("{0}")]
        public void LogStep(string message)
        {
            
        }
    }
}