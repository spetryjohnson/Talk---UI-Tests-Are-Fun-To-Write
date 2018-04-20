using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide5 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		ApplicationFormPage DataEntryPage;
		LoginPage LoginPage;

		[Test]
		public void Applicants_can_submit_application_with_fee() {
			var dataEntryForm = new DataEntryForm(
				fee: 42.00m
			);
			Database.Save(dataEntryForm);

			LoginPage.LogInAsApplicant();
			DataEntryPage.GoToPage(id: dataEntryForm.Id);
			
			// ...
		}

		private DataEntryForm CreateSingleTabFormWithApplicationFee(decimal fee) {
			throw new NotImplementedException();
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

		internal static void Save(DataEntryForm dataEntryForm) {
			throw new NotImplementedException();
		}
	}

	public class DataEntryForm {
		private bool multiTab;

		public DataEntryForm(bool multiTab = false, decimal fee = 0m) {
			this.multiTab = multiTab;
		}

		public bool IsMultiTab { get; internal set; }
		public int Id { get; set; }
	}

	public class ApplicationFormPage : BasePageObject {

	}

	public class LoginPage : BasePageObject {
		public void LogInAsApplicant() { }
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
