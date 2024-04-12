using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class RemoveItemInCartPage : CorePage
    {
        By iconCart = By.ClassName("my-cart");
        public RemoveItemInCartPage() { }
        public void RemoveItemInCart()
        {
            Click(iconCart);
            Thread.Sleep(5000);
        }
    }
}
