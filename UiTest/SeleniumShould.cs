using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTest
{
    public class SeleniumShould
    {
        private const string HomeUrl = "https://ispdigital.net/";
        private const string PackageAndPricingUrl = "https://ispdigital.net/package-and-pricing";
        private const string ApplicationRequestUrl = "https://ispdigital.net/application-request";
        private const string HomeTitle = "ISP Digital | A Complete ISP Billing & Management Software for ISP Business";
        //private const string PackageAndPricingTitle = "ISP Digital | A Complete ISP Billing & Management Software for ISP Business";

        [Fact]
        [Trait ("Category","Smoke")]
        public void LoadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //const string homeUrl = "https://ispdigital.net/";

                driver.Navigate().GoToUrl(HomeUrl);

                DemoHelper.pause();

                //string pageTitle = driver.Title;

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //const string homeUrl = "https://ispdigital.net/";

                driver.Navigate().GoToUrl(HomeUrl);

                DemoHelper.pause();

                driver.Navigate().Refresh();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                

                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.pause();
                driver.Navigate().GoToUrl(PackageAndPricingUrl);
                DemoHelper.pause();
                driver.Navigate().Back();
                DemoHelper.pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                

                driver.Navigate().GoToUrl(PackageAndPricingUrl);
                DemoHelper.pause();

                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.pause();

                driver.Navigate().Back();
                DemoHelper.pause();

                driver.Navigate().Forward();
                DemoHelper.pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void OrderButton()
        {
            using (IWebDriver driver = new ChromeDriver())
            {


                driver.Navigate().GoToUrl(PackageAndPricingUrl);
                DemoHelper.pause();
                IWebElement Package = driver.FindElement(By.Id("data-728"));
                Package.Click();
                DemoHelper.pause();
                
                //in this case, because there is more than one "Order Now" button, it will select the 1st one
                IWebElement OrderButton = driver.FindElement(By.LinkText("Order Now"));
                OrderButton.Click();
                DemoHelper.pause();

                //driver.Navigate().GoToUrl(HomeUrl);
                //DemoHelper.pause();

                //driver.Navigate().Back();
                //DemoHelper.pause();

                //driver.Navigate().Forward();
                //DemoHelper.pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(ApplicationRequestUrl, driver.Url);

            }
        }

        [Fact]
        [Trait("Category", "Application")]
        public void OrderButtonByXpath()
        {
            using (IWebDriver driver = new ChromeDriver())
            {


                driver.Navigate().GoToUrl(PackageAndPricingUrl);
                DemoHelper.pause();
                IWebElement Package = driver.FindElement(By.XPath("/html/body/section[3]/div/div/div[2]/div/div[3]/ul/li[5]"));
                Package.Click();
                DemoHelper.pause();

                
                IWebElement OrderButton = driver.FindElement(By.XPath("/html/body/section[3]/div/div/div[2]/div/div[4]/a"));
                OrderButton.Click();
                DemoHelper.pause();

                //driver.Navigate().GoToUrl(HomeUrl);
                //DemoHelper.pause();

                //driver.Navigate().Back();
                //DemoHelper.pause();

                //driver.Navigate().Forward();
                //DemoHelper.pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(ApplicationRequestUrl, driver.Url);

            }
        }
    }
}
