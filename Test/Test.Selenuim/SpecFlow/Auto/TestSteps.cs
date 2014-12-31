using System.Globalization;
using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium;
using TechTalk.SpecFlow;

namespace Test.Selenuim.SpecFlow.Auto
{
    [Binding]
    public class StepDefinitions
    {
        private readonly IWebDriver _driver = new FirefoxDriver();
        private readonly  ISelenium  _selenium = null;
        public StepDefinitions()
        {
             _selenium = new WebDriverBackedSelenium(_driver, "http://www.baidu.com/");
            _selenium.Start();
             _selenium.Open("/");
            //_driver.Navigate().GoToUrl();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _selenium.Type("id=kw", "abc");
            //IWebElement query = _driver.FindElement(By.Id("kw"));
            //query.SendKeys(query.Text + p0.ToString(CultureInfo.InvariantCulture));
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(120, p0);
        }
    }
}
