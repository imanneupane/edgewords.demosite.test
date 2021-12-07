using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class ApplyCoupon_POM
    {
        IWebDriver driver;

        public ApplyCoupon_POM(IWebDriver driver)
        {
            this.driver = driver;  
        }

        IWebElement viewCart => driver.FindElement(By.LinkText("View cart"));
        IWebElement Coupon => driver.FindElement(By.Id("coupon_code"));
        IWebElement ApplyButton => driver.FindElement(By.Name("apply_coupon"));

        public void ViewCart()
        {
            viewCart.Click();
        }
        public void CouponCode(String couponC)
        {
            Coupon.SendKeys(couponC);
        }
        public void ApplyCouponButton()
        {
            ApplyButton.Click();
        }
    }
}
