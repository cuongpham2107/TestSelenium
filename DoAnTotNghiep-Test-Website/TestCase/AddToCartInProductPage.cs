using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class AddToCartInProductPage : CorePage
    {
        By addToCartInProduct = By.Id("add_to_cart");
        public AddToCartInProductPage() { }
        public void AddToCartInProduct()
        {
            try
            {
                long windowHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight;");
                long documentHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight;");

                long scrollDistance = documentHeight / 8;

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, arguments[0]);", scrollDistance);
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Click(addToCartInProduct);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
