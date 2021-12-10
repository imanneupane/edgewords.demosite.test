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
            //Scroll page
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
            Coupon_POM applycoupon = new Coupon_POM(driver);
            applycoupon.ViewCart();
            applycoupon.CouponCode("edgewords");
            applycoupon.ApplyCouponButton();
            TakeScreenShot(driver, "couponapplied");

            //Check that the coupon takes off 15%
            //Thread.Sleep(1000);     
            WaitHelper(driver, 20, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
            try
            {
                applycoupon.CheckCoupon();
                //Assert.That(discount.ToString("0.00"), Is.EqualTo(couponDiscount.Remove(0, 1)), "They are not equal");
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
                Console.WriteLine("Coupon does not take 15% off");
            }

            //Check that the total calculated is correct
            try
            {
                applycoupon.CheckTotal();
                //Assert.That(totalAmt.ToString("0.00"),Is.EqualTo(total.Remove(0, 1)), "They are not equal");
            }
            catch (AssertionException)
            {
                //Thread.Sleep(1000);
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
                Console.WriteLine("The total amount is incorrect");
            }

            //proceed to checkout and completing billing details
            WaitHelper(driver, 10, By.PartialLinkText("Proceed to checkout"));
            Thread.Sleep(3000);
            driver.FindElement(By.PartialLinkText("Proceed to checkout")).Click();
            Console.WriteLine("You are in Checkout");

            WaitHelper(driver, 10, By.PartialLinkText("Click here to enter your code"));

            //Completing Billing Details
            BillingDetail_POM billsDetail = new BillingDetail_POM(driver);
            billsDetail.BillingForm("Nami", "Rai", "nFocus", "United Kingdom", "101 Star Road", "Ashford", "Kent", "TN3 5JB", "021540231", "namirai@yahoo.com");
            Thread.Sleep(1000);
            billsDetail.PlaceOrder();
            try
            {
                WaitHelper(driver, 20, By.XPath("//*[text()='Order received']"));
            }
            catch (StaleElementReferenceException)
            {
                Console.WriteLine("Not in the right page");
            }
            
            Console.WriteLine("You are in Billing Details");

            //Thread.Sleep(1000);
            TakeScreenShotElement(driver, "Order Number", By.XPath("/html//article[@id='post-6']//ul/li[1]"));

            //Check my order is placed
            MyOrders_POM orders = new MyOrders_POM(driver);
            orders.GoToMyOrders();
            try
            {
                orders.CheckOrderNumber();
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "MyOrders", By.Id("post-7"));
                Console.WriteLine("Recent Order was not Placed");
            }

            //Log out of the Account
            LogOut_POM logout = new LogOut_POM(driver);
            logout.LogOut();
            Console.WriteLine("You are Logged Out!");
        }


        /*
        [Test]
        public void Billing()
        {
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
            //Login to your account
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.LinkText("Dismiss")).Click();
            LoginPage_POM login = new LoginPage_POM(driver);
            WaitHelper(driver, 10, By.Name("login"));
            login.LoginExpected("imanneupane@yahoo.com", "Neupane@12345");
            System.Console.WriteLine("You are now Logged in!");

            driver.FindElement(By.LinkText("Shop")).Click();
            driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/cap/']/img")).Click();
            driver.FindElement(By.XPath("//main[@id='main']//form[@action='https://www.edgewordstraining.co.uk/demo-site/product/cap/']/button[@name='add-to-cart']")).Click();
            driver.FindElement(By.CssSelector("div[role='alert'] > .button.wc-forward")).Click();

            driver.FindElement(By.Name("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.Name("apply_coupon")).Click();
            BillingDetail_POM billsDetail = new BillingDetail_POM(driver);
            driver.FindElement(By.PartialLinkText("Proceed")).Click();
            billsDetail.BillingForm("Nami", "Rai", "nFocus", "United Kingdom", "101 Star Road", "Ashford", "Kent", "TN3 5JB", "021540231", "namirai@yahoo.com");
            //WaitHelper(driver, 10, By.Id("place_order"));
            Thread.Sleep(1000);
            billsDetail.PlaceOrder();

            //Capturing the order number
            Thread.Sleep(1000);
            //WaitHelper(driver, 10, By.XPath("/html//article[@id='post-6']//ul/li[1]"));
            TakeScreenShotElement(driver, "Order Number", By.XPath("/html//article[@id='post-6']//ul/li[1]"));

            //Check my orders
            MyOrders_POM orders = new MyOrders_POM(driver);
            orders.GoToMyOrders();
            try
            {
                orders.CheckOrderNumber();
            }
            catch (AssertionException)
            {
                TakeScreenShotElement(driver, "MyOrders", By.Id("post-7"));
                Console.WriteLine("Recent Order was not Placed");
            }

            //Log out of the Account
            LogOut_POM logout = new LogOut_POM(driver);
            logout.LogOut();
            Console.WriteLine("You are Logged Out!");
        }
        */
    }
}