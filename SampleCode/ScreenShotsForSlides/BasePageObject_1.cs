using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;

namespace AdvancedUITesting.ScreenShotsForSlides.BasePageObject.Slide1 {

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
}
