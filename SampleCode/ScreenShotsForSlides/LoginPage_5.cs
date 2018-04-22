using System;
using System.Linq;
using AdvancedUITesting.SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.PageObjects.Slide5 {

	public class LoginPage {

		[FindsBy(How = How.Id, Using = "UserName")]
		public IWebElement UserName { get; protected set; }

		[FindsBy(How = How.ClassName, Using = "some-css-class")]
		public IWebElement Password { get; protected set; }

		[FindsBy(How = How.CssSelector, Using = "#LoginForm > button")]
		public IWebElement SubmitButton { get; protected set; }

		public IWebElement ErrorMessage { get; protected set; }

		public void LoginAs(string username, string password) {

		}
	}

	[TestFixture]
	public class LoginPageTests {

		protected IWebDriver WebDriver;

		LoginPage LoginPage = new LoginPage();
		string ADMIN_USERNAME = "";
		string ADMIN_PASSWORD = "";
		string USER_USERNAME = "";
		string USER_PASSWORD = "";

		[Test]
		public void User_can_log_in() {
			LoginPage.LoginAs(ADMIN_USERNAME, ADMIN_PASSWORD);

			Assert.That(WebDriver.Url, Does.Not.Contains("login"));
		}

		[Test]
		public void Invalid_credentials_displays_failure_message() {
			LoginPage.LoginAs(ADMIN_USERNAME, "incorrect_password");

			Assert.That(LoginPage.ErrorMessage.IsDisplayed, Is.True);
		}

		[Test]
		public void When_account_is_locked_displays_failure_message() {
			// ... (setup code to lock the account goes here)
			LoginPage.LoginAs(ADMIN_USERNAME, ADMIN_PASSWORD);

			Assert.That(LoginPage.ErrorMessage.IsDisplayed, Is.True);
			Assert.That(LoginPage.ErrorMessage.Text, Contains.Substring("whatever"));
		}

		[Test]
		public void Admin_is_redirected_to_admin_dashboard() {
			LoginPage.LoginAs(ADMIN_USERNAME, ADMIN_PASSWORD);

			Assert.That(WebDriver.Url, Contains.Substring("/admin/dashboard"));
		}

		[Test]
		public void Normal_user_is_redirected_to_default_dashboard() {
			LoginPage.LoginAs(USER_USERNAME, USER_PASSWORD);

			Assert.That(WebDriver.Url, Contains.Substring("/user/dashboard"));
		}

		[Test]
		public void Triggers_password_reset_if_password_is_stale() {
			// ... (setup code to trigger password reset goes here)
			LoginPage.LoginAs(USER_USERNAME, USER_PASSWORD);

			Assert.That(WebDriver.Url, Contains.Substring("/passwordReset"));
		}
	}
}

