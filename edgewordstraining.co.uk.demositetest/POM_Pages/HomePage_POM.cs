using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class HomePage_POM
    {
        IWebDriver driver;

        public HomePage_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LoginItem => driver.FindElement(By.LinkText("My account"));
        
        //Service methods
        public void Login()
        {
            driver.FindElement(By.LinkText("Dismiss")).Click();
            LoginItem.Click();
        }
    }
}
