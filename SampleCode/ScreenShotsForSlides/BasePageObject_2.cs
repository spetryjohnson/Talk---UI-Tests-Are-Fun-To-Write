using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;

namespace AdvancedUITesting.ScreenShotsForSlides.BasePageObject.Slide2 {

	public abstract class BasePageObject {

		protected IWebDriver WebDriver;
		protected IJavaScriptExecutor JsDriver => (IJavaScriptExecutor)WebDriver;

		public static string BaseUrl { get; } = ConfigurationManager.AppSettings["BaseUrl"];
		public abstract string PageRelativeUrl { get; }
		public string QueryString { get; set; }
		public string PageUrl => new Uri(new Uri(BaseUrl), PageRelativeUrl + QueryString).ToString();

		public string PageTitle => this.WebDriver.Title;
		public string BrowserUrl => this.WebDriver.Url;

		public virtual void GoToPage() {
			this.WebDriver.Navigate().GoToUrl(this.PageUrl);
			this.WaitForPageLoad();
			this.WaitForAjax();
		}

		public virtual void GoToHttpsPage() {
			var secureUrl = this.PageUrl.Replace("http", "https");
			this.WebDriver.Navigate().GoToUrl(secureUrl);
		}

		public virtual bool IsAt() {
			var driverUri = new Uri(this.WebDriver.Url);
			var pageUri = new Uri(this.PageUrl);
			return pageUri.LocalPath == driverUri.LocalPath;
		}

		public static TPage GetInstance<TPage>(IWebDriver webDriver) where TPage : BasePageObject, new() {
			var pageInstance = new TPage {
				WebDriver = webDriver
			};

			PageFactory.InitElements(webDriver, pageInstance);

			return pageInstance;
		}

		public void WaitForPageLoad(int maxWaitTimeInSeconds = 30) {
			var state = string.Empty;

			try {
				var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

				//Checks every 500 ms whether predicate returns true if returns exit otherwise keep trying till it returns ture
				wait.Until(
					d => {

						try {
							state = ((IJavaScriptExecutor)WebDriver).ExecuteScript(@"return document.readyState").ToString();
						}
						catch (InvalidOperationException) {
							//Ignore
						}
						catch (NoSuchWindowException) {
							//when popup is closed, switch to last windows
							WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
						}

						//In IE7 there are chances we may get state as loaded instead of complete
						return state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) ||
							   state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase);

					});
			}
			catch (TimeoutException) {
				//sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
				if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase)) {
					throw;
				}
			}
			catch (NullReferenceException) {
				//sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
				if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase)) {
					throw;
				}
			}
			catch (WebDriverException) {
				if (WebDriver.WindowHandles.Count == 1) {
					WebDriver.SwitchTo().Window(WebDriver.WindowHandles[0]);
				}
				state = ((IJavaScriptExecutor)WebDriver).ExecuteScript(@"return document.readyState").ToString();
				if (!(state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) ||
					  state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase))) {
					throw;
				}
			}
		}

		public void Wait(double delay, double interval) {
			// Causes the WebDriver to wait for at least a fixed delay
			var now = DateTime.Now;
			var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromMilliseconds(delay));
			wait.PollingInterval = TimeSpan.FromMilliseconds(interval);
			wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromMilliseconds(delay) > TimeSpan.Zero);
		}

		public void LogoutAjax() {
			this.WebDriver.ExecuteJavaScript("$.ajax(\'/Account/Logout/\', {async: false, success:function() {$('body').append(\"<div id='loggedOut'>loggedOut</div>\");}})");
			new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(30)).Until(
				ExpectedConditions.ElementExists(By.Id("loggedOut")));
			WaitForAjax();
		}

		public void PopulateRichTextField(string field, string value) {
			this.WebDriver.ExecuteJavaScript($"CKEDITOR.instances['{field}'].setData('{value}')");
		}

		public void WaitForAjax(double waitSeconds = 30D, int sleepBefore = 500) {
			WebDriver.WaitForAjax(waitSeconds, sleepBefore);
		}

		public void Logout() {
			WebDriver.Navigate().GoToUrl(new Uri(new Uri(BaseUrl), "/Account/Logout").ToString());
			try {
				var alert = this.WebDriver.SwitchTo().Alert();
				alert.Accept();
			}
			catch (NoAlertPresentException) {

			}
			this.WaitForPageLoad();
		}
	}
}
