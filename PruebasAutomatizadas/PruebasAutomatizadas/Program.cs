using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PruebasAutomatizadas
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:51474/PROJECTs/Create");
            driver.Manage().Window.Maximize();

            IWebElement projectCode = driver.FindElement(By.Id("pro_ncode"));
            projectCode.SendKeys("20");
            IWebElement projectName = driver.FindElement(By.Id("pro_name"));
            projectName.SendKeys("Pruebas Automatizadas");
            IWebElement projectInitialDate = driver.FindElement(By.Id("pro_initial_Date"));
            projectInitialDate.SendKeys("01/01/2019");
            IWebElement projectFinalDate = driver.FindElement(By.Id("pro_final_Date"));
            projectFinalDate.SendKeys("01/07/2019");
            IWebElement projectTeam = driver.FindElement(By.Id("tpr_ncode"));
            projectTeam.SendKeys("Presentación");

            IWebElement btnCreate = driver.FindElement(By.Id("btnCreate"));
            btnCreate.Click();
        }
    }
}
