using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DoAnTotNghiep_Test_Website.Components
{
    public class CorePage
    {
        public static IWebDriver driver;
        public static IWebDriver SeleniumInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver chromeDriver = new ChromeDriver(options);
            driver = chromeDriver;
            return driver;
        }
        public static void CloseSelenium()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }
        /// <summary>
        /// Open Url 
        /// </summary>
        /// <param name="url"></param>
        public void GoToUrl(string url)
        {
            if (driver != null)
            {
                driver.Url = url;
            }
           
        }
        /// <summary>
        /// Send Key Element
        /// </summary>
        /// <param name="by">Element</param>
        /// <param name="value">Value</param>
        public void Write(By by,string value)
        {
            if (driver != null)
            {
                driver.FindElement(by).SendKeys(value);
            }
           
        }
        /// <summary>
        /// Click in element
        /// </summary>
        /// <param name="by">Element</param>
        public void Click(By by) 
        {
            if (driver != null)
            {
                driver.FindElement(by).Click();
            }
           
        }
        public void Clear(By by)
        {
            if (driver != null)
            {
                driver.FindElement(by).Clear();
            }
           
        }
    }
}
