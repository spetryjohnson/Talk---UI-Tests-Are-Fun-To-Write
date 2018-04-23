using System;
using System.Linq;
using AdvancedUITesting.SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TreeOfLife.Slide2 {

	public class LoginPage {

		[FindsBy(How = How.Id, Using = "table.Foo > tr > td > a")]
		public IWebElement Foo { get; protected set; }
	}
}

