using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestableCode.Slide1 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		TestPage MyAccountPage;
		LoginPage LoginPage;
		object dbContext = null;

		[Test]
		public void When_user_is_licensed_then_cycle_dates_are_visible() {
			var activeUser = UserHelper.Create(
				isLicensed: true,
				cycleEndDate: new DateTime(2018, 1, 1)
			);
			UserHelper.Save(dbContext, activeUser);

			LoginPage.LogInAs(activeUser);

			MyAccountPage.GoToPage();

			Assert.That(MyAccountPage.CycleEndDate.IsDisplayed);
		}
	}

	public static class UserHelper {
		internal static object Create(bool isLicensed, DateTime cycleEndDate) {
			throw new NotImplementedException();
		}

		internal static void Save(object dbContext, object user) {
			throw new NotImplementedException();
		}
	}

	public class TestPage : BasePageObject {
		public IWebElement CycleEndDate { get; set; }
		internal void GoToPage() {
			throw new NotImplementedException();
		}
	}

	public class LoginPage : BasePageObject {
		internal void LogInAs(object activeUser) {
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
