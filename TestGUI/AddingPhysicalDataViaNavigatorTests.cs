using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using static TestGUI.TestProvider;

namespace TestGUI
{
    public class AddingPhysicalDataViaNavigatorTests
    {

        [Test(Description = "Создание физических данных")]
        public void CreatePhysicalDataTest()
        {
            var wd = LoadProject();
            try
            {
                TestProvider.GetElement(wd, "Модули").Click();
                TestProvider.GetElement(wd, "Сварка").Click();
                var dataNavigator = TestProvider.GetElement(wd, "Данные");
                //dataNavigator.
                Thread.Sleep(5000);
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
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
