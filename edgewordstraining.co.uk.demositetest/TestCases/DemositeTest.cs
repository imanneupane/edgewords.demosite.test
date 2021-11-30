using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

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
            driver.Quit();
        }

        [Test]
        public void LoginTest()
        {
            driver.Url = baseUrl;
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.Id("username")).SendKeys("imanneupane@yahoo.com");
            driver.FindElement(By.Id("password")).SendKeys("Neupane@12345");
            driver.FindElement(By.CssSelector("button[name='login']")).Click();
            System.Console.WriteLine("You are now Logged in!");
            Assert.Pass("Successfully logged in");
        }


    }
}