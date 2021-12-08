using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edgewordstraining.co.uk.demositetest.POM_Pages
{
    public class BillingDetail_POM
    {
        IWebDriver driver;

        public BillingDetail_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement fName => driver.FindElement(By.Id("billing_first_name"));
        IWebElement lName => driver.FindElement(By.Id("billing_last_name"));
        IWebElement comName => driver.FindElement(By.Id("billing_company"));
        IWebElement countryS => driver.FindElement(By.Id("select2-billing_country-container"));
        IWebElement inputC => driver.FindElement(By.ClassName("select2-search__field"));
        IWebElement fAddress => driver.FindElement(By.Id("billing_address_1"));
        IWebElement sAddress => driver.FindElement(By.Id("billing_address_2"));
        IWebElement tName => driver.FindElement(By.Id("billing_city"));
        IWebElement staName => driver.FindElement(By.Id("billing_state"));
        IWebElement pCode => driver.FindElement(By.Id("billing_postcode"));
        IWebElement pNum => driver.FindElement(By.Id("billing_phone"));
        IWebElement emailAd => driver.FindElement(By.Id("billing_email"));
        IWebElement note => driver.FindElement(By.Id("order_comments"));
        IWebElement selectPay => driver.FindElement(By.XPath("//div[@id='payment']/ul//label[1]"));
        IWebElement pOrder => driver.FindElement(By.Id("place_order"));

        public void FirstName(string name)
        {
            fName.Clear();
            fName.SendKeys(name);
        }
        public void LastName(string Sname)
        {
            lName.Clear();
            lName.SendKeys(Sname);
        }
        public void CompanyName(string coName)
        {
            comName.Clear();
            comName.SendKeys(coName);
        }
        public void SelectCountry(string country)
        {
            countryS.Click();
            inputC.Clear();
            inputC.SendKeys(country + Keys.Enter);
        }
        public void Address1(string firstAdd)
        {
            fAddress.Clear();
            fAddress.SendKeys(firstAdd);
        }
        public void Address2(string secondAdd)
        {
            sAddress.Clear();
            sAddress.SendKeys(secondAdd);
        }
        public void TownCity(string cityName)
        {
            tName.Clear();
            tName.SendKeys(cityName);
        }
        public void County(string countName)
        {
            staName.Clear();
            staName.SendKeys(countName);
        }
        public void PostCode(string postC)
        {
            pCode.Clear();
            pCode.SendKeys(postC);
        }
        public void PhoneNo(string pNumber)
        {
            pNum.Clear();   
            pNum.SendKeys(pNumber);
        }
        public void Email(string mail)
        {
            emailAd.Clear();
            emailAd.SendKeys(mail);
        }
        public void Comment(string comm)
        {
            note.Clear();
            note.SendKeys(comm);
        }
        public void SelectPayment()
        {
            selectPay.Click();
        }
        public void PlaceOrder()
        {
            pOrder.Click();
        }

        public void BillingForm(string firstName, string surName, string company, string country, string address, string town, string county, string postcode, string phone, string email)
        {
            FirstName(firstName);
            LastName(surName);
            CompanyName(company);
            SelectCountry(country);
            Address1(address);
            TownCity(town);
            County(county);
            PostCode(postcode);
            PhoneNo(phone);
            Email(email);
        }
    }
}
