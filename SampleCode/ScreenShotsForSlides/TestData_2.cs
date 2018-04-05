using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;


namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide2 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {

		IWebDriver WebDriver;
		ApplicationFormPage DataEntryPage;

		[Test]
		public void Applicants_can_submit_application_with_fee() {
			DataEntryPage.GoToPage(
				DataEntryForms.FORM_WITH_APPLICATION_FEE
			); // ...
		}
	}

	public static class DataEntryForms {
		public const int FORM_WITH_APPLICATION_FEE = 1;
		public const int FORM_WITH_MULTI_TABBED_UI = 2;
		public const int FORM_WITH_MANUAL_REVIEW_STEP = 3;
	}


	public class DataEntryForm { }

	public class ApplicationFormPage : BasePageObject {

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
