using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static edgewordstraining.co.uk.demositetest.Utils.Helpers;
using edgewordstraining.co.uk.demositetest.POM_Pages;

namespace edgewordstraining.co.uk.demositetest.TestCases
{
    public class Tests : Utils.BaseClass
    {
        
        [Test, Order(1)]
        public void DemoTest()
        {
            driver.Url = baseUrl;
            //Go to login page
            HomePage_POM home = new HomePage_POM(driver);
            home.Login();

            //Login to your account
            LoginPage_POM login = new LoginPage_POM(driver);
            WaitHelper(driver, 10, By.Name("login"));
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            //Screenshot form
            TakeScreenShotElement(driver, "login form", By.Id("post-7"));
            System.Console.WriteLine("You are now Logged in!");

            //Add a item to your cart
            AddItem_POM additem = new AddItem_POM(driver);
            additem.GoToShop().SelectProduct().AddItem();
            //additem.AddItemToCart();
      
            //view cart and apply coupon
            ApplyCoupon_POM applycoupon = new ApplyCoupon_POM(driver);
            applycoupon.ViewCart();
            applycoupon.CouponCode("edgewords");
            applycoupon.ApplyCouponButton();
            TakeScreenShot(driver, "couponapplied");
            
            //Check that the coupon takes off 15%
            string subtotal = driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).Text;
            decimal priceBeforeDiscount = Convert.ToDecimal(subtotal.Remove(0,1));
            decimal discount = (15m/100m) * priceBeforeDiscount;

            IJavaScriptExecutor scroll = (IJavaScriptExecutor)driver;
            _ = scroll.ExecuteScript("window.scrollTo(0,8)");

            //Thread.Sleep(1000);
            WaitHelper(driver, 20, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
            string couponDiscount = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            
            try
            {
                Assert.That(discount.ToString("0.00"), Is.EqualTo(couponDiscount.Remove(0, 1)), "They are not equal");
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
                Console.WriteLine("Coupon does not take 15% off");
            }
            
            /*
            if (discount.ToString("0.00").Equals(couponDiscount.Remove(0,1)))
            {
                Console.WriteLine("Coupon takes 15% off");
            }
            else
            {
                Console.WriteLine("Coupon does not take 15% off");
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
            }
            */

            //Check that the total calculated is correct
            decimal priceAfterDiscount = priceBeforeDiscount - discount;
            string shipping = driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//tr[@class='shipping']/td/span")).Text;
            decimal shipCost = Convert.ToDecimal(shipping.Remove(0,1));
            decimal totalAmt = priceAfterDiscount + shipCost;
            string total = driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//strong/span")).Text;

            try
            {
                Assert.That(totalAmt.ToString("0.00"),Is.EqualTo(total.Remove(0, 1)), "They are not equal");
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
                Console.WriteLine("The total amount is incorrect");
            }

            /*
            if (totalAmt.ToString("0.00").Equals(total.Remove(0, 1)))
            {
                Console.WriteLine("The total amount is correct");
            }
            else
            {
                Console.WriteLine("The total amount is incorrect");
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
            }
            */

            //proceed to checkout and completing billing details
            //driver.FindElement(By.PartialLinkText("Proceed to checkout")).Click();
            //driver.FindElement(By.Id("")).SendKeys("");
            
            System.Console.WriteLine("Result: " + shipping);
            
        }

        [Test, Order(2)]
        public void AddItemTest()
        {
            driver.Url = baseUrl;
           
        }

    }
}