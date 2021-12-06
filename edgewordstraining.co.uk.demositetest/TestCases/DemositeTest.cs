using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace edgewordstraining.co.uk.demositetest.TestCases
{
    public class Tests
    {
        IWebDriver driver;
        string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }

        [Test]
        public void LoginTest()
        {
            driver.Url = baseUrl;

            //Login to your account
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.Id("username")).SendKeys("imanneupane@yahoo.com");
            driver.FindElement(By.Id("password")).SendKeys("Neupane@12345");
            driver.FindElement(By.CssSelector("button[name='login']")).Click();
            System.Console.WriteLine("You are now Logged in!");
            //Assert.Pass("Successfully logged in");

            //Add a item to your cart
            driver.FindElement(By.LinkText("Shop")).Click();
            driver.FindElement(By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/polo/']/img")).Click();
            driver.FindElement(By.Name("add-to-cart")).Click();
            
            //view cart and apply coupon
            driver.FindElement(By.LinkText("View cart")).Click();
            driver.FindElement(By.Id("coupon_code")).SendKeys("edgewords");
            driver.FindElement(By.Name("apply_coupon")).Click();

        }

    }
}