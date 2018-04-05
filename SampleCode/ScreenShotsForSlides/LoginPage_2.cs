using System;
using System.Linq;
using AdvancedUITesting.SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace AdvancedUITesting.ScreenShotsForSlides.PageObjects.Slide2 {

	public class LoginPage {

		[FindsBy(How = How.Id, Using = "UserName")]
		public IWebElement UserName { get; protected set; }

		[FindsBy(How = How.ClassName, Using = "some-css-class")]
		public IWebElement Password { get; protected set; }

		[FindsBy(How = How.CssSelector, Using = "#LoginForm > button")]
		public IWebElement SubmitButton { get; protected set; }

		public void LoginAs(string emailAddress, string password) {
			findElementWithId("UserName").SetText(emailAddress);
			findElementsWithClass("password-class").First().SetText(password);
			findElementsByCSS("#LoginForm > button").First().Click();
		}

		private List<FakeWebElement> findElementsByCSS(string v) {
			throw new NotImplementedException();
		}

		private List<FakeWebElement> findElementsWithClass(string v) {
			throw new NotImplementedException();
		}

		private FakeWebElement findElementWithId(string v) {
			throw new NotImplementedException();
		}

		private class FakeWebElement {
			public void SetText(string s) { }
			public void Click() { }
		}
	}
}

