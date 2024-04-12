using DoAnTotNghiep_Test_Website.Components;
using DoAnTotNghiep_Test_Website.TestCase;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Serialization;

namespace DoAnTotNghiep_Test_Website
{
    [TestClass]
    public class TestExecution
    {
        private readonly string baseUrl = "http://127.0.0.1:8000";
        HomePage homePage = new HomePage();
        RegisterPage registerPage = new RegisterPage();
        LoginPage loginPage = new LoginPage();
        CategoryPage categoryPage = new CategoryPage();
        ProductPage productPage = new ProductPage();
        AddToCartPage addToCartPage = new AddToCartPage();
        AddToCartInProductPage addToCartInProductPage = new AddToCartInProductPage();
        RemoveItemInCartPage removeItemInCartPage = new RemoveItemInCartPage();
        #region Check Home Page
        /// <summary>
        /// Check Home Page
        /// </summary>
        [TestMethod]
        public void CheckHomePage_TC001()
        {
            CorePage.SeleniumInit();
            homePage.GotoHomePage(baseUrl);
            CorePage.driver.Close();
        }
        #endregion
        #region Register

        /// <summary>
        /// Register
        /// </summary>
        [TestMethod]
        public void Registration_Success_TC001()
        {
            CorePage.SeleniumInit();
            registerPage.Register($"{baseUrl}/register", "Van", "Van123@gmail.com", "VanNgocNghech123");
            CorePage.driver.Close();
        }
        [TestMethod]
        public void Registration_Fail_TC002()
        {
            CorePage.SeleniumInit();
            registerPage.Register($"{baseUrl}/register", "Van", "Van123@gmail.com", "VanNgocNghech123");

            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(10));
            string actualText = wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='mt-3 list-disc list-inside text-sm text-red-600']/li"))).Text;
            Assert.AreEqual("The email has already been taken.", actualText);
            CorePage.driver.Close();
        }
        #endregion
        #region Login
        /// <summary>
        /// Login success
        /// </summary>
        [TestMethod]
        public void Login_Success_TC001()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(10));
            string actualText = wait.Until(driver => driver.FindElement(By.XPath("/html/body/header/div[1]/div/div/div[2]/div/div[2]/div/div/div[1]/span/button"))).Text;
            Assert.AreEqual("Van", actualText);
            CorePage.driver.Close();
        }
        /// <summary>
        /// Username fail
        /// </summary>
        [TestMethod]
        public void Login_Fail_Username_TC002()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van124@gmail.com", "VanNgocNghech123");
            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(10));
            string actualText = wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='mt-3 list-disc list-inside text-sm text-red-600']/li"))).Text;
            Assert.AreEqual("These credentials do not match our records.", actualText);
            CorePage.driver.Close();
        }
        /// <summary>
        /// Password Fail
        /// </summary>
        [TestMethod]
        public void Login_Fail_Password_TC003()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech");
            WebDriverWait wait = new WebDriverWait(CorePage.driver, TimeSpan.FromSeconds(10));
            string actualText = wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='mt-3 list-disc list-inside text-sm text-red-600']/li"))).Text;
            Assert.AreEqual("These credentials do not match our records.", actualText);
            CorePage.driver.Close();
        }
        #endregion
        #region Select Category

        [TestMethod]
        public void Select_Category_TC001()
        {
            CorePage.SeleniumInit(); 
            categoryPage.ChooseCategory($"{baseUrl}");
            
            CorePage.CloseSelenium();
        }
        #endregion
        #region Select Product

        [TestMethod]
        public void Select_Product_TC001()
        {
            CorePage.SeleniumInit();
            productPage.ChooseProduct($"{baseUrl}");
            CorePage.CloseSelenium();
        }
        #endregion
        #region Product Add To Card
        [TestMethod]
        public void Select_Product_Add_To_Card_TC001()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            addToCartPage.AddToCart($"{baseUrl}");
            CorePage.CloseSelenium();
        }
        #endregion
        #region Product Add To Card In Product Page
        [TestMethod]
        public void Select_Product_Add_To_Card_In_Product_Page_TC001()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            productPage.ChooseProduct($"{baseUrl}");
            addToCartInProductPage.AddToCartInProduct();
            CorePage.CloseSelenium();
        }
        #endregion
        #region Remove Item Proudct Card
        [TestMethod]
        public void Remove_Item_Product_Card_TC001()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            removeItemInCartPage.RemoveItemInCart();
            CorePage.CloseSelenium();
        }
        #endregion

    }
}