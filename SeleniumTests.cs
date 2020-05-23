using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.ObjectModel;
using System.Threading;

namespace Vezba_zadatak_domaci_28
{
    class SeleniumTests
    {
        IWebDriver driver;
        WebDriverWait wait;

        public void Navigate(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        [Test]
        public void TestOrder()
        {
            Navigate("http://automationpractice.com/index.php");
            IWebElement InputFild = driver.FindElement(By.Id("search_query_top"));
            if (InputFild.Displayed && InputFild.Enabled)
            {
                InputFild.SendKeys("Faded");
            }
            IWebElement IButtonSearch = driver.FindElement(By.Name("submit_search"));
            if (IButtonSearch.Displayed && IButtonSearch.Enabled)
            {
                IButtonSearch.Click();
            }
           // IWebElement ListOfItems = wait.Until(EC.ElementIsVisible(By.ClassName("product_list")));
           // ReadOnlyCollection<IWebElement> listItems = ListOfItems.FindElements(By.TagName("li"));biramo iz liste prvi rezultat koji se pojavi jer je nasa slika i jedina koja se pojavi
           // if (listItems[0].Displayed && listItems[0].Enabled)
           // {
             //   listItems[0].Click();//
           // }//
            IWebElement FindImage = driver.FindElement(By.XPath("//img[@title='Faded Short Sleeve T-shirts']"));
            if (FindImage.Displayed && FindImage.Enabled)
            {
                FindImage.Click();
            }
            IWebElement QuantInput = driver.FindElement(By.Id("quantity_wanted"));
            if (QuantInput.Displayed && QuantInput.Enabled)
            {
                QuantInput.Clear();
                QuantInput.SendKeys("2");
            }
            Thread.Sleep(3000);

           // IWebElement SizeInput = driver.FindElement(By.ClassName("selector"));
            //if (SizeInput.Displayed && SizeInput.Enabled)
            //{
              //  SelectElement selectSize = new SelectElement(SizeInput);
              //  selectSize.SelectByText("M");
            
            Thread.Sleep(3000);
            IWebElement Color = driver.FindElement(By.Id("color_14"));
            if (Color.Displayed && Color.Enabled)
            {
                Color.Click();
            }
            IWebElement addToCard = driver.FindElement(By.XPath("//span[text()='Add to cart']"));
            if (addToCard.Displayed && addToCard.Enabled)
            {
                addToCard.Click();
            }
            try
            {
                IWebElement PupUp = wait.Until(EC.ElementIsVisible(By.ClassName("icon-ok")));
                if (PupUp.Displayed && PupUp.Enabled)
                {
                    IWebElement Contiuebutton = driver.FindElement(By.XPath("//span[@title='Continue shopping']"));
                    if (Contiuebutton.Displayed && Contiuebutton.Enabled)
                    {
                        Contiuebutton.Click();
                        Assert.Pass();
                    }

                }
            }
            catch (WebDriverTimeoutException)
            {
                {
                    Assert.Fail();
                }
            }
        }   
    }
}
