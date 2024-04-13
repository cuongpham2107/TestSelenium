using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class RegisterPage: CorePage
    {
        By name = By.Name("name");
        By email = By.Name("email");
        By password = By.Name("password");
        By password_confirmation = By.Name("password_confirmation");
        By register_btn = By.XPath("/html/body/main/section/div/div/div/form/div[5]/button");
        public RegisterPage() { }
        public void Register(string url, string _name, string _email, string _password)
        {
            Step = Test.CreateNode("Register");
            GoToUrl(url);
            Write(name, _name);
            Write(email, _email);
            Write(password, _password);
            Write(password_confirmation, _password);
            Click(register_btn);
        }
    }
}
