using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.Utils
{
    public static class Helpers
    {
        public static void WaitHelper(IWebDriver driver, int seconds, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(seconds));
            wait.Until(drv => drv.FindElement(locator).Displayed);
        }

        public static void HandleAlret(IWebDriver driver)
        {
            IAlert myalert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert encountered with text: " + myalert.Text);
            myalert.Accept();
        }


    }
}
