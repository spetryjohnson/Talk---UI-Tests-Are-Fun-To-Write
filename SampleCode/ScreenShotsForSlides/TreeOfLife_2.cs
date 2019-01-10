using System;
using System.Linq;
using AdvancedUITesting.SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TreeOfLife.Slide2 {

	public class LoginPage {

		[FindsBy(How = How.CssSelector, Using = "#Foo tr td > span[0] > a")]
		public IWebElement Foo { get; protected set; }
	}
	public class LoginPage2 {

		[FindsBy(How = How.Id, Using = "#Selenium-FooLink")]
		public IWebElement Foo { get; protected set; }
	}
}

