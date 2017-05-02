using Modules.Pages;
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
            Global.GlobalDefinition.driver = new ChromeDriver();

            LoginPages loginObj = new LoginPages();
            loginObj.LoginStep();

            PropertyPage propertyObj = new PropertyPage();
            if (propertyObj.verifyResult(Global.GlobalDefinition.driver, "http://new-keys.azurewebsites.net/PropertyOwners", "iPhone", "238"))
                Console.WriteLine("iPhone is added") ;

        }
    }
}
