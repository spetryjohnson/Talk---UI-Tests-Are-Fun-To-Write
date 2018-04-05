using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AdvancedUITesting.SeleniumTests {

	public static class WebDriverExtensions {

		public static void WaitForAjax(this IWebDriver driver, double waitSeconds = 30, int sleepBefore = 500) {
			Thread.Sleep(sleepBefore); // May take a half second for the overlay to appear on an ajax call
			WaitTilElementDisappears(driver, By.ClassName("blockOverlay"), waitSeconds);
		}

		public static void WaitForElement(this IWebDriver driver, By @by, double waitSeconds = 30) {
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
			wait.Until(ExpectedConditions.ElementIsVisible(by));
		}

		public static void WaitTilElementDisappears(this IWebDriver driver, By @by, double waitSeconds = 30) {
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
			wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));

		}
	}
}
