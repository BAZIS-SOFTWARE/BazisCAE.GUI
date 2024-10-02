using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGUI
{
    public class ModelModuleTests
    {
        [Test(Description = "Сеточный генератор. Действия: импорт геометрии. Запуск генератора")]
        [TestCase(@"c:\BazisComponents\WeldingCADMerge\model7v3.stp", TestName = "Импорт геометрии model7v3.stp")]
        [TestCase(@"c:\BazisComponents\WeldingCADMerge\part2.step", TestName = "Импорт геометрии part2.STEP")]
        [TestCase(@"c:\BazisComponents\WeldingCADMerge\part3.step", TestName = "Импорт геометрии part3.STEP")]
        public void ModelModuleOperationsTest(string cadFile)
        {
            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe");
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "3");
            var args = string.Join(" ", new string[] {
                "-cad", cadFile });

            opt.AddAdditionalCapability("appArguments", args);
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");

            wd = new WindowsDriver<WindowsElement>(url, opt);

            var moduls = wd.FindElement(By.Name("Модули"));
            moduls.Click();
            var modulR = wd.FindElement(By.Name("Построение сетки"));
            modulR.Click();
            var mesh = wd.FindElement(By.Name("Сетка"));
            mesh.Click();
            var meshGen = wd.FindElement(By.Name("Генератор 3D сетки"));
            meshGen.Click();
            var approuve = wd.FindElement(By.Name("ОК"));
            approuve.Click();

            Thread.Sleep(3000);
            Tests.SwithModule(wd, moduls, "Сварка");

            Thread.Sleep(3000);
            wd.CloseApp();
        }
    }
}
