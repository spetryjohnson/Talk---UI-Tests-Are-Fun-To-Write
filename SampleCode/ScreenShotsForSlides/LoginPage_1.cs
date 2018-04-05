using System.Linq;
using AdvancedUITesting.SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AdvancedUITesting.ScreenShotsForSlides.PageObjects.Slide1 {

	public class LoginPage {

		[FindsBy(How = How.Id, Using = "UserName")]
		public IWebElement UserName { get; protected set; }

		[FindsBy(How = How.ClassName, Using = "some-css-class")]
		public IWebElement Password { get; protected set; }

		[FindsBy(How = How.CssSelector, Using = "#LoginForm > button")]
		public IWebElement SubmitButton { get; protected set; }

		public void LoginAs(string emailAddress, string password) {
			UserName.ClearAndSendKeys(emailAddress);
			Password.ClearAndSendKeys(password);
			SubmitButton.Click();
		}
	}
}

