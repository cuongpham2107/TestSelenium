using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class LoginPage: CorePage
    {

        By email = By.Name("email");
        By password = By.Name("password");
        By btnLogin = By.XPath("/html/body/main/section/div/div/div[2]/form/button");
        public LoginPage() { }
        public void Login(string url,string _email, string _password) 
        {
            Step = Test.CreateNode("Login");
            GoToUrl(url);
            Write(email, _email);
            Write(password, _password);
            Click(btnLogin);
        } 

    }
}
