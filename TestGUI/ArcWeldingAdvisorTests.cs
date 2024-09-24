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
        [TestCase("Дуговая сварка", "Материалы", "  a_m", "  d_m","  r_m",TestName = "Дуговая сварка_Материалы: добавить, обновить, удалить")]
        [TestCase("Дуговая сварка", "Закрепления", "  a_c", "  d_c", "  r_c", TestName = "Дуговая сварка_Закрепления: добавить, обновить, удалить")]
        [TestCase("Дуговая сварка", "Режим сварки", "  a_h", "  d_h", "  r_h", TestName = "Дуговая сварка_Режим сварки: добавить, обновить, удалить")]
        [TestCase("Дуговая сварка", "Среда", "  a_m", "  d_m", "  r_m", TestName = "Дуговая сварка_Среда сварки: добавить, обновить, удалить")]
        [TestCase("Дуговая сварка", "Планировщик", "  a_p", "  d_p", "  r_p", TestName = "Дуговая сварка_Планировщик: добавить, обновить, удалить")]
        public void BasicControlsOperationsTest(string process, string category, string btnAdd, string btnDel, string btnRef)
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
            var taskArcW = wd.FindElement(By.Name(process));
            taskArcW.Click();
            var arcWMat = wd.FindElement(By.Name(category));
            arcWMat.Click();
            var strWMat = wd.FindElement(By.Name("Строка 0"));
            strWMat.Click();
            var refBtn = wd.FindElement(By.Name(btnRef));
            refBtn.Click();
            var delBtn = wd.FindElement(By.Name(btnDel));
            delBtn.Click();
            var addBtn = wd.FindElement(By.Name(btnAdd));
            addBtn.Click();

            Thread.Sleep(3000);

            //возврат лицензии на модуль сварка
            moduls.Click();
            var modulM = wd.FindElement(By.Name("Построение сетки"));
            modulM.Click();

            Thread.Sleep(3000);
            wd.CloseApp();
        }
    }
}