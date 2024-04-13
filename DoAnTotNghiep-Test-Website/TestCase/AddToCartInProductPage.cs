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
            Step = Test.CreateNode("Add to Cart in Product");
            Scroll(8);
            Click(addToCartInProduct);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
