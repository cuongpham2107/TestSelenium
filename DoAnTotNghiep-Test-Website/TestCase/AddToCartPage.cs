﻿using DoAnTotNghiep_Test_Website.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep_Test_Website.TestCase
{
    public class AddToCartPage : CorePage
    {
        By addToCart = By.XPath("/html/body/section[4]/div/div[2]/div[1]/div/div[1]/div[2]");
        public AddToCartPage() { }
        public void AddToCart(string url)
        {
            Step = Test.CreateNode("Add to Cart");
            GoToUrl(url);
            Scroll(3);
            Click(addToCart);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
