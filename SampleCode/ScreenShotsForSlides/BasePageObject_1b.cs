using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.BasePageObject.Slide1b {

	public abstract class BasePageObject {

		protected IWebDriver WebDriver;

		public static TPage GetInstance<TPage>(IWebDriver webDriver)
			where TPage : BasePageObject, new() {

			var pageInstance = new TPage {
				WebDriver = webDriver
			};

			PageFactory.InitElements(webDriver, pageInstance);

			return pageInstance;
		}
	}

	public class MyAccountTests : BaseUITest {
		
		MyAccountPage MyAccountPage;

		public void Setup() {
			MyAccountPage = BasePageObject.GetInstance<MyAccountPage>(WebDriver);
		}

		[Test]
		public void Does_the_thing_and_stuff() {
			MyAccountPage.DoSomethingCool_LookMaNoWebDriverNeeded();
		}
	}

	public class BaseUITest {
		protected IWebDriver WebDriver;
	}

	public class MyAccountPage : BasePageObject {
		internal void DoSomethingCool_LookMaNoWebDriverNeeded() {
			throw new NotImplementedException();
		}
	}
}
