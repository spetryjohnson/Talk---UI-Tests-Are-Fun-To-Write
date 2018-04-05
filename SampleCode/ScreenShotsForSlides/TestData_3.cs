using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;


namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide3 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {

		IWebDriver WebDriver;
		ApplicationFormPage DataEntryPage;

		[Test]
		public void Multi_tab_application_with_fee() {
			Database.ExecSql(@"
				update	DATA_FORMS 
				set		IS_MULTI_TAB = true
				where	ID = {0}"
			, DataEntryForms.FORM_WITH_APPLICATION_FEE);

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

	public static class Database {
		internal static void ExecSql(string v, int fORM_WITH_APPLICATION_FEE) {
			throw new NotImplementedException();
		}
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
