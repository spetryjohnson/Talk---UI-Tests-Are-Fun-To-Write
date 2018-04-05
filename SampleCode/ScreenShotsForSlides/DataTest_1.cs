using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdvancedUITesting.ScreenShotsForSlides.DataTest.Slide1 {

	public class SomeSearchComponent {

		public List<Foo> Search(
			string keyword = null, 
			int? categoryId = null, 
			List<int> memberIds = null,
			bool includeDeleted = false) {

			// dynamically build a query and execute it
			return null;
		}
	}

	public class Foo { }

}
