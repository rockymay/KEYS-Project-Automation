using Modules.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    class Program
    {
        static void Main(string[] args)
        {

           

        }
    }


    [TestFixture]
    class ButtonTest
    {
        //public static ExtentReports reports;
        //public static ExtentTest test;

        [SetUp]
        public void Login()
        {
            ////Define report
            //reports = new ExtentReports(@"C:/Users/rockymay/Documents/Visual%20Studio%202015/Projects/InterfaceButton/InterfaceButton/bin/Debug/Test.html", false, DisplayOrder.NewestFirst);

            //Define Browser and Open 

            Global.GlobalDefinition.driver = new ChromeDriver();

            LoginPages loginObj = new LoginPages();
            loginObj.LoginStep();

            //Take screenshots after login
            Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinition.driver, "LoginSuccessful");


        }

        [Test]
        public void AddPropertyTest()
        {
            //test = reports.StartTest("Add");

            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailDeleteButton();
        }


        [Test]
        public void CheckActionButtonTest()
        {
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.CheckActionButton();
        }


        [Test]
        public void ActionDetailViewButton()
        {
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailViewButton();
        }


        [Test]
        public void ActionDetailEditButton()
        {
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailEditButton();
        }


        [Test]
        public void ActionDetailDeleteButton()
        {
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailDeleteButton();

        }


        [TearDown]

        public void Closing()
        {
            Environment.Exit(0);
        }

    }


}
