using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;


namespace TestGUI
{
    public class TreeViewTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(TestName = "Добавление реакции")]

        public void TreeViewOperationTests()
        {
            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"D:\Bazis\DataBase\TestDataBases\bin\Debug\TestDataBases.exe");
            opt.AddAdditionalCapability("appArguments", @"mat D:\Bazis\DataBase\Materials\Materials_for_test.jsf");

            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            wd = new WindowsDriver<WindowsElement>(url, opt);

            wd.FindElementByName("Открыть файл").Click();
            var clickMaterial = new Actions(wd);
            clickMaterial.MoveByOffset(165, 150).DoubleClick().Build().Perform();

            var click = new Actions(wd);

            wd.FindElementByName("Сталь_20ХГСА").Click();
            click.MoveByOffset(0, 0).DoubleClick().Build().Perform();

            wd.FindElementByName("Металлургия").Click();
            click.MoveByOffset(0, 0).ContextClick().Build().Perform();

            wd.FindElementByName("Добавить реакцию").Click();
            wd.FindElementByName("Металлургия").Click();

            wd.FindElementByName("Реакция R1-R2,Масс.Доли-°C").Click();
            click.MoveByOffset(0, 0).Click().Build().Perform();

            wd.FindElementByName("Редактировать").Click();
            wd.FindElementByName("InitialPhase").Click();

            var clickInitialStructure = new Actions(wd);
            clickInitialStructure.MoveByOffset(70, 3).Click().Build().Perform();

            var clickAust = new Actions(wd);
            clickAust.MoveByOffset(-20, 60).Click().Build().Perform();

            wd.FindElementByName("FinalPhase").Click();
            var clickFinalStructure = new Actions(wd);
            clickFinalStructure.MoveByOffset(70, 3).Click().Build().Perform();

            var clickMart = new Actions(wd);
            clickMart.MoveByOffset(-20, 50).Click().Build().Perform();

            wd.FindElementByName("PhaseName").Click();

            var clickPhaseName = new Actions(wd);
            clickPhaseName.MoveByOffset(70, 3).Click().Build().Perform();

            var clickCooling = new Actions(wd);
            clickCooling.MoveByOffset(-20, 20).Click().Build().Perform();
            SendKey("Температура Строка 0", "300", wd);

            SendKey("Масс.Доли Строка 0", "0.9", wd);
            SendKey("Температура Строка 1", "375", wd);
            SendKey("Масс.Доли Строка 1", "0.5", wd);

            var closeForm = new Actions(wd);
            closeForm.MoveByOffset(50, -200).Click().Build().Perform();
            Thread.Sleep(2000);


            wd.CloseApp();
        }

        public void SendKey(string name, string value, WindowsDriver<WindowsElement> wd)
        {
            wd.FindElement(By.Name(name)).Click();
            wd.FindElement(By.Name(name)).SendKeys(value);
        }
    }
}
