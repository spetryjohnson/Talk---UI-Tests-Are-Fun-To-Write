using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.PageObject.Slide1 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		LoginPage LoginPage;
		object dbContext = null;

		[Test]
		public void Administrator_logs_in_and_lands_on_dashboard() {
			LoginPage.GoToPage(); 

			var landingPage = LoginPage.LogInAsAdmin();

			Assert.That(landingPage, Is.InstanceOf<DashboardPage>());
		}
	}

	public static class UserHelper {
		public static object Create(bool active) {
			throw new NotImplementedException();
		}

		internal static void Save(object dbContext, object user) {
			throw new NotImplementedException();
		}
	}

	public class DashboardPage : BasePageObject {
		public IWebElement EmailAddress { get; set; }
		internal void GoToPage() {
			throw new NotImplementedException();
		}
	}

	public class LoginPage : BasePageObject {
		internal BasePageObject LogInAsAdmin() {
			throw new NotImplementedException();
		}
		internal void GoToPage() {
			throw new NotImplementedException();
		}
	}

	public class BasePageObject {

		protected IWebDriver WebDriver;

		public virtual void GoToPage(int id) {
		}

		public static TPage GetInstance<TPage>(IWebDriver webDriver) where TPage : BasePageObject, new() {
			var pageInstance = new TPage {
				WebDriver = webDriver
			};

			PageFactory.InitElements(webDriver, pageInstance);

			return pageInstance;
		}
	}
}
