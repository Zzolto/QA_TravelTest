using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Utils.Reports
{
    public class ExtentReports
    {
        private static ExtentReports _extentReports;
        private static ExtentTest _extentTest;
        
        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

            if (_extentReports == null)
            {
                Directory.CreateDirectory(path);
                _extentReports = new ExtentReports();

                var htmlReporter = new ExtentHtmlReporter(path);
                

            }
            return _extentReports;
        }

        public static void LogInfo(string info)
        {
            _extentTest.Info(info);
        }
    }
}