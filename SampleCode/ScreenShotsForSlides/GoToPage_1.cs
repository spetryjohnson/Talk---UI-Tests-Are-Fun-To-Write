using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;

namespace AdvancedUITesting.ScreenShotsForSlides.GoToPage.Slide1 {

	public abstract class BasePageObject {
		protected IWebDriver WebDriver;

		protected void GoToUrl(string url) {

		}
	}

	public class LoginPage : BasePageObject {

		public void GoToPage(string redirectTo = null) {
			var url = $"/Account/Login?redirectTo={redirectTo ?? "/"}";
			base.GoToUrl(url);
		}
	}


	public class MemberDetailsPage : BasePageObject {

		public void GoToPage(int memberId) {
			var url = $"/Member/View?id={memberId}";
			base.GoToUrl(url);
		}
	}


	public static class Extensions {
		public static void WaitForPageLoad(this BasePageObject p) {

		}
	}
}
