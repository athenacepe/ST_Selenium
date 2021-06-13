using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Athena_Selenium
{ 
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Name("q")).SendKeys("Selenium automation");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.calculator.net/");
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[1]/span[4]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();
            IWebElement result = driver.FindElement(By.XPath(".//*[@id='sciOutPut']"));
            double actual = double.Parse(result.Text);
            double expected = 10.0;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect.");
        }


        //Assignment Questions

        //Question 1a: cos(7)
        [TestMethod]
        public void TM1A()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.calculator.net/");
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[1]/span[2]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[1]/span[1]")).Click();
            IWebElement result = driver.FindElement(By.XPath(".//*[@id='sciOutPut']"));
            double actual = double.Parse(result.Text);
            double expected = 0.9925461516;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect.");
        }

        //Question 1b: Log(100)
        [TestMethod]
        public void TM1B()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.calculator.net/");
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[4]/span[5]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[3]/span[1]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[4]/span[1]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[4]/span[1]")).Click();
            IWebElement result = driver.FindElement(By.XPath(".//*[@id='sciOutPut']"));
            double actual = double.Parse(result.Text);
            double expected = 2;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect.");
        }

        //Question 1c: 3 + 8 (x + y)
        [TestMethod]
        public void TM1C()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.calculator.net/");
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[3]/span[3]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[1]/span[4]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[1]/span[2]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();
            IWebElement result = driver.FindElement(By.XPath(".//*[@id='sciOutPut']"));
            double actual = double.Parse(result.Text);
            double expected = 11;
            Assert.AreEqual(actual, expected, 0.00001, "Incorrect.");
        }

        //Question 1d: 5! (n!)
        [TestMethod]
        public void TM1D()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.calculator.net/");
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();
            driver.FindElement(By.XPath(".//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[5]/span[5]")).Click();
            IWebElement result = driver.FindElement(By.XPath(".//*[@id='sciOutPut']"));
            double actual = double.Parse(result.Text);
            double expected = 120;
            Assert.AreEqual(actual, expected);
        }

        //Question 2: validates the availability of all links in this page
        [TestMethod]
        public void TM2()
        {
            //WILL BE IN A SEPARATE FILE
        }

        //Question 3: Verify the correctness of the amount to be paid when purchasing three items
        [TestMethod]
        public void TM3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");

            //Add Blouse
            driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Continue Shopping
            driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[2]/div[4]/span/span")).Click();

            //Add Faded Short Sleeves
            driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Add Printed Summer Dress
            driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[5]/div/div[2]/div[2]/a[1]")).Click();
            
            //Go to checkout
            driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();

            //Get the total price
            IWebElement result = driver.FindElement(By.Id("total_price"));
            string stringResult = result.Text;
            //Remove the $ sign
            double actual = double.Parse(stringResult.Remove(0,1));
            double expected = 74.49;
            Assert.AreEqual(actual, expected);
        }

        //Question 4: Verify correctness of the amount to be paid when purchasing three items and removing two of them
        [TestMethod]
        public void TM4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");

            //Add Blouse
            driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);

            //Continue Shopping
            driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[2]/div[4]/span/span")).Click();

            //Add Faded Short Sleeves
            driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Add Printed Summer Dress
            driver.FindElement(By.XPath(".//*[@id='homefeatured']/li[5]/div/div[2]/div[2]/a[1]")).Click();

            //Go to checkout
            driver.FindElement(By.XPath(".//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();

            //Delete 2 items from the cart
            driver.FindElement(By.XPath(".//*[@id='1_1_0_0']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath(".//*[@id='5_19_0_0']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Wait for the 2 items to finish being removed from the cart
            Thread.Sleep(10000);

            //Get the total price
            IWebElement result = driver.FindElement(By.Id("total_price"));
            string stringResult = result.Text;
            //Remove the $ sign
            double actual = double.Parse(stringResult.Remove(0, 1));
            double expected = 29.00;
            Assert.AreEqual(actual, expected);
        }
    }
}
