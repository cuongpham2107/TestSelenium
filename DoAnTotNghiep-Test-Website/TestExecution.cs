using DoAnTotNghiep_Test_Website.Components;
using DoAnTotNghiep_Test_Website.TestCase;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Serialization;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace DoAnTotNghiep_Test_Website
{
    [TestClass]
    public class TestExecution
    {

        public TestContext instance;
        public TestContext TestContext
        {
            get { return instance; }
            set { instance = value; }
        }
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            string resultFile = Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
            CorePage.CreateReport(resultFile);
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            CorePage.extentReports.Flush();
        }
        [TestInitialize()]
        public void TestInit()
        {
          
            CorePage.Test = CorePage.extentReports.CreateTest(TestContext.TestName);
        }
        [TestCleanup()]
        public void TestCleanUp()
        {
           
        }

        private readonly string baseUrl = "http://127.0.0.1:8000";
        HomePage homePage = new HomePage();
        RegisterPage registerPage = new RegisterPage();
        LoginPage loginPage = new LoginPage();
        CategoryPage categoryPage = new CategoryPage();
        ProductPage productPage = new ProductPage();
        AddToCartPage addToCartPage = new AddToCartPage();
        AddToCartInProductPage addToCartInProductPage = new AddToCartInProductPage();
        RemoveItemInCartPage removeItemInCartPage = new RemoveItemInCartPage();
        AddAddressOrderPage addAddressOrderPage = new AddAddressOrderPage();
        PaymentOrderPage paymentOrderPage = new PaymentOrderPage();
        ContactPage contactPage = new ContactPage();
        #region Check Home Page
        /// <summary>
        /// Check Home Page
        /// </summary>
        [TestMethod]
        public void TC001_CheckHomePage()
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
        public void TC002_Registration_Success()
        {
            CorePage.SeleniumInit();
            registerPage.Register($"{baseUrl}/register", "Van", "Van123@gmail.com", "VanNgocNghech123");
            CorePage.driver.Close();
        }
        [TestMethod]
        public void TC003_Registration_Fail()
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
        public void TC004_Login_Success()
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
        public void TC004_Login_Fail_Username()
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
        public void TC005_Login_Fail_Password()
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
        public void TC006_Select_Category()
        {
            CorePage.SeleniumInit(); 
            categoryPage.ChooseCategory($"{baseUrl}");
            
            CorePage.CloseSelenium();
        }
        #endregion
        #region Select Product

        [TestMethod]
        public void TC007_Select_Product()
        {
            CorePage.SeleniumInit();
            productPage.ChooseProduct($"{baseUrl}");
            CorePage.CloseSelenium();
        }
        #endregion
        #region Product Add To Card
        [TestMethod]
        public void TC008_Select_Product_Add_To_Card()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            addToCartPage.AddToCart($"{baseUrl}");
            CorePage.CloseSelenium();
        }
        #endregion
        #region Product Add To Card In Product Page
        [TestMethod]
        public void TC009_Select_Product_Add_To_Card_In_Product_Page()
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
        public void TC010_Remove_Item_Product_Card()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            productPage.ChooseProduct($"{baseUrl}");
            addToCartInProductPage.AddToCartInProduct();
            removeItemInCartPage.RemoveItemInCart($"{baseUrl}/check-out");
            CorePage.CloseSelenium();
        }
        #endregion
        #region Add Address in Order
        [TestMethod]
        public void TC011_Add_Address_In_Order()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            productPage.ChooseProduct($"{baseUrl}");
            addToCartInProductPage.AddToCartInProduct();
            CorePage.driver.Url = $"{baseUrl}/check-out";
            addAddressOrderPage.ClickCheckOut();
            addAddressOrderPage.AddAddress();
            CorePage.CloseSelenium();
        }
        #endregion
        #region Payment in Order
        [TestMethod]
        public void TC012_Payment_In_Order()
        {
            CorePage.SeleniumInit();
            loginPage.Login($"{baseUrl}/login", "Van123@gmail.com", "VanNgocNghech123");
            productPage.ChooseProduct($"{baseUrl}");
            addToCartInProductPage.AddToCartInProduct();
            CorePage.driver.Url = $"{baseUrl}/check-out";
            addAddressOrderPage.ClickCheckOut();
            paymentOrderPage.PaymentOrder();
            CorePage.CloseSelenium();
        }
        #endregion
        #region Contact
        [TestMethod]
        public void TC013_SendContact()
        {
            CorePage.SeleniumInit();
            contactPage.Contact($"{baseUrl}/contact");
            CorePage.CloseSelenium();
        }
        #endregion
    }
}