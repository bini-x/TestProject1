using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TestProject1
{
    internal class Class1
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test()
        {
            driver = new ChromeDriver("C:\\Users\\erbli\\Downloads\\chromedriver-win64");
            driver.Navigate().GoToUrl("https://e-learning.uni-gjilan.net/");

            string expectedTitle = "UNIVERSITETI KADRI ZEKA";
            string actualTitle = driver.Title;

            // Assert.AreEqual(expectedTitle, actualTitle);
            if(actualTitle == expectedTitle)
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
            driver.Quit();
        }

        [Test]
        public void TestimiIKomponenteve()
        {
            driver = new ChromeDriver("C:\\Users\\erbli\\Downloads\\chromedriver-win64");
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            var title = driver.Title;
            ClassicAssert.AreEqual("Web form", title);
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var textBox = driver.FindElement(By.Name("my-text"));
            var submitButton = driver.FindElement(By.TagName("button"));
            
            textBox.SendKeys("Selenium");
            submitButton.Click();

            var message = driver.FindElement(By.Id("message"));
            var value = message.Text;
            ClassicAssert.AreEqual("Received!", value);

            driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
