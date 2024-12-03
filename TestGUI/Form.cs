using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestGUI
{
    public class Form
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Построение металлургических диаграмм")]
        [TestCase("CCT", TestName = "CCT диаграмма")]
        [TestCase("TTT", TestName = "TTT диаграмма")]
        [TestCase("Hardening", TestName = "Диаграмма упрочнения")]
        public void DiagramOperationTests(string key)
        {
            var wd = WindowsDriver();

            wd.FindElement(By.Name("Открыть файл")).Click();

            var clickMaterial = new Actions(wd);
            clickMaterial.MoveByOffset(165, 150).DoubleClick().Build().Perform();
            
            wd.FindElementByName("Сталь_20ХМ").Click();
            var click = new Actions(wd);
            click.MoveByOffset(0, 0).DoubleClick().Build().Perform();            

            if (key == "CCT" || key == "TTT")
                OpenMetallurgy(wd, key);            
            else if (key == "Hardening") 
                CreateHardeningControl(wd);

            wd.CloseApp();
        }

        private static WindowsDriver<WindowsElement> WindowsDriver()
        {
            WindowsDriver<WindowsElement> wd;

            var opt = new AppiumOptions();

            opt.AddAdditionalCapability("app", @"D:\Bazis\DataBase\TestDataBases\bin\Debug\TestDataBases.exe");
            opt.PlatformName = "Windows11x64";
            var url = new Uri("http://127.0.0.1:4723");
            return new WindowsDriver<WindowsElement>(url, opt);
        }

        private void OpenMetallurgy(WindowsDriver<WindowsElement> wd, string key)
        {
            wd.FindElementByName("Металлургия").Click();
            
            var click = new Actions(wd);
            click.MoveByOffset(0, 0).ContextClick().Build().Perform();

            wd.FindElementByName("Рассчитать диаграмму").Click();

            if (key == "CCT")
                CreateCCTDiagramm(wd);
            else if (key == "TTT")
                CreateTTTDiagramm(wd);
        }
        private void CreateCCTDiagramm(WindowsDriver<WindowsElement> wd)
        {
            wd.FindElement(By.Name("InitialPhase")).Click();

            var clickStructure = new Actions(wd);
            clickStructure.MoveByOffset(30, 5).Click().Build().Perform();

            var clickAustenite = new Actions(wd);
            clickAustenite.MoveByOffset(-10, 20).Click().Build().Perform();

            wd.FindElement(By.Name("Рассчитать")).Click();

            Thread.Sleep(2000); 
        }

        private void CreateTTTDiagramm(WindowsDriver<WindowsElement> wd)
        {
            wd.FindElement(By.Name("TTT")).Click();

            wd.FindElement(By.Name("InitialPhase")).Click();

            var clickStructure = new Actions(wd);
            clickStructure.MoveByOffset(30, 5).Click().Build().Perform();

            var clickAustenite = new Actions(wd);
            clickAustenite.MoveByOffset(-10, 20).Click().Build().Perform();

            wd.FindElement(By.Name("Время")).SendKeys("10000");

            wd.FindElement(By.Name("Рассчитать")).Click();

            Thread.Sleep(2000);
        } 
        
        private void CreateHardeningControl(WindowsDriver<WindowsElement> wd)
        {
            wd.FindElementByName("Механические свойства").Click();
            var click = new Actions(wd);
            click.MoveByOffset(0, 0).ContextClick().Build().Perform();

            wd.FindElementByName("Рассчитать упрочнение").Click();

            wd.FindElementByName("Phases").Click();

            var clickStructure = new Actions(wd);
            clickStructure.MoveByOffset(30, 5).Click().Build().Perform();

            var clickAustenite = new Actions(wd);
            clickAustenite.MoveByOffset(-10, 70).Click().Build().Perform();

            wd.FindElement(By.Name("Рассчитать")).Click();

            wd.FindElement(By.Name("Указать температуру")).Click();

            wd.FindElement(By.Name("Temp")).SendKeys("200");

            wd.FindElement(By.Name("Рассчитать")).Click();

            Thread.Sleep(2000);
        }

        public void SendKey(string name, string value, WindowsDriver<WindowsElement> wd)
        {
            wd.FindElement(By.Name(name)).Click();

            wd.FindElement(By.Name(name)).SendKeys(value);
        }

        [TestCase(TestName = "Добавление и копирование нового материала")]
        public void AddNewMaterialTests()
        {
            var wd = WindowsDriver();

            wd.FindElement(By.Name("Добавить раздел")).Click();

            var click = new Actions(wd);
            wd.FindElementByName("Новый_материал_0").Click();
            click.MoveByOffset(0, 0).DoubleClick().Build().Perform();

            wd.FindElement(By.Name("Общие сведения")).Click();
            click.MoveByOffset(0, 0).Click().Build().Perform();

            wd.FindElement(By.Name("Структура,Фаза-Масс.доли")).Click();

            wd.FindElement(By.Name("Добавить ряд")).Click();

            SendKey("Фаза Строка 0", "Аустенит", wd);
            SendKey("Фаза Строка 1", "Мартенсит", wd);

            wd.FindElement(By.Name("Тепловые свойства")).Click();
            click.MoveByOffset(0, 0).Click().Build().Perform();

            wd.FindElementByName("Теплоемкость,Дж-C°").Click();

            SendKey("Температура Строка 0", "100", wd);
            SendKey("Аустенит Строка 0", "1", wd);
            SendKey("Мартенсит Строка 0", "2", wd);

            wd.FindElementByName("Новый_материал_0").Click();

            wd.FindElement(By.Name("Создать копию")).Click();

            wd.FindElementByName("Новый_материал_0_копия").Click();

            Thread.Sleep(2000);
            wd.CloseApp();
        }

        [TestCase(TestName = "Добавление и копирование новой функции")]
        public void AddNewFunctionTests()
        {
            var wd = WindowsDriver();

            wd.FindElement(By.Name("Функции")).Click();

            wd.FindElement(By.Name("Добавить раздел")).Click();

            wd.FindElement(By.Name("Новая_функция_0,\" \"-\" \"")).Click();

            SendKey("X Строка 0", "100", wd);
            SendKey("Y Строка 0", "200", wd);

            wd.FindElement(By.Name("Добавить ряд")).Click();

            SendKey("X Строка 1", "300", wd);
            SendKey("Y Строка 1", "400", wd);

            wd.FindElement(By.Name("Создать копию")).Click();

            wd.FindElement(By.Name("Новая_функция_0_копия,\" \"-\" \"")).Click();

            Thread.Sleep(2000);
            wd.CloseApp();
        }

    }
}
