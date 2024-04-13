using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class PaymentOrderPage : CorePage
    {
        By chooseAddress = By.Name("address_id");
        By payment = By.Id("COD");
        By btnPayment = By.XPath("/html/body/section[3]/div/div/form/div/div[2]/div/button");
        public PaymentOrderPage() { }
        public void PaymentOrder() 
        {
            Step = Test.CreateNode("Payment Order");
            SelectElement(chooseAddress,1);
            Thread.Sleep(1000);
            Click(payment);
            Thread.Sleep(1000);
            Click(btnPayment);
            Thread.Sleep(5000);

        }
    }
}
