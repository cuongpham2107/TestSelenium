using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class AddAddressOrderPage : CorePage
    {
        By btnCheckOut = By.XPath("/html/body/section[3]/div/div[2]/div[2]/div/a");
        By addNewAddress = By.XPath("/html/body/section[3]/div/div/form/div/div[1]/div/div[1]/div/div/button");
        By inputName = By.Name("name");
        By inputCustomerName = By.Name("customer_name");
        By inputPhone = By.Name("phone");
        By selectProvince = By.Name("province");
        By selectDistrict = By.Name("district");
        By selectWard = By.Name("ward");
        By address = By.Name("address");
        By email = By.Name("email");
        By btnAdd = By.Name("add");

        public AddAddressOrderPage() { }
        public void ClickCheckOut()
        {
            Step = Test.CreateNode("Click Check Out");
            Scroll(4);
            Click(btnCheckOut);
            Thread.Sleep(1000);
            
        }
        public void AddAddress()
        {
            Step = Test.CreateNode("Add Address");
            Click(addNewAddress);
            Thread.Sleep(1000);
            Write(inputName, "Van");
            Thread.Sleep(1000);
            Write(inputCustomerName, "Van Ngoc Nghech");
            Thread.Sleep(1000);
            Write(inputPhone, "012345678");
            Thread.Sleep(1000);
            SelectElement(selectProvince);
            Thread.Sleep(1000);
            SelectElement(selectDistrict);
            Thread.Sleep(1000);
            SelectElement(selectWard);
            Thread.Sleep(1000);
            Write(address, "Số 1");
            Thread.Sleep(1000);
            Write(email, "Van123@gmail.com");
            Thread.Sleep(1000);
            Click(btnAdd);
        }
    }
}
