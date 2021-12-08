using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class LogOut_POM
    {
        IWebDriver driver;

        public LogOut_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement account => driver.FindElement(By.LinkText("My account"));
        IWebElement logOut => driver.FindElement(By.LinkText("Log out"));

        public void LogOut()
        {
            account.Click();
            logOut.Click(); 
        }
    }
}
