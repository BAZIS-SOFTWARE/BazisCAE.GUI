using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace TestGUI
{
    public class ToolStripPageTests
    {
        [Test(Description = "Тест продвинутого выбора. Действия: показать, переключение радиокнопок")]
        public void AdvanceModuleTest()
        {
            string args = @"-proj c:\BazisGUI\GUI\Projects\Welding\Arc\proj.bpf";

            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe");
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "3");
            opt.AddAdditionalCapability("appArguments", args);
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            wd = new WindowsDriver<WindowsElement>(url, opt);

            var moduls = wd.FindElement(By.Name("Модули"));
            moduls.Click();
            var modulW = wd.FindElement(By.Name("Построение сетки"));
            modulW.Click();
            var advSelection = wd.FindElement(By.Name("toolStripButton1"));
            advSelection.Click();

            wd.FindElement(By.Name("Элементы")).Click();
            wd.FindElement(By.Name("Узлы")).Click();
            wd.FindElement(By.Name("По направлению")).Click();
            
            wd.FindElement(By.Name("Выбрать")).Click();

            Thread.Sleep(1000);

            //возврат фокуса на главную форму
            advSelection.Click();

            Thread.Sleep(1000);

            var a = new Actions(wd);
            a.SendKeys(Keys.Escape).Perform();

            Thread.Sleep(1000);

            //возврат лицензии на модуль сварка
            TaskModuleTests.SwithModule(wd, moduls, "Построение сетки");

            Thread.Sleep(3000);
            wd.CloseApp();
        }


        [Test(Description = "Тест модуля измерений. Действия: измерить, переключение радиокнопок")]
        public void MeasureModuleTest()
        {
            string args = @"-proj c:\BazisGUI\GUI\Projects\Welding\Arc\proj.bpf";

            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe");
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "3");
            opt.AddAdditionalCapability("appArguments", args);
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            wd = new WindowsDriver<WindowsElement>(url, opt);

            var moduls = wd.FindElement(By.Name("Модули"));
            moduls.Click();
            var modulW = wd.FindElement(By.Name("Построение сетки"));
            modulW.Click();
            var measureForm = wd.FindElement(By.Name("toolStripButton14"));
            measureForm.Click();


            var measurebtn = wd.FindElement(By.Name("Измерить"));

            wd.FindElement(By.Name("Расстояние")).Click();
            measurebtn.Click();
            wd.FindElement(By.Name("Объем, ед.^3")).Click();
            measurebtn.Click();
            wd.FindElement(By.Name("Площадь, ед.^2")).Click();
            measurebtn.Click();
            wd.FindElement(By.Name("Путь")).Click();
            measurebtn.Click();

            Thread.Sleep(1000);

            //возврат фокуса на главную форму
            measureForm.Click();

            Thread.Sleep(1000);

            var a = new Actions(wd);
            a.SendKeys(Keys.Escape).Perform();

            Thread.Sleep(1000);

            //возврат лицензии на модуль сварка
            TaskModuleTests.SwithModule(wd, moduls, "Построение сетки");

            Thread.Sleep(3000);
            wd.CloseApp();
        }

        [Test(Description = "Тест модуля сечений. Действия: построить, переключение радиокнопок")]
        public void CrossSectionModuleTest()
        {
            string args = @"-proj c:\BazisGUI\GUI\Projects\Welding\Arc\proj.bpf";

            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"c:\BazisGUI\GUI\bin\x64\Debug\BazisGUI.exe");
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "3");
            opt.AddAdditionalCapability("appArguments", args);
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            wd = new WindowsDriver<WindowsElement>(url, opt);

            var moduls = wd.FindElement(By.Name("Модули"));
            moduls.Click();
            var modulW = wd.FindElement(By.Name("Построение сетки"));
            modulW.Click();
            var crossForm = wd.FindElement(By.Name("toolStripButton15"));
            crossForm.Click();


            var createbtn = wd.FindElement(By.Name("Построить"));
            var deletebtn = wd.FindElement(By.Name("Удалить"));

            wd.FindElement(By.Name("XY")).Click();
            createbtn.Click();
            wd.FindElement(By.Name("XZ")).Click();
            createbtn.Click();
            wd.FindElement(By.Name("YZ")).Click();
            createbtn.Click();

            deletebtn.Click();

            Thread.Sleep(1000);

            //возврат фокуса на главную форму
            crossForm.Click();

            Thread.Sleep(1000);

            var a = new Actions(wd);
            a.SendKeys(Keys.Escape).Perform();

            Thread.Sleep(1000);

            //возврат лицензии на модуль сварка
            TaskModuleTests.SwithModule(wd, moduls, "Построение сетки");

            Thread.Sleep(3000);
            wd.CloseApp();
        }
    }
}
