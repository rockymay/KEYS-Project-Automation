using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Pages
{
    class LoginPages
    {
        public LoginPages()
        {
            PageFactory.InitElements(Global.GlobalDefinition.driver, this);

            //Populate in collection
            //Global.ExcelLib.PopulateInCollection("demo.xlsx", "LoginPage");

        }


        public void LoginStep()
        {
            var driver = Global.GlobalDefinition.driver;
            //Populate in collection
            //Global.ExcelLib.PopulateInCollection("demo.xlsx", "LoginPage");

            //Define IWebDriver
            driver.Navigate().GoToUrl("http://new-keys.azurewebsites.net");
            driver.Manage().Window.Maximize();

            Global.GlobalDefinition.TextBox(driver, "Id", "UserName", "rockystx@gmail.com");
            Global.GlobalDefinition.TextBox(driver, "Id", "Password", "rocky1217");
            Global.GlobalDefinition.ActionButton(driver,"XPath", "//*[@id='sign_in']/div[4]/div[2]/button");


            try
            {
                string message = driver.FindElement(By.XPath("/html/body/div/section[2]/div/div[1]/h2")).Text;
                if (message == "Dashboard")
                {
                    Console.WriteLine("Login successful.");
                }
            }
            catch { Console.WriteLine("Login failed"); }


            
        }
        public void quit()
        {
            var driver = Global.GlobalDefinition.driver;
            driver.Close();
        }

    }
}
