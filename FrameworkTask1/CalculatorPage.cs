﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask1
{
    public class CalculatorPage
    {
        private IWebDriver _driver;

        public CalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void TakeScreenshot()
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string fileName = $"screenshot_{timestamp}.png";

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                screenshot.SaveAsFile(filePath);
                Console.WriteLine($"Screenshot saved: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to take a screenshot: {ex.Message}");
            }
        }

        private IWebElement TxtField => _driver.FindElement(By.XPath("//*[@id=\"ucj-1\"]/div/div/div/div/div/div/div/div[2]/div[1]/div/div[2]/div/button"));
        private IWebElement ComputeEngineButton => _driver.FindElement(By.XPath("//div[@role='button' and .//h2[text()='Compute Engine']]"));
        private IWebElement InputField => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[2]/div/div/div/div/div[2]/div[1]/div[3]/div[3]/button/div"));
        private IWebElement FirstDropdown => _driver.FindElement(By.XPath("//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[11]/div/div/div[2]/div/div[1]/div[3]/div/div/div/div[1]/div"));
        private IWebElement FirstOption => _driver.FindElement(By.XPath("//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[11]/div/div/div[2]/div/div[1]/div[3]/div/div/div/div[2]/ul/li[7]"));
        private IWebElement SecondSwitch => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[21]/div/div/div[1]/div/div/span/div/button/div/span[1]"));
        private IWebElement ThirdDropdown => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[1]/div"));
        private IWebElement ThirdOption => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[2]/ul/li[2]"));
        private IWebElement FourthDropdown => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[1]/div"));
        private IWebElement FourthOption => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[2]/ul/li[3]"));
        private IWebElement FifthDropdown => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[29]/div/div[1]/div/div/div/div[1]/div"));
        private IWebElement FifthOption => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[29]/div/div[1]/div/div/div/div[2]/ul/li[5]"));
        private IWebElement ShareButton => _driver.FindElement(By.XPath("//*[@id=\"ow5\"]/div/div/div/div/div/div/div[2]/div[1]/div/div[4]/div[2]/div[2]/div/button/span[5]/i"));
        private IWebElement FirstPagePriceElement => _driver.FindElement(By.XPath("//*[@id='yDmH0d']/div[5]/div[2]/div/div/div/div[2]/div[1]/div/div/label"));
        private IWebElement EstimateButton => _driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/div[5]/div[2]/div/div/div/div[1]/a"));
        private IWebElement SecondPagePriceElement => _driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[1]/div/div[1]/div[1]/h4"));
        public void ClickTxtField() => TxtField.Click();
        public void ClickComputeEngineButton() => ComputeEngineButton.Click();
        public void ClickInputField(int times)
        {
            for (int i = 0; i < times; i++)
            {
                InputField.Click();
            }
        }
        public void SelectFirstDropdownOption()
        {
            FirstDropdown.Click();
            FirstOption.Click();
        }

        public void ToggleSecondSwitch() => SecondSwitch.Click();
        public void SelectThirdDropdownOption()
        {
            ThirdDropdown.Click();
            ThirdOption.Click();
        }
       
        public void SelectFourthDropdownOption()
        {
            FourthDropdown.Click();
            FourthOption.Click();
        }

        public void SelectFifthDropdownOption()
        {
            FifthDropdown.Click();
            FifthOption.Click();
        }

        public void SwitchToLastWindow()
        {
            var windows = _driver.WindowHandles;
            _driver.SwitchTo().Window(windows.Last());
        }

        public void ClickShareButton() => ShareButton.Click();
        public void ClickEstimateButton() => EstimateButton.Click();
        public string GetFirstPagePrice() => FirstPagePriceElement.Text;
        public string GetSecondPagePrice() => SecondPagePriceElement.Text;
    }

}