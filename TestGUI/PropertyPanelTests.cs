using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestGUI.TestProvider;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace TestGUI
{
    public class PropertyPanelTests
    {
        [Test(Description = "Последовательное развертывание корней 'Объекты', 'ГруппыОбъектов' и 'Данные'")]
        public void SelectingTreeElementsTests()
        {
            var opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", Path.GetFullPath(@".\..\..\..\..\GUI\bin\x64\Debug\BazisGUI.exe"));
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "5");
            opt.AddAdditionalCapability("appArguments", $"-proj {Path.GetFullPath(@".\..\..\..\..\GUI\Projects\Welding\Arc\proj.bpf")}");
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            var wd = new WindowsDriver<WindowsElement>(url, opt);

            try
            {
                var actions = new Actions(wd);

                TestProvider.GetElement(wd, "Модули", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Сварка", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Объекты", SearchWay.Name).Click();
                //Собираю в actions действия которые нужно выполнить 
                ExpandElement(wd, actions, "Элементы2D");
                ExpandElement(wd, actions, "Элементы3D");
                ExpandElement(wd, actions, "Группы объектов");
                ExpandElement(wd, actions, "Данные");

                actions.Perform();

                //Ячейка имя 
                TestProvider.GetElement(wd, "Элемент2D : 7384", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Элемент3D : 23258", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "refLine", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Load", SearchWay.Name).Click();
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        [Test(Description = "AdditiveGrow")]
        [TestCase("Элемент2D : 7384" )]
        [TestCase("Элемент3D : 23258")]
        [TestCase("refLine")]
        public void RenameTreeElementsTests(string element)
        {
            var opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", Path.GetFullPath(@".\..\..\..\..\GUI\bin\x64\Debug\BazisGUI.exe"));
            opt.AddAdditionalCapability("ms:waitForAppLaunch", "5");
            opt.AddAdditionalCapability("appArguments", $"-proj {Path.GetFullPath(@".\..\..\..\..\GUI\Projects\Welding\Arc\proj.bpf")}");
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            var wd = new WindowsDriver<WindowsElement>(url, opt);

            try
            {
                var actions = new Actions(wd);

                TestProvider.GetElement(wd, "Модули", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Сварка", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Объекты", SearchWay.Name).Click();
                //Собираю в actions действия которые нужно выполнить 
                ExpandElement(wd, actions, "Элементы2D");
                ExpandElement(wd, actions, "Элементы3D");
                ExpandElement(wd, actions, "Группы объектов");
                actions.Perform();

                //Ячейка имя 
                TestProvider.GetElement(wd, element, SearchWay.Name).Click();

                //Редактирование c ошибкой
                Rename(wd, "name@1 231", true);
                Rename(wd, "     name@1231", true);
                Rename(wd, "name@1231     ", true);
                //Редактирование правильное имя
                Rename(wd, "new_nameElement", false);
                Rename(wd, "newNameElement232425!@#$%^&*()_+=", false);
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        private static void Rename(WindowsDriver<WindowsElement> wd, string newName, bool isError)
        {
            ClickCell(wd, " Строка 0, Не отсортировано.");
            wd.Keyboard.SendKeys(newName + Keys.Enter);
            if(isError) wd.Keyboard.SendKeys(Keys.Enter);
        }
        private static void ClickCell(WindowsDriver<WindowsElement> wd, string rowName)
        {
            TestProvider.GetElement(wd, rowName, SearchWay.Name).Click();
            TestProvider.ClickByOffset(wd, 130, 0, ClickType.LeftOne);
            TestProvider.ClickByOffset(wd, 0, 0, ClickType.LeftOne);
        }

        private static void ExpandElement(WindowsDriver<WindowsElement> wd, Actions actions, string nameInTree)    
        {
            var element = TestProvider.GetElement(wd, nameInTree, SearchWay.Name);
            actions.DoubleClick(element);
        }
    }
}
