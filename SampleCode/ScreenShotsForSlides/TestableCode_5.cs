using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestableCode.Slide5 {

	public class SomePageObject {

		[FindsBy(How = How.CssSelector, Using = "a.selenium-SomeImportantLink")]
		public IWebElement SomeImportantLink { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#Selenium-SomeImportantLink")]
		public IWebElement AnotherImportantLink { get; set; }
	}

}
