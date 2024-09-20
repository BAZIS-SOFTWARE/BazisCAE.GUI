using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace TestGUI
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //var myProcess = new Process();

            //myProcess.StartInfo.FileName = $@"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe";

            //var argStr = string.Join(" ", new string[] { @"..\Debug\Projects", "proj.bpf" });

            //myProcess.StartInfo.Arguments = argStr;
            //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //myProcess.Start();
        }

        [Test]
        public void MaterialsOperationsTest()
        {

            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe");
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "3");
            opt.AddAdditionalCapability("appArguments", @"c:\BazisGUI\GUI\Projects proj.bpf");
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            wd = new WindowsDriver<WindowsElement>(url,opt);

            var moduls = wd.FindElement(By.Name("Модули"));
            moduls.Click();
            var modulW = wd.FindElement(By.Name("Сварка"));
            modulW.Click();
            var tasks = wd.FindElement(By.Name("Задачи"));
            tasks.Click();
            var taskArcW = wd.FindElement(By.Name("Дуговая сварка"));
            taskArcW.Click();
            var arcWMat = wd.FindElement(By.Name("Материалы"));
            arcWMat.Click();
            var strWMat = wd.FindElement(By.Name("Строка 0"));
            strWMat.Click();
            var refBtn = wd.FindElement(By.Name("  r_m"));
            refBtn.Click();
            var delBtn = wd.FindElement(By.Name("  d_m"));
            delBtn.Click();
            var addBtn = wd.FindElement(By.Name("  a_m"));
            addBtn.Click();

            Thread.Sleep(3000);
            wd.CloseApp();
        }
    }
}