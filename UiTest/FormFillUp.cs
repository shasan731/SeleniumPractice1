using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTest
{
    public class FormFillUp
    {
        private const string HomeUrl = "https://ispdigital.net/";
        private const string PackageAndPricingUrl = "https://ispdigital.net/package-and-pricing";
        private const string ApplicationRequestUrl = "https://ispdigital.net/application-request";
        private const string HomeTitle = "ISP Digital | A Complete ISP Billing & Management Software for ISP Business";

        [Fact]
        public void FormSubmit()
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

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(ApplicationRequestUrl, driver.Url);

                //IWebElement NameField = 
                driver.FindElement(By.Id("Attribute3")).SendKeys("Harry Potter");
                DemoHelper.pause();
                //NameField.SendKeys("Harry Potter");
                driver.FindElement(By.Id("Attribute4")).SendKeys("harrypotter.gryffindor@hogwarts.com");
                DemoHelper.pause();
                driver.FindElement(By.Id("Attribute5")).SendKeys("Mischeif");
                DemoHelper.pause();
                driver.FindElement(By.Id("Attribute6")).SendKeys("www.thegoldentrio.com");
                DemoHelper.pause();
                driver.FindElement(By.Id("Attribute7")).SendKeys("+0166666666");
                DemoHelper.pause();
                driver.FindElement(By.Id("Attribute8")).SendKeys("Cupboard Under The Stairs, Privet Drive, London, England");
                DemoHelper.pause();
                driver.FindElement(By.Id("Attribute9")).SendKeys("hp_hw");
                DemoHelper.pause();
                driver.FindElement(By.Id("Attribute10")).SendKeys("Voldemort is back!!");
                driver.FindElement(By.Id("order-req-check")).Click();
                DemoHelper.pause();
                driver.FindElement(By.Id("order-req-check")).Submit();
                //driver.FindElement(By.Id("send-order-req")).Click();
                DemoHelper.pause(8000);

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(PackageAndPricingUrl, driver.Url);


            }
        }
    }
}
