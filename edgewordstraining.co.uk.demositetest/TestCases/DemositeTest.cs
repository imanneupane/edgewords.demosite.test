using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static edgewordstraining.co.uk.demositetest.Utils.Helpers;
using System;
using System.Threading;

namespace edgewordstraining.co.uk.demositetest.TestCases
{
    public class Tests : Utils.BaseClass
    {
        
        [Test]
        public void DemoTest()
        {
            driver.Url = baseUrl;

            driver.FindElement(By.LinkText("Dismiss")).Click();
            //Login to your account
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.Id("username")).SendKeys("imanneupane@yahoo.com");
            driver.FindElement(By.Id("password")).SendKeys("Neupane@12345");
            //Screenshot form
            TakeScreenShotElement(driver, "login form", By.Id("post-7"));
            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            //wait.Until(drv => drv.FindElement(By.Name("login")).Displayed);
            WaitHelper(driver, 10, By.Name("login"));
            driver.FindElement(By.Name("login")).Click();
            System.Console.WriteLine("You are now Logged in!");

            //Add a item to your cart
            WaitHelper(driver, 10, By.LinkText("Shop"));
            driver.FindElement(By.LinkText("Shop")).Click();
            driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/polo/']/img")).Click();
            driver.FindElement(By.Name("add-to-cart")).Click();
            
            //view cart and apply coupon
            driver.FindElement(By.LinkText("View cart")).Click();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.Name("apply_coupon")).Click();
            TakeScreenShot(driver, "couponapplied");

           
            
            //Check that the coupon takes off 15%
            string subtotal = driver.FindElement(By.XPath("/html//article[@id='post-5']/div[@class='entry-content']/div[@class='woocommerce']//table[@class='shop_table shop_table_responsive']//tr[@class='cart-subtotal']/td/span")).Text;
            decimal priceBeforeDiscount = Convert.ToDecimal(subtotal.Remove(0,1));
            decimal discount = (15m/100m) * priceBeforeDiscount;

            IJavaScriptExecutor scroll = (IJavaScriptExecutor)driver;
            scroll.ExecuteScript("window.scrollTo(0,8)");

            //Thread.Sleep(1000);
            WaitHelper(driver, 20, By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount"));
            string couponDiscount = driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text;
            //Assert.That(discount.ToString("0.00"), Is.EqualTo(couponDiscount.Remove(0,1)), "They are not equal");

            if (discount.ToString("0.00").Equals(couponDiscount.Remove(0,1)))
            {
                Console.WriteLine("Coupon takes 15% off");
            }
            else
            {
                Console.WriteLine("Coupon does not take 15% off");
                TakeScreenShotElement(driver, "CouponDiscount", By.ClassName("cart_totals"));
            }

            //Check that the total calculated is correct
            decimal priceAfterDiscount = priceBeforeDiscount - discount;
            string shipping = driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//tr[@class='shipping']/td/span")).Text;
            decimal shipCost = Convert.ToDecimal(shipping.Remove(0,1));
            decimal totalAmt = priceAfterDiscount + shipCost;
            string total = driver.FindElement(By.XPath("/html//article[@id='post-5']//div[@class='cart-collaterals']/div/table[@class='shop_table shop_table_responsive']//strong/span")).Text;

            if (totalAmt.ToString("0.00").Equals(total.Remove(0, 1)))
            {
                Console.WriteLine("The total amount is correct");
            }
            else
            {
                Console.WriteLine("The total amount is incorrect");
                TakeScreenShotElement(driver, "Cart Total", By.ClassName("order-total"));
            }

            //proceed to checkout and completing billing details
            driver.FindElement(By.PartialLinkText("Proceed to checkout")).Click();
            driver.FindElement(By.Id("")).SendKeys("");

            System.Console.WriteLine("Result: " + shipping);
        }

    }
}