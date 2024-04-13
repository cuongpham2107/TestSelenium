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
        By iconRemoveCart = By.XPath("/html/body/section[3]/div/div[1]/div/div/table/tbody/tr[1]/td[5]/div[1]");
        public RemoveItemInCartPage() { }
        public void RemoveItemInCart(string url)
        {
            Step = Test.CreateNode("Remove Item Cart");
            GoToUrl(url);
            Click(iconRemoveCart);
            Thread.Sleep(2000);
        }
    }
}
