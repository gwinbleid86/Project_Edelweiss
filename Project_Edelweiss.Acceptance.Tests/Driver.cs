using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Project_Edelweiss.Acceptance.Tests
{
    public class Driver
    {
        public static IWebDriver driver;

        public static IWebDriver GetDriver
        {
            get
            {
                if(driver == null) driver = new ChromeDriver();
                return driver;
            }
        }
    }
}
