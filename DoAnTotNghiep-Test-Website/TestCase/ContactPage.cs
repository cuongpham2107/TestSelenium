using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class ContactPage :CorePage
    {
        By name = By.XPath("/html/body/div[4]/div/form/div/div[1]/input");
        By email = By.XPath("/html/body/div[4]/div/form/div/div[2]/input");
        By message = By.XPath("/html/body/div[4]/div/form/div/div[3]/textarea");
        By btn = By.XPath("/html/body/div[4]/div/form/div/div[3]/button");
        public void Contact(string url)
        {
            Step = Test.CreateNode("Contact Page");
            GoToUrl(url);
            Scroll(4);
            Write(name, "Van");
            Thread.Sleep(1000);
            Write(email, "Van123@gmail.com");
            Thread.Sleep(1000);
            Write(message, "Xin Chao");
            Thread.Sleep(1000);
            Click(btn);
        }
    }
}
