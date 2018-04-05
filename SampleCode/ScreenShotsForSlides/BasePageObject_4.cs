using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;

namespace AdvancedUITesting.ScreenShotsForSlides.BasePageObject.Slide4 {

	public abstract class BasePageObject {
		protected IWebDriver WebDriver;
		public abstract string PageRelativeUrl { get; }
	}

	public class SomePageObject : BasePageObject {

		public override string PageRelativeUrl => "/path?id={id}&filter={keyword}";

		public SomePageObject GoToPage(int id, string keyword = null) {
			var url = PageRelativeUrl
				.Replace("{id}", id.ToString())
				.Replace("{keyword}", keyword);
			this.WebDriver.Navigate().GoToUrl(PageRelativeUrl);
			this.WaitForPageLoad();
			return this;
		}
	}



	public static class Extensions {
		public static void WaitForPageLoad(this BasePageObject p) {

		}
	}
}
