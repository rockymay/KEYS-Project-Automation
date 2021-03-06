﻿using Modules.Pages;
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
            PropertyPage propertyObj = new PropertyPage();
            propertyObj.CheckActionButton();


        }
    }


    [TestFixture]
    public class ModulesTest
    {
        public static ExtentReports reports;
        public static ExtentTest test;

        [SetUp]
        public void Login()
        {
            //Define report
            string currentFolder = @"C:\Users\rockymay\Source\Repos\KEYS-Project";
            string reportFolder = currentFolder + "\\" + "Test.html";
            reports = new ExtentReports(@"C:/Users/rockymay/Source/Repos/KEYS-Project/Modules/Modules/Test.html", false, DisplayOrder.NewestFirst);  //, false, DisplayOrder.NewestFirst

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
            test = reports.StartTest("PropertyActionDetailViewButton");
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

        //#####################################
        [Test]
        public void AdminSorting()
        {
            test = reports.StartTest("AdminSorting");

            AdminPage adminObj = new AdminPage();
            adminObj.Sorting();
        }


        [Test]
        public void AdminCheckActionButton()
        {
            test = reports.StartTest("AdminCheckActionButton");

            AdminPage adminObj = new AdminPage();
            adminObj.CheckActionButton();
        }




        [Test]
        public void AdminActionDetailViewButton()
        {
            test = reports.StartTest("AdminActionDetailViewButton");

            AdminPage adminObj = new AdminPage();
            adminObj.ActionDetailViewButton();
        }




        [Test]
        public void AdminActionDetailEditButton()
        {
            test = reports.StartTest("AdminActionDetailEditButton");

            AdminPage adminObj = new AdminPage();
            adminObj.ActionDetailEditButton();
        }


        [Test]
        public void AdminActionDetailDeleteButton()
        {
            test = reports.StartTest("AdminActionDetailDeleteButton");

            AdminPage adminObj = new AdminPage();
            adminObj.ActionDetailDeleteButton();
        }




        [Test]
        public void AdminSearchFunction()
        {
            test = reports.StartTest("AdminSearchFunction");

            AdminPage adminObj = new AdminPage();
            adminObj.SearchFunction();
        }





        //#####################################  SERVICE PROVIDOR   ##################

        [Test]
        public void ServiceSorting()
        {
            test = reports.StartTest("Service Sorting");
            ServiceSupplier serviceObj = new ServiceSupplier();
            serviceObj.Sorting();
        }

        [Test]
        public void ServiceCheckActionButton()
        {
            test = reports.StartTest("Service CheckActionButton");
            ServiceSupplier serviceObj = new ServiceSupplier();
            serviceObj.CheckActionButton();
        }

        [Test]
        public void ServiceActionDetailViewButton()
        {
            test = reports.StartTest("Service ActionDetailViewButton");
            ServiceSupplier serviceObj = new ServiceSupplier();
            serviceObj.ActionDetailViewButton();
        }

        [Test]
        public void ServiceActionDetailEditButton()
        {
            test = reports.StartTest("Service ActionDetailEditButton");
            ServiceSupplier serviceObj = new ServiceSupplier();
            serviceObj.ActionDetailEditButton();
        }

        [Test]
        public void ServiceActionDetailDeleteButton()
        {
            test = reports.StartTest("Service ActionDetailDeleteButton");
            ServiceSupplier serviceObj = new ServiceSupplier();
            serviceObj.ActionDetailDeleteButton();
        }

        [Test]
        public void ServiceSearchFunction()
        {
            test = reports.StartTest("Service SearchFunction");
            ServiceSupplier serviceObj = new ServiceSupplier();
            serviceObj.SearchFunction();
        }


        //##########################################




        [TearDown]

        public void Closing()
        {


            reports.EndTest(test);
            reports.Flush();


            LoginPages loginObj = new LoginPages();
            loginObj.quit();

        }

    }
}