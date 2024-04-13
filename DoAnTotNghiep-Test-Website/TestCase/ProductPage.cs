using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class ProductPage : CorePage
    {
        By product = By.XPath("/html/body/section[4]/div/div[2]/div[1]/div/div[2]/h6/a");
        public ProductPage() { }
        public void ChooseProduct(string url)
        {
            Step = Test.CreateNode("Product");
            GoToUrl(url);
            Scroll(3);
            Click(product);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
