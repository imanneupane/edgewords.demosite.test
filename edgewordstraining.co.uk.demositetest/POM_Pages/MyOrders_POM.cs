using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class MyOrders_POM
    {
        IWebDriver driver;

        public MyOrders_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement account => driver.FindElement(By.LinkText("My account"));
        IWebElement orders => driver.FindElement(By.LinkText("Orders"));
        IWebElement recentOrder => driver.FindElement(By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number"));

        public void GoToMyOrders()
        {
            account.Click();
            orders.Click();
        }
        public void CheckOrderNumber()
        {
            string orderNumber = recentOrder.Text;
            Assert.That(string.IsNullOrEmpty(orderNumber), Is.False, "Order number is Displayed!");
        }
    }
}
