using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.Utils
{
    public class BaseClass
    {
        public IWebDriver driver;
        public string baseUrl = "https://www.edgewordstraining.co.uk/demo-site/";

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
    }
}
