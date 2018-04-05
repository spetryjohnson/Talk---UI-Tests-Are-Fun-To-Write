using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.PageObject.Slide2 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		SomeFeaturePage SomeFeaturePage;
		object dbContext = null;

		[Test]
		public void Can_configure_a_ComparisonRule() {

			SomeFeaturePage.DoTheThing();

			var compRuleEditor = SomeFeaturePage.ConfigureComparisonRule();
			compRuleEditor.ConfigureRule("some", "params", "for", "whatever");

			SomeFeaturePage.SubmitForm();

			// Assert.Whatever()
		}
	}

	public class ComparisonRulePage : BasePageObject {
		public IWebElement EmailAddress { get; set; }

		internal void ConfigureRule(string v1, string v2, string v3, string v4) {
			throw new NotImplementedException();
		}

		internal void GoToPage() {
			throw new NotImplementedException();
		}
	}

	public class SomeFeaturePage : BasePageObject {
		internal BasePageObject LogInAsAdmin() {
			throw new NotImplementedException();
		}
		internal void GoToPage() {
			throw new NotImplementedException();
		}
		public ComparisonRulePage ConfigureComparisonRule() { return null; }

		internal void DoTheThing() {
			throw new NotImplementedException();
		}

		internal void SubmitForm() {
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
