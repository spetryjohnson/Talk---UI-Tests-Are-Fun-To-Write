using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AdvancedUITesting.SeleniumTests {

	public static class IWebElementExtensions {

		public static IWebElement Parent(this IWebElement child) {
			return child.FindElement(By.XPath(".."));
		}

		public static void RightClick(this IWebElement element, IWebDriver driver) {
			var action = new Actions(driver).ContextClick(element);
			action.Build().Perform();
		}

		public static void ClearAndSendKeys(this IWebElement webElement, string text) {
			webElement.Clear();
			webElement.SendKeys(text);
		}

		/// <summary>
		/// Convenience method to wrap the IWebElement's Displayed property. This should be used
		/// anytime we want to check if an element is displayed so that we don't have to wrap
		/// every call to Displayed in a try/catch block.
		/// </summary>
		public static bool IsDisplayed(this IWebElement webElement) {
			// this try/catch is due to selenium using exceptions to indicate 
			// search failures rather than an empty result or null
			try {
				return webElement.Displayed;
			}
			catch {
				return false;
			}
		}

		public static string Value(this IWebElement webElement) {
			return webElement.GetAttribute("value");
		}

		public static void SetCheckboxSelected(this IWebElement webElement, bool isChecked) {
			if (webElement.Selected != isChecked) {
				webElement.Click();
			}
		}

		public static void SelectFromDropdown(this IWebElement element, string value) {
			new SelectElement(element).SelectByText(value);
		}

		public static IWebElement FindAncestorByClassName(this IWebElement element, string className) {
			IWebElement current = element.Parent().Parent();
			while (current.FindElements(By.ClassName(className)).Count == 0) {
				current = current.Parent();
			}

			return current.FindElement(By.ClassName(className));
		}
	}
}
