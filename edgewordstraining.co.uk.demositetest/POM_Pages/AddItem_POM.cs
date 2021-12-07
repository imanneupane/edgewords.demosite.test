using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class AddItem_POM
    {
        IWebDriver driver;

        public AddItem_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement GoShop => driver.FindElement(By.LinkText("Shop"));
        IWebElement Product => driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/polo/']/img"));
        IWebElement AddToCart => driver.FindElement(By.Name("add-to-cart"));

        public AddItem_POM GoToShop()
        {
            GoShop.Click();
            return this;
        }
        public AddItem_POM SelectProduct()
        {
            Product.Click();
            return this;
        }
        public AddItem_POM AddItem()
        {
            AddToCart.Click();
            return this;
        }

        public void AddItemToCart()
        {
            GoToShop();
            SelectProduct();
            AddItem();
        }
    }
}
