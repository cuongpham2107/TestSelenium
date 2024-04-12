using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class HomePage : CorePage
    {
        By logo = By.ClassName("header__logo");
        public HomePage() { }
        public void GotoHomePage(string url) 
        {
            GoToUrl(url);
            Click(logo);
        }
    }
}
