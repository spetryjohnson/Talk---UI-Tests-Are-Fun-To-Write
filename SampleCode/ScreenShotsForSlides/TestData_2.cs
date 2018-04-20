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
		public void Applicants_can_submit_data_entry_form() {
			DataEntryPage.GoToPage(
				DataEntryForms.SAMPLE_FORM
			); 
			
			// test body goes here...
		}
	}

	public static class DataEntryForms {
		public const int SAMPLE_FORM = 1;
		public const int FORM_WITH_APPLICATION_FEE = 2;
		public const int FORM_WITH_MULTI_TABBED_UI = 3;
		public const int FORM_WITH_MANUAL_REVIEW_STEP = 4;
		public const int FORM_WITH_APPLICATION_FEE_MULTI_TAB = 5;
		public const int FORM_WITH_REVIEW_STEP_BY_EXTERNAL_USER = 6;
		public const int FORM_WITH_SINGLE_FILE_UPLOAD = 7;
		public const int FORM_WITH_MULTIPLE_FILE_ULOADS = 8;
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
