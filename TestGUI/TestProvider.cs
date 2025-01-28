using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestGUI
{
    public static class TestProvider
    {
        public enum SearchWay
        {
            Name,
            ID,
            TagName,
            XPath
        }

        public enum ClickType
        {
            LeftOne,
            LeftDouble,
            RightOne,
            ClickAndHold
        }
        public static WindowsDriver<WindowsElement> CreateWinDriver(string args)
        {
            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", Path.GetFullPath(@".\..\..\..\..\PropertiesDataBases\bin\Debug\PropertiesDataBases.exe"));
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "10");
            opt.AddAdditionalCapability("appArguments", args);
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            return new WindowsDriver<WindowsElement>(url, opt);
        }

        public static WindowsElement GetElement(WindowsDriver<WindowsElement> wd, string searchArg, SearchWay search = SearchWay.Name, double timeOut = 10)
        {
            WindowsElement element = null;
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(wd)
            {
                Timeout = TimeSpan.FromSeconds(timeOut),
                Message = $"Element by searching argument \"{searchArg}\" not found."
            };

            wait.IgnoreExceptionTypes(typeof(WebDriverException));
            try
            {
                wait.Until(wd =>
                {
                    if (search == SearchWay.Name)
                        element = wd.FindElement(By.Name(searchArg));
                    else if (search == SearchWay.ID)
                        element = wd.FindElement(By.Id(searchArg));
                    else if (search == SearchWay.ID)
                        element = wd.FindElement(By.TagName(searchArg));
                    else
                        element = wd.FindElement(By.XPath(searchArg));
                    return element;
                });
            }
            catch (WebDriverTimeoutException ex) { Assert.Fail(ex.Message); }
            return element;
        }

        public static void ClickByOffset(WindowsDriver<WindowsElement> wd, int x, int y, ClickType clickType, double timeOut = 10)
        {
            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(wd)
            {
                Timeout = TimeSpan.FromSeconds(timeOut),
                Message = $"Clicking on Element by offset ({x}, {y}) turn into error: could not click by offset"
            };
            try
            {
                wait.Until(wd =>
                {
                    var action = new Actions(wd);

                    if (clickType == ClickType.LeftDouble)
                        action.MoveByOffset(x, y).DoubleClick().Build().Perform();

                    else if (clickType == ClickType.RightOne)
                        action.MoveByOffset(x, y).ContextClick().Build().Perform();

                    else if (clickType == ClickType.ClickAndHold)
                        action.ClickAndHold().MoveByOffset(x, y).Click().Build().Perform();

                    else
                        action.MoveByOffset(x, y).Click().Build().Perform();

                    return action;
                });
            }

            catch (WebDriverTimeoutException ex) { Assert.Fail(ex.Message); }
        }

        public static void SendKey(WindowsDriver<WindowsElement> wd, string name, string value)
        {
            wd.FindElement(By.Name(name)).Click();

            wd.FindElement(By.Name(name)).SendKeys(value);
        }
    }
}
