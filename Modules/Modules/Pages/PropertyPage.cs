using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modules.Pages
{
    class PropertyPage
    {
        public PropertyPage()
        {

            PageFactory.InitElements(Global.GlobalDefinition.driver, this);

            //Populate in collection
            //Global.ExcelLib.PopulateInCollection("demo.xlsx", "LoginPage");
            navigate();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[1]/div/div/input")]
        public IWebElement propertyName { get; set; }
        [FindsBy(How = How.Id, Using = "jobDescription")]
        public IWebElement description { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[3]/div/div/select")]
        public IWebElement propertyType { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[4]/div[2]/div/div/select")]
        public IWebElement propertyType2 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[5]/div/div/input")]
        public IWebElement targetRent { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[1]/div/div[6]/div/select")]
        public IWebElement rentType { get; set; }
        [FindsBy(How = How.Id, Using = "autocomplete0")]
        public IWebElement addressAutoComplete { get; set; }
        [FindsBy(How = How.Id, Using = "street_numbert")]
        public IWebElement streetNumber { get; set; }
        [FindsBy(How = How.Id, Using = "route")]
        public IWebElement streetName { get; set; }
        [FindsBy(How = How.Id, Using = "postal_code")]
        public IWebElement postalCode { get; set; }
        [FindsBy(How = How.Id, Using = "locality")]
        public IWebElement city { get; set; }
        [FindsBy(How = How.Id, Using = "sublocality_level_1")]
        public IWebElement suburb { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[3]/div/div[1]/div/input")]
        public IWebElement yearBuilt { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[3]/div/div[6]/div/input")]
        public IWebElement parkingSpace { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[1]/div/input")]
        public IWebElement purchasePrice { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[2]/div/input")]
        public IWebElement mortgage { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[3]/div/input")]
        public IWebElement repayment { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[4]/div[4]/div/select")]
        public IWebElement repaymentFrequency { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[5]/button[1]")]
        public IWebElement saveBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='propertyDetails']/div/div[5]/button[2]")]
        public IWebElement cancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='photoUpload']/div/div[3]/button[1]")]
        public IWebElement fileUploadSaveBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='photoUpload']/div/div[3]/button[2]")]
        public IWebElement fileUploadCancelBtn { get; set; }

        [FindsBy(How = How.Id, Using = "searchId")]
        public IWebElement searchTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='property-grid']/div/form/div/div/div/button/span[2]")]
        public IWebElement searchBtn { get; set; }


        private void navigate()
        {
            Global.GlobalDefinition.driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/PropertyOwners");
        }

        public void AddProperty()
        {
            var driver = Global.GlobalDefinition.driver;

            Global.GlobalDefinition.ActionButton(driver, "Id", "add-new-property");

            //Brief Info
            Thread.Sleep(500);
            new SelectElement(propertyType).SelectByIndex(1);
            new SelectElement(propertyType2).SelectByIndex(1);
            new SelectElement(rentType).SelectByIndex(1);
            propertyName.SendKeys("iPhone");
            description.SendKeys("Sina");
            description.SendKeys("250");
            Thread.Sleep(1000);
            //Address
            addressAutoComplete.SendKeys("238 botany road");
            Thread.Sleep(1000);
            Actions selectAddress = new Actions(driver);
            selectAddress.SendKeys(Keys.ArrowDown).Perform();
            selectAddress.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
            suburb.SendKeys("Golfland");

            //Property Detail
            yearBuilt.SendKeys("2007");
            parkingSpace.SendKeys("20");
            purchasePrice.SendKeys("500,000 NZD");
            mortgage.SendKeys("N/A");
            repayment.SendKeys("N/A");
            new SelectElement(repaymentFrequency).SelectByIndex(1);


            //Save button press
            saveBtn.Click();
            Thread.Sleep(500);
            fileUploadSaveBtn.Click();


            //Verify 
            if (verifyResult(driver, driver.Url, "iPhone", "238 botany road"))
            {
                Console.WriteLine("Add property successful");
            }

        }

        public bool verifyResult(IWebDriver driver, string url, string name, string address)
        {
            driver.Navigate().GoToUrl(url);
            bool result = false;

            driver.FindElement(By.Id("searchId")).SendKeys(name);
            driver.FindElement(By.XPath("//*[@id='property-grid']/div/form/div/div/div/button/span[2]")).Click();


            var searchResult = driver.FindElements(By.XPath("//*[@id='propList']"));
            Console.WriteLine(searchResult.Count());

            foreach (IWebElement line in searchResult)
            {
                if (line.FindElement(By.XPath("./tr/td[1]")).Text == name)
                { result = true; }
            }

            return result;
        }
    }
}
