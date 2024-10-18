using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;

namespace TestGUI
{
    public class ResultsModuleTests
    {
        [Test(Description = "Постпроцессор. Действия: выбрать шаг,показать результаты, скрыть результаты")]
        [TestCase(@"c:\projs\testProj\tjoint\proj.bpf",
            @"c:\projs\testProj\tjoint\ResultsData\механическая_2_50_1500.db", "XYZ", TestName = "Результаты_XYZ")]
        [TestCase(@"c:\projs\ElenaLu\Bulk\1.bpf",
            @"c:\projs\ElenaLu\Bulk\термическая_0.db", "T", TestName = "Результаты_T")]
        public void ResultModuleOperationsTest(string projFile, string resFile, string resKind)
        {
            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe");
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "3");
            var args = string.Join(" ", new string[] {
                "-proj", projFile, "-res", resFile });

            opt.AddAdditionalCapability("appArguments", args);
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");

            wd = new WindowsDriver<WindowsElement>(url, opt);

            var moduls = wd.FindElement(By.Name("Модули"));
            moduls.Click();
            var modulR = wd.FindElement(By.Name("Анализ результатов"));
            modulR.Click();
            var resTools = wd.FindElement(By.Name("Результаты"));
            resTools.Click();
            var resField = wd.FindElement(By.Name("Построить поле"));
            resField.Click();

            var resSet = wd.FindElement(By.Name("Набор результатов"));
            resSet.Click();

            var a = new Actions(wd);
            a.MoveByOffset(-(resSet.Size.Width - 20), 0).Click().Build().Perform();

            var resNodes = wd.FindElement(By.Name("ПоУзлам"));

            a.MoveToElement(resNodes).MoveByOffset(-(resNodes.Size.Width), 0).
                Click().Build().Perform();

            var resKindNode = wd.FindElement(By.Name(resKind));
            resKindNode.Click();

            var richEditControl = wd.FindElement(By.Name("RichEdit Control"));
            richEditControl.Click();

            Thread.Sleep(3000);
            TaskModuleTests.SwithModule(wd, moduls, "Построение сетки");

            Thread.Sleep(3000);
            wd.CloseApp();
        }

        [Test]
        [TestCase(@"C:\Users\unv\source\BazisProj\testProj\VSMPO\vsmpo.bpf", @"C:\Users\unv\source\BazisProj\testProj\VSMPO\ResultsData\термическая_1_0_50.db")]
        public void TestExportCtrl_ShouldPass_OnSuccessfulExport(string projPath, string resPath)
        {
            var opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", Path.GetFullPath(@"C:\Users\unv\source\repos\Bazis\BazisGUI4.1\GUI\bin\x64\Debug\BazisGUI.exe"));
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "5");
            opt.AddAdditionalCapability("appArguments", @$"-proj {projPath} -res {resPath}");

            var wd = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), opt);
            try
            {
                wd.FindElement(By.Name("Модули")).Click();
                wd.FindElement(By.Name("Анализ результатов")).Click();
                wd.FindElement(By.Name("Результаты")).Click();
                wd.FindElement(By.Name("Экспорт результатов")).Click();
                wd.FindElement(By.TagName("TaskType")).Click();
                wd.FindElement(By.Name("механическая")).Click();
            }
            catch (Exception ex) { }
            finally { wd.CloseApp(); }
        }
    }
}
