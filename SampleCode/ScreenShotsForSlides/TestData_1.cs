using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide1 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {

		IWebDriver WebDriver;
		ApplicationFormPage DataEntryPage;

		[Test]
		public void Applicants_can_submit_data_entry_form() {
			DataEntryPage.GoToPage(id: 0);	
			
			// test body goes here...
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
