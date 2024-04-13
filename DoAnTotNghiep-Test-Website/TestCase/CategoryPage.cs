using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class CategoryPage : CorePage
    {
        By category = By.XPath("/html/body/section[3]/div/div/div/div[2]/div[1]/div/div[6]/div/div/h5/a");
        public CategoryPage() { }
        public void ChooseCategory( string url)
        {
            Step = Test.CreateNode("Category Page");
            GoToUrl(url);
            Scroll(7);
            Click(category);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
