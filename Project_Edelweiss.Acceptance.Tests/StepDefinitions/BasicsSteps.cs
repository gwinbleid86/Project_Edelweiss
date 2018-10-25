using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class BasicsSteps
    {
        private IWebDriver driver;
        private const string MAIN_PAGE_URL = "http://localhost:56257/";

        public BasicsSteps()
        {
            driver = Driver.GetDriver;
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(MAIN_PAGE_URL);
        }

        public void ClickLink(string linkText)
        {
            var link = driver.FindElement(By.LinkText(linkText));
            link.Click();
        }
      
        public void ClickButton(string caption)
        {
            var button = driver.FindElement(By.XPath($"//button[contains(text(),'{caption}')]"));
            button.Click();
        }
        public void ClickButtonT(string id)
        {
            var button = driver.FindElement(By.Id(id));
            button.Click();
        }

        public void FillText(string id, string text)
        {

            var textBox = driver.FindElement(By.Id(id));
            textBox.SendKeys(text);
        }

        public void FillTextNearLabel(string labelText, string text, string type = "text")
        {
            var textBox = driver.FindElement(By.XPath(
                $"//label[contains(text(),'{labelText}')]/../input[@type='{type}']"));
            textBox.SendKeys(text);
        }
        public void FillTextNearLabelT( string text, string type = "search")
        {
            var textBox = driver.FindElement(By.XPath(
                $"//input[@type='{type}']"));
            textBox.SendKeys(text);
        }
        public void FillTextNearLabelTtt( string text, string id)
        {
            IWebElement input = driver.FindElement(By.Id(id));
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='passp']")));
            Actions builder = new Actions(driver);
            builder.SendKeys(input, "111222").Build().Perform();
            //builder.MoveToElement(input).SendKeys(input, "111222").Build().Perform();
        }
        public void FillTextNearLabelTttt( string text, string type = "search")
        {
            IWebElement input = driver.FindElement(By.XPath("//*[@id='passp']"));
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='passp']")));
            Actions builder = new Actions(driver);
            builder.MoveToElement(input).SendKeys(input, "111222").Build().Perform();
        }

        public bool IsElementFound(string text)
        {
            var element = driver.FindElement(By.XPath($"//*[contains(text(),'{text}')]"));
            return element != null;
        }

        public void SelectElement(string labelText, string element)
        {
            var select = driver.FindElement(By.XPath(
                $"//label[contains(text(),'{labelText}')]/../../div/select"));
            var selectElement = new SelectElement(select);
            selectElement.SelectByText(element);
        }
        public void SelectElementt(string labelText, string element)
        {
            var select = driver.FindElement(By.Id(labelText));
            var selectElement = new SelectElement(select);
            selectElement.SelectByText(element);
        }
        public void ClickLinkk(string linkText, /*string text,*/ string labelText, string element)
        {
            //var link = driver.FindElement(By.LinkText(linkText));
            var link = driver.FindElement(By.Id(linkText));
            link.Click();
            var select = driver.FindElement(By.Id(labelText));
            var selectElement = new SelectElement(select);
            selectElement.SelectByText(element);
            //link.Selected();
        }
    }
}
