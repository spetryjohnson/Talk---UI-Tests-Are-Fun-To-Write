using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide8 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		ApplicationFormPage DataEntryPage;
		object dbContext = null;

		[Test]
		public void Applicants_can_submit_application_with_fee() {
			// create in memory (all tests do this)
			var dataEntryForm = DataEntryFormHelper.Create(
				fee: 50.00m
			);

			// save to disk (for data/integration/UI tests)
			DataEntryFormHelper.Save(dbContext, dataEntryForm);

			DataEntryPage.GoToPage(id: dataEntryForm.Id);
			
			// ...
		}

		private DataEntryForm CreateSingleTabFormWithApplicationFee(decimal fee) {
			throw new NotImplementedException();
		}
	}

	public static class DataEntryFormHelper {
		internal static DataEntryForm Create(decimal fee) {
			return null;
		}

		internal static void Save(object dbContext, DataEntryForm dataEntryForm) {
			throw new NotImplementedException();
		}
	}

	public class DataEntryForm {
		public bool IsMultiTab { get; internal set; }
		public int Id { get; set; }
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
