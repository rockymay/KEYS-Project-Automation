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
    class AdminPage
    {
        public AdminPage()  //Initiate
        {

            PageFactory.InitElements(Global.GlobalDefinition.driver, this);


            //Populate in collection
            //Global.ExcelLib.PopulateInCollection("demo.xlsx", "LoginPage");

        }
        #region  Construct Element
      
        [FindsBy(How = How.Id, Using = "searchId")]
        public IWebElement searchTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/section[2]/div/form/div/div/div/button/span/span")]
        public IWebElement searchBtn { get; set; }

        #endregion

        public void navigate()
        {
            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Navigate Start ");

            //Global.GlobalDefinition.driver.FindElement(By.XPath("//*[@id='leftsidebar']/div[2]/div/ul/li[3]/a/span")).Click();

            Global.GlobalDefinition.driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/Admin/Home");

        }

        public void Sorting()
        {


            var driver = Global.GlobalDefinition.driver;

            driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/Admin/Home");


            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Click on sorting ");
            var heading = driver.FindElements(By.XPath("//*[@id='listUserTable']/thead/tr/th"));
            //*[@id="listUserTable"]/thead/tr/th[1]/span/a
            //*[@id="listUserTable"]/thead/tr/th[1]/span/a
            //*[@id="listUserTable"]/thead/tr/th[2]/a
            //*[@id="listUserTable"]/thead/tr/th[3]/a
            foreach (var item in heading)
            {
                //FindElement(By.XPath())
                item.Click();
                Thread.Sleep(500);
            }

            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Admin Sorting Pass ");
        }

        public void CheckActionButton()
        {

            var driver = Global.GlobalDefinition.driver;
            driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/Admin/Home");




            //Get page number
            //var pageMessage = driver.FindElement(By.XPath("//*[@id='listUserTable']/div/ul/li[1]/a")).Text;
            //int startIndex = pageMessage.IndexOf("of") + 2;
            //int endIndex = pageMessage.IndexOf(".");
            //int pageNumber = int.Parse(pageMessage.Substring(startIndex, endIndex - startIndex));
            //Console.WriteLine(pageNumber);

            string currentURL = driver.Url;

            for (int i = 2; i < 10; i++)
            {
                ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Button Check on Page: " + i);

                string url = "http://new-keys.azurewebsites.net/Admin/Home?page=" + i;

                driver.Navigate().GoToUrl(url);

                var propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));

                foreach (var item in propLists)
                {
                    //Click on Action button and Click away.
                    item.FindElements(By.XPath("./td")).Last().FindElement(By.XPath("./div/button")).Click();

                    item.FindElement(By.XPath("./td[1]")).Click();

                }

            }
            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Button Check Pass");

        }

        public void ActionDetailViewButton()
        {
            var driver = Global.GlobalDefinition.driver;

            driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/Admin/Home");

            var propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));


            for (int i = 0; i < propLists.Count(); i++)
            {

                //
                ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Action Button Clicked on line: " + (i + 1));
                propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));


                //Click on Action button and Click away.
                propLists[i].FindElement(By.XPath("./td[4]/div/button")).Click();


                //Get action detail button
                var actionDetailBtn = propLists[i].FindElements(By.XPath("./td[4]/div/ul/li"));
                Console.WriteLine("No. Detail Button: " + actionDetailBtn.Count());
                for (int j = 0; j < actionDetailBtn.Count(); j++)

                {
                    Console.WriteLine(actionDetailBtn[j].Text + "+END");

                    if (actionDetailBtn[j].Text == "DETAILS")
                    {
                        actionDetailBtn[j].Click();
                        //Go back to Index
                        driver.FindElement(By.XPath("//*[@id='userDetails']/div/div[3]/button")).Click();

                        break;
                    }

                }

                ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Action View Detail Pass");

            }
        }

        public void ActionDetailEditButton()
        {
            var driver = Global.GlobalDefinition.driver;

            driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/Admin/Home");

            var propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));

            for (int i = 0; i < propLists.Count(); i++)
            {


                //Define testlog for Edit
                ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Action Button Clicked on line: " + (i + 1));

                propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));


                //Click on Action button and Click away.
                propLists[i].FindElement(By.XPath("./td[4]/div/button")).Click();

                //Get action detail button
                var actionDetailBtn = propLists[i].FindElements(By.XPath("./td[4]/div/ul/li"));
                Console.WriteLine("No. Detail Button: " + actionDetailBtn.Count());
                for (int j = 0; j < actionDetailBtn.Count(); j++)

                {
                    if (actionDetailBtn[j].Text == "EDIT")
                    {
                        actionDetailBtn[j].Click();
                        //Go back to Index
                        Thread.Sleep(500);
                        ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Action: Cancel");
                        driver.FindElement(By.XPath("//*[@id='userEdit']/div[3]/button[2]")).Click();
                        Thread.Sleep(500);
                    }
                }
            }
            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Action Edit-Cancel Pass");
        }

        public void ActionDetailDeleteButton()
        {
            var driver = Global.GlobalDefinition.driver;


            driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net/Admin/Home");


            var propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));

            for (int i = 0; i < propLists.Count(); i++)
            {
                //Define testlog for Edit
                ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Action Button Clicked on line: " + (i + 1));

                propLists = driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr"));

                //Click on Action button and Click away.
                propLists[i].FindElement(By.XPath("./td[4]/div/button")).Click();

                //Get action detail button
                var actionDetailBtn = propLists[i].FindElements(By.XPath("./td[4]/div/ul/li"));
                Console.WriteLine("No. Detail Button: " + actionDetailBtn.Count());
                for (int j = 0; j < actionDetailBtn.Count(); j++)

                {
                    Console.WriteLine(actionDetailBtn[j].Text + "+END");

                    if (actionDetailBtn[j].Text == "DELETE")
                    {
                        actionDetailBtn[j].Click();
                        //Go back to Index
                        Thread.Sleep(500);
                        driver.FindElement(By.XPath("//*[@id='userDelete']/div/div[3]/button[2]")).Click();
                        Thread.Sleep(500);

                    }

                }

            }
            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Action Delete-Cancel Pass");
        }

        public void SearchFunction()
        {
            navigate();

            var driver = Global.GlobalDefinition.driver;


            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Click on UI");
            searchTextBox.SendKeys("test");
            searchBtn.Click();

            //Get number of results
            Console.WriteLine("Search result number for current page: " + driver.FindElements(By.XPath("//*[@id='listUserTable']/tbody/tr")).Count());
            

            ModulesTest.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Search Func Pass");

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
