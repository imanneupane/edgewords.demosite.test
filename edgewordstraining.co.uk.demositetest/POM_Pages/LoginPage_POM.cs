using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class LoginPage_POM
    {
        IWebDriver driver;
        public LoginPage_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement UsernameField => driver.FindElement(By.Id("username"));
        IWebElement PasswordField => driver.FindElement(By.Id("password"));
        IWebElement LoginButton => driver.FindElement(By.Name("login"));

        //Service methods

        public void Username(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }
        public void Password(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }
        public void LoginSubmit()
        {
            LoginButton.Click();
        }

        public void LoginExpected(string sUsername, string sPassword)
        {
            Username(sUsername);
            Password(sPassword);
            LoginSubmit();
        }
    }
}
