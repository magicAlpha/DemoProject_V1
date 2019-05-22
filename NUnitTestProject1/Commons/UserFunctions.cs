using NUnitFramework.Utils;
using OpenQA.Selenium;

namespace NUnitFramework.Common
{

    public class UserFunctions
    {
        private ProgressLogger logger;
        static Config data;
        public static IWebDriver driver;
     
       

        public UserFunctions(ProgressLogger logger)
        {
            this.logger = logger;
            data = ConfigManager.Instance;
            driver = NUnitWebDriver.GetInstanceOfNUnitWebDriver();
        }

        








    }
}