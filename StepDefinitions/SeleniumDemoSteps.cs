using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace goSelenium.StepDefinitions
{
    [Binding]
    public class SeleniumDemoSteps
    {
        private IWebDriver driver;

        [Given(@"I open the browser")]
        public void GivenIOpenTheBrowser()
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService("C:\\Users\\91953\\Downloads\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe");
            driver = new ChromeDriver(chromeDriverService);
            driver.Manage().Window.Maximize();
        }

        [When(@"I navigate to the website ""(.*)""")]
        public void WhenINavigateToTheWebsite(string url)
        {
            driver.Url = url;
        }

        [Then(@"the title of the website should be ""(.*)""")]
        public void ThenTheTitleOfTheWebsiteShouldBe(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Then(@"the URL of the website should be ""(.*)""")]
        public void ThenTheURLOfTheWebsiteShouldBe(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, driver.Url);
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string buttonLabel)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.FindElement(By.XPath($"//button[contains(text(), '{buttonLabel}')]")).Click();
        }

        [Then(@"the ""(.*)"" button should be displayed")]
        public void ThenTheButtonShouldBeDisplayed(string buttonLabel)
        {
            IWebElement deleteButton = driver.FindElement(By.XPath($"//button[contains(text(), '{buttonLabel}')]"));
            Assert.IsTrue(deleteButton.Displayed);
        }

        [Then(@"the text of the ""(.*)"" button should be ""(.*)""")]
        public void ThenTheTextOfTheButtonShouldBe(string buttonLabel, string expectedText)
        {
            IWebElement deleteButton = driver.FindElement(By.XPath($"//button[contains(text(), '{buttonLabel}')]"));
            Assert.AreEqual(expectedText, deleteButton.Text);
        }

        [Then(@"I close the browser")]
        public void ThenICloseTheBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
