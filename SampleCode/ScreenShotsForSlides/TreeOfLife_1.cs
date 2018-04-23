using System;
using System.Linq;
using AdvancedUITesting.SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TreeOfLife.Slide1 {

	public class LoginPage {

		[FindsBy(How = How.Id, Using = "CycleExpiredFlag")]
		public IWebElement CycleExpired { get; protected set; }
	}
}

