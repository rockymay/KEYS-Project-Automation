using Modules.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
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
    public class PropertyModuleTest
    {
        public static ExtentReports reports;
        public static ExtentTest test;

        [SetUp]
        public void Login()
        {
            //Define report
            string currentFolder = @"C:\Users\rockymay\Source\Repos\KEYS-Project";
            string reportFolder = currentFolder + "\\" + "Test.html";
            reports = new ExtentReports(reportFolder, false, DisplayOrder.OldestFirst);  //, false, DisplayOrder.NewestFirst

            //Define Browser and Open d
            Global.GlobalDefinition.driver = new ChromeDriver();

            LoginPages loginObj = new LoginPages();
            loginObj.LoginStep();

            //Take screenshots after login
            //Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinition.driver, "LoginSuccessful");


        }

        [Test]
        public void PropertyAddPropertyTest()
        {
            test = reports.StartTest("PropertyAddPropertyTest");

            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailDeleteButton();
        }


        [Test]
        public void PropertyCheckActionButtonTest()
        {
            test = reports.StartTest("PropertyCheckActionButtonTest");
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.CheckActionButton();
        }


        [Test]
        public void PropertyActionDetailViewButton()
        {
            // = reports.StartTest("PropertyActionDetailViewButton");
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailViewButton();
        }


        [Test]
        public void PropertySearchFunction()
        {
            test = reports.StartTest("PropertySearchFunction");
            PropertyPage propertyObj = new PropertyPage();
            
            propertyObj.SearchFunction();
        }


        [Test]
        public void PropertyActionDetailEditButton()
        {
            test = reports.StartTest("PropertyActionDetailEditButton");
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailEditButton();
        }


        [Test]
        public void PropertyActionDetailDeleteButton()
        {
            test = reports.StartTest("PropertyActionDetailDeleteButton");
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailDeleteButton();

        }


        [TearDown]

        public void Closing()
        {


            reports.EndTest(test);
            reports.Flush();


            LoginPages loginObj = new LoginPages();
            loginObj.quit();

        }

    }

    [TestFixture] 
    public class AdminModuleTest
    {
        public static ExtentReports reports;
        public static ExtentTest test;

        [SetUp]
        public void Login()
        {
            ////Define report
            string reportPath = Environment.CurrentDirectory + "\\" + "Test.html";
            reports = new ExtentReports(reportPath, false, DisplayOrder.NewestFirst);

            //Define Browser and Open 

            Global.GlobalDefinition.driver = new ChromeDriver();

            LoginPages loginObj = new LoginPages();
            loginObj.LoginStep();

            //Take screenshots after login
            Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinition.driver, "LoginSuccessful");


        }

        [Test]
        public void AdminAddPropertyTest()
        {
            test = reports.StartTest("AdminAddPropertyTest");

            PropertyPage propertyObj = new PropertyPage();
            propertyObj.ActionDetailDeleteButton();
        }



        [TearDown]

        public void Closing()
        {

            LoginPages loginObj = new LoginPages();
            loginObj.quit();
        }

    }

}
