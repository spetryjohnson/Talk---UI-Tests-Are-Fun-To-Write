using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestableCode.Slide4 {

	public class SomePageObject {

		[FindsBy(How = How.CssSelector, Using = "tr.foo > td > span[0] > a")]
		public IWebElement SomeImportantLink { get; set; } 
	}

}
