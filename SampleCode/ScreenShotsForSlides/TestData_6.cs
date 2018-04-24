using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide6 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		ApplicationFormPage DataEntryPage;

		[Test]
		public void Applicants_can_submit_application_with_fee() {
			var dataEntryForm = new DataEntryForm(
				fee: 42.00m,
				credential: new Credential(),
				owner: new Member()
			);
			Database.Save(dataEntryForm);

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
		private Credential credential;
		private Member member;

		public DataEntryForm(decimal fee, Credential credential, Member owner) {
			this.credential = credential;
			this.member = owner;
		}

		public bool IsMultiTab { get; internal set; }
		public int Id { get; set; }
	}

	public class Credential {
		public Credential() {
		}
	}

	public class Member {
		public Member() {
		}
	}

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
