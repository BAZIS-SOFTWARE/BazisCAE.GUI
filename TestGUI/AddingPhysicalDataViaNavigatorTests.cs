using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using static TestGUI.TestProvider;

namespace TestGUI
{
    public class AddingPhysicalDataViaNavigatorTests
    {
        [TestCase("Материал")]
        [TestCase("Нагрев")]
        [TestCase("Закрепление")]
        [TestCase("Нагрузка")]
        [TestCase("Среда")]
        [Test(Description = "Создание физических данных")]
        public void CreatePhysicalDataTest(string type)
        {
            var wd = LoadProject();
            try
            {
                TestProvider.GetElement(wd, "Модули").Click();
                TestProvider.GetElement(wd, "Сварка").Click();
                Thread.Sleep(1500);

                var element = TestProvider.GetElement(wd, "Данные");
                Actions action = new Actions(wd);
                action.ContextClick(element).Perform();
                
                TestProvider.GetElement(wd, "Добавить").Click();
                if(type == "Материал")
                {
                    TestProvider.GetElement(wd, "Материал").Click();
                    CreateMaterial(wd);
                }

                else if(type == "Закрепление")
                {
                    TestProvider.GetElement(wd, "Закрепление").Click();
                    CreateClamp(wd);
                }
                else if (type == "Нагрузка")
                {
                    TestProvider.GetElement(wd, "Нагрузка").Click();
                    CreateLoad(wd);
                }
                else if (type == "Нагрев")
                {
                    TestProvider.GetElement(wd, "Нагрев").Click();

                }

                else
                {

                }

                    //"cmbEl" "cmbMat" "txbStartTime" "txbStopTime" "cmbTraj" "cmbRef" "txbStartTime"
                    Thread.Sleep(5000);
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        private void CreateLoad(WindowsDriver<WindowsElement> wd)
        {
            SelectCMBElement(wd, "cmbKind");
            TestProvider.GetElement(wd, "chbX").Click();
            TestProvider.GetElement(wd, "chbY").Click();
            TestProvider.GetElement(wd, "chbZ").Click();
            SelectCMBElement(wd, "cmbGr");

            wd.FindElementByName("txbValue").Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Delete);
            wd.Keyboard.SendKeys("666" + OpenQA.Selenium.Keys.Enter);

            SelectCMBElement(wd, "cmbLoadFunction");

            var startLabel = wd.FindElementsByName("txbStartTime");
            var startAdditive = startLabel.OrderBy(btn => btn.Location.Y).First();
            startAdditive.Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Backspace);
            wd.Keyboard.SendKeys("0" + OpenQA.Selenium.Keys.Enter);

            wd.FindElementByName("txbStopTime").Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Delete);
            wd.Keyboard.SendKeys("2" + OpenQA.Selenium.Keys.Enter);

            FillGeneralControl(wd);
        }

        private void CreateClamp(WindowsDriver<WindowsElement> wd)
        {
            SelectCMBElement(wd, "cmbNodeGr"); 
            SelectCMBElement(wd, "cmbKind");
            TestProvider.GetElement(wd, "chbX").Click();
            TestProvider.GetElement(wd, "chbY").Click();
            TestProvider.GetElement(wd, "chbZ").Click();

            var startLabel = wd.FindElementsByName("txbStartTime");
            var startAdditive = startLabel.OrderBy(btn => btn.Location.Y).First();
            startAdditive.Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Backspace);
            wd.Keyboard.SendKeys("0" + OpenQA.Selenium.Keys.Enter);

            wd.FindElementByName("txbStopTime").Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Delete);
            wd.Keyboard.SendKeys("2" + OpenQA.Selenium.Keys.Enter);

            FillGeneralControl(wd);
        }

        private void CreateMaterial(WindowsDriver<WindowsElement> wd)
        {
            SelectCMBElement(wd, "cmbEl");
            SelectCMBElement(wd, "cmbMat");

            var startLabel = wd.FindElementsByName("txbStartTime");
            var startAdditive = startLabel.OrderBy(btn => btn.Location.Y).First();
            startAdditive.Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Backspace);
            wd.Keyboard.SendKeys("0" + OpenQA.Selenium.Keys.Enter);

            wd.FindElementByName("txbStopTime").Click();
            wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Delete);
            wd.Keyboard.SendKeys("2" + OpenQA.Selenium.Keys.Enter);

            FillGeneralControl(wd);

        }

        private void FillGeneralControl(WindowsDriver<WindowsElement> wd)
        {
            SelectCMBElement(wd, "cmbTraj");
            SelectCMBElement(wd, "cmbRef");

            wd.FindElementByName("Создать").Click();
        }

        private void SelectCMBElement(WindowsDriver<WindowsElement> wd, string nameCmb)
        {
            wd.FindElementByName(nameCmb).Click();
            var previous = wd.SwitchTo().ActiveElement();
            previous.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
            previous.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        private static WindowsDriver<WindowsElement> LoadProject()
        {
            var opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", Path.GetFullPath(@".\..\..\..\..\GUI\bin\x64\Debug\BazisGUI.exe"));
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "5");
            opt.AddAdditionalCapability("appArguments", $"-proj {Path.GetFullPath(@".\..\..\..\..\GUI\Projects\Welding\Arc\proj.bpf")}");
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            var wd = new WindowsDriver<WindowsElement>(url, opt);

            return wd;
        }
    }
}
