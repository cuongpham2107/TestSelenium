using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace DoAnTotNghiep_Test_Website.Components
{
    public class CorePage
    {
        public static IWebDriver driver;
        public TestContext testContext;
        public static ExtentReports extentReports;
        public static ExtentTest Test;
        public static ExtentTest Step;
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
                driver.Dispose();
                driver.Quit();
            }
        }
        public static void CreateReport(string filename) 
        {
            extentReports = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(@filename);
            extentReports.AttachReporter(sparkReporter);
        }
        public static void TakeScreenShot(Status status, string stepDetail)
        {
            string path = Path.Combine(Environment.CurrentDirectory,"images");
           
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("Thư mục đã được tạo.");
                }
                else
                {
                    Console.WriteLine("Thư mục đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            string pathImage = Path.Combine(path, DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(pathImage, screenshot.AsByteArray);
            Step.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(pathImage).Build());
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
        public void Write(By by,string value, string stepDetail = "N/A")
        {
            try
            {
                if (driver != null)
                {
                    driver.FindElement(by).SendKeys(value);
                    TakeScreenShot(Status.Pass,stepDetail);
                }
            }
            catch(Exception ex)
            {
                TakeScreenShot(Status.Fail, "FAILED: " + stepDetail + ex);
            }
            
           
        }
        /// <summary>
        /// Click in element
        /// </summary>
        /// <param name="by">Element</param>
        public void Click(By by,string stepDetail = "N/A") 
        {
            
            try
            {
                if (driver != null)
                {
                    driver.FindElement(by).Click();
                    TakeScreenShot(Status.Pass, stepDetail);
                }
            }
            catch (Exception ex)
            {
                TakeScreenShot(Status.Fail, "FAILED: " + stepDetail + ex);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        public void Clear(By by)
        {
            if (driver != null)
            {
                driver.FindElement(by).Clear();
            }
           
        }
        public void SelectElement(By by,int index = 0)
        {
            if (driver != null)
            {
                IWebElement dropdown =  driver.FindElement(by);
                SelectElement select = new SelectElement(dropdown);
                if(index == 0)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1, 11);
                    select.SelectByIndex(randomNumber);
                }
                else
                {
                    select.SelectByIndex(index);
                }
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Scroll(int scroll)
        {
            try
            {
                long windowHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight;");
                long documentHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight;");

                long scrollDistance = documentHeight / scroll;

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, arguments[0]);", scrollDistance);
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
