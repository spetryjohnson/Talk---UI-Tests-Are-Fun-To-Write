using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide4 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {

		[Test]
		public void Applicants_can_submit_application_with_fee() {
			var formToRender = Database.Get<DataEntryForm>(
				DataEntryForms.FORM_WITH_APPLICATION_FEE
			);

			formToRender.IsMultiTab = true;

			// ... 
		}
	}

	public static class DataEntryForms {
		public const int FORM_WITH_APPLICATION_FEE = 1;
		public const int FORM_WITH_APPLICATION_FEE_MULTI_TAB = 2;
		public const int FORM_WITH_AUDIT_AND_FEE = 3;
		public const int FORM_WITH_SINGLE_FILE_UPLOAD = 4;
		public const int FORM_WITH_MULTIPLE_FILE_UPLOADS = 5;
	}

	public static class Database {
		public static T Get<T>(int id) {
			return default(T);
		}
	}

	public class DataEntryForm {
		public bool IsMultiTab { get; internal set; }
	}
}
