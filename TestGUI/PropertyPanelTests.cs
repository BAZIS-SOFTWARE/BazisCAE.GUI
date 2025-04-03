using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Windows.Forms;
using static TestGUI.TestProvider;

namespace TestGUI
{

    public class PropertyPanelTests
    {
        [Test(Description = "Последовательное развертывание корней 'Объекты', 'ГруппыОбъектов' и 'Данные'")]
        public void SelectingTreeElementsTest()
        {
            var wd = LoadProject();
            try
            {
                var actions = new Actions(wd);

                TestProvider.GetElement(wd, "Модули", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Сварка", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Объекты", SearchWay.Name).Click();
 
                ExpandElement(wd, actions, "Элементы2D");
                ExpandElement(wd, actions, "Элементы3D");
                ExpandElement(wd, actions, "Группы объектов");
                ExpandElement(wd, actions, "Данные");
                ExpandElement(wd, actions, "Данные");

                actions.Perform();

                TestProvider.GetElement(wd, "Элемент2D : 7384", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Элемент3D : 23258", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "refLine", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Load", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Среда : air Коэф.теплоотдачи.воздух 20 0 1500 *", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Нагрев : ARC;4;100;25 Load 0 50 baseLine|refLine;2;startNodes;startNodes;0|0|0|0", SearchWay.Name).Click();
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        [Test(Description = "Изменение имени объекта - попытка присвоения некорректного имени и ввод валидных значений")]
        [TestCase("Элемент2D : 7384" )]
        [TestCase("refLine")]
        //[TestCase("Среда : air Коэф.теплоотдачи.воздух 20 0 1500 *")]
        public void RenameTreeElementsTest(string element)
        {
            var wd = LoadProject();
            try
            {
                var actions = new Actions(wd);

                TestProvider.GetElement(wd, "Модули", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Сварка", SearchWay.Name).Click();

                ExpandElement(wd, actions, "Элементы2D");
                ExpandElement(wd, actions, "Элементы3D");
                ExpandElement(wd, actions, "Группы объектов");
                actions.Perform();

                TestProvider.GetElement(wd, element, SearchWay.Name).Click();

                Rename(wd, "name@1 231", true);
                Rename(wd, "     name@1231", true);
                Rename(wd, "name@1231     ", true);
                Rename(wd, "new_nameElement", false);
                Rename(wd, "newNameElement232425!@#$%^&*()_+=", false);
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        [Test(Description = "Изменение цвета и последовательное изменение режима отображения объекта")]
        [TestCase("Элемент2D : 7384")]
        [TestCase("Элемент3D : 23258")]
        public void SelectColorAndTypeModeTest(string element)
        {
            var wd = LoadProject();
            try
            {
                var actions = new Actions(wd);

                TestProvider.GetElement(wd, "Модули", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Сварка", SearchWay.Name).Click();

                //Собираю в actions действия которые нужно выполнить 
                ExpandElement(wd, actions, "Элементы2D");
                ExpandElement(wd, actions, "Элементы3D");
                actions.Perform();

                //Ячейка имя 
                TestProvider.GetElement(wd, element, SearchWay.Name).Click();

                ChangeColor(wd, -10, 100);
                ChangeColor(wd, -125, 100);

                ChangeComboBoxValue(wd, 1);
                ChangeComboBoxValue(wd, 2);
                ChangeComboBoxValue(wd, 3);
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        [Test(Description = "Изменение группы у элементов ValuableData")]
        public void ChangeDataGroupTest()
        {
            var wd = LoadProject();
            try 
            {
                var actions = new Actions(wd);
                TestProvider.GetElement(wd, "Модули", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Сварка", SearchWay.Name).Click();
                TestProvider.GetElement(wd, "Данные", SearchWay.Name).Click();

                while (true)
                {
                    var previous = wd.SwitchTo().ActiveElement();
                    previous.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                    var current = wd.SwitchTo().ActiveElement();
                    if (previous.Equals(current)) break;

                    for (int i = 0; i < 1; i++)
                    {
                        TestProvider.GetElement(wd, " Строка 1, Не отсортировано.", SearchWay.Name).Click();
                        TestProvider.ClickByOffset(wd, 265, 0, ClickType.LeftOne);
                        TestProvider.ClickByOffset(wd, 0, 0, ClickType.LeftOne);
                        wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                        wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Enter);
                        wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Tab);
                    }
                    previous.SendKeys(OpenQA.Selenium.Keys.Enter);
                    wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
                    Thread.Sleep(1000);
                }


                Thread.Sleep(2000);
            }
            catch (Exception e) { wd.CloseApp(); Assert.Fail(e.Message); }

            finally { wd.CloseApp(); }
        }

        private static WindowsDriver<WindowsElement> LoadProject( )
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

        private static void Rename(WindowsDriver<WindowsElement> wd, string newName, bool isError)
        {
            WindowsElement exept = null;
            ClickCell(wd, " Строка 0, Не отсортировано.");
            wd.Keyboard.SendKeys(newName + OpenQA.Selenium.Keys.Enter);
            try
            {
                exept = wd.FindElement(By.Name("FormatException"));
                Thread.Sleep(1000);
            }
            catch(OpenQA.Selenium.WebDriverException ex) { }
            
            if (isError) 
            {
                Assert.That(!(exept is null));
                wd.Keyboard.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            else
            {
                if (exept is not null)
                {
                    wd.Keyboard.SendKeys(newName + OpenQA.Selenium.Keys.Enter);
                    throw new Exception("FormatException: ");
                }
            }
        }

        private static void ChangeTreeViewElement(WindowsDriver<WindowsElement> wd, int indexViewMode)
        {
            var selectedViewMode = new Actions(wd);
            for (int i = 0; i < indexViewMode; i++)
            {
                selectedViewMode.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
            }
            selectedViewMode.SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
        }

        private static void ChangeComboBoxValue(WindowsDriver<WindowsElement> wd, int indexViewMode)
        {
            TestProvider.GetElement(wd, " Строка 2, Не отсортировано.", SearchWay.Name).Click();
            TestProvider.ClickByOffset(wd, 275, 0, ClickType.LeftOne);
            TestProvider.ClickByOffset(wd, 0, 0, ClickType.LeftOne);
            var selectedViewMode = new Actions(wd);
            for (int i = indexViewMode - 1; i < indexViewMode; i++)
            {
                selectedViewMode.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
            }
            selectedViewMode.SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
            TestProvider.ClickByOffset(wd, 100, 0, ClickType.LeftOne);
            var update = new Actions(wd);
            update.SendKeys(OpenQA.Selenium.Keys.Escape).Perform();
        }

        private static void ChangeColor(WindowsDriver<WindowsElement> wd, int offsetX, int offsetY)
        {
            ClickCell(wd, " Строка 1, Не отсортировано.");
            TestProvider.GetElement(wd, "Основные цвета:", SearchWay.Name).Click();
            TestProvider.ClickByOffset(wd, offsetX, offsetY, ClickType.LeftOne);
            TestProvider.GetElement(wd, "ОК", SearchWay.Name).Click();
            var update = new Actions(wd);
            update.SendKeys(OpenQA.Selenium.Keys.Escape).Perform();
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