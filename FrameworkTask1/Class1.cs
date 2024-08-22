using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Linq;

namespace FrameworkTask1
{
    public class WebDriverTest
    {
        private IWebDriver _driver;
        private WebDriverManager webDriverManager;
        

        [Test]
        public void GoogleSearch()
        {
            try
            {
                webDriverManager = new WebDriverManager();
                _driver = webDriverManager.GetDriver();

                _driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");

                var calculatorPage = new CalculatorPage(_driver);

                calculatorPage.ClickTxtField();
                Thread.Sleep(3000);
                calculatorPage.ClickComputeEngineButton();
                Thread.Sleep(3000);
                calculatorPage.ClickInputField(3);
                calculatorPage.SelectFirstDropdownOption();
                calculatorPage.ToggleSecondSwitch();
                Thread.Sleep(3000);
                calculatorPage.SelectThirdDropdownOption();
                calculatorPage.SelectFourthDropdownOption();
                Thread.Sleep(1000);
                calculatorPage.SelectFifthDropdownOption();
                Thread.Sleep(4000);

                calculatorPage.ClickShareButton();
                Thread.Sleep(3000);

                string firstPagePrice = calculatorPage.GetFirstPagePrice();

                calculatorPage.ClickEstimateButton();

                calculatorPage.SwitchToLastWindow();

                string secondPagePrice = calculatorPage.GetSecondPagePrice();

                string firstPagePriceNumeric = new string(firstPagePrice.Where(char.IsDigit).ToArray());
                string secondPagePriceNumeric = new string(secondPagePrice.Where(char.IsDigit).ToArray());

                if (firstPagePriceNumeric == secondPagePriceNumeric)
                {
                    Console.WriteLine("The prices match: " + firstPagePrice);
                }
                else
                {
                    Console.WriteLine("The prices do not match. First page: " + firstPagePrice + ", Second page: " + secondPagePrice);
                }
            }
            catch (Exception ex)
            {
                var calculatorPage = new CalculatorPage(_driver);
                calculatorPage.TakeScreenshot();
                Console.WriteLine("Test failed: " + ex.Message);
            }
            finally
            {
                webDriverManager.QuitDriver();
            }
        }
    }
}