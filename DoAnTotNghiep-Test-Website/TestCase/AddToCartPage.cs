using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class AddToCartPage : CorePage
    {
        By addToCart = By.XPath("/html/body/section[4]/div/div[2]/div[1]/div/div[1]/div[2]");
        public AddToCartPage() { }
        public void AddToCart(string url)
        {
            GoToUrl(url);
            try
            {
                long windowHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight;");
                long documentHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight;");

                long scrollDistance = documentHeight / 3;

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, arguments[0]);", scrollDistance);
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Click(addToCart);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
