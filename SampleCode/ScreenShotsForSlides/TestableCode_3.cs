using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestableCode.Slide3 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {

		[TestCase(true)]
		[TestCase(false)]
		public void When_user_is_licensed_then_cycle_dates_are_visible(bool licensed) {
			var user = UserHelper.Create(
				isLicensed: licensed,
				cycleEndDate: new DateTime(2018, 1, 1)
			);

			var model = new MyAccountViewModel(user);
			var result = model.RenderCycleDates();

			if (licensed) {
				Assert.That(result, Is.EqualTo(user.CycleEnd));
			}
			else {
				Assert.That(result, Is.EqualTo("Not licensed"));
			}
		}

		internal class MyAccountViewModel {
			private object activeUser;

			public MyAccountViewModel(object activeUser) {
				this.activeUser = activeUser;
			}

			internal string RenderCycleDates() {
				throw new NotImplementedException();
			}
		}

		public class User {
			public string CycleEnd { get; set; }
		}

		public static class UserHelper {
			internal static User Create(bool isLicensed, DateTime cycleEndDate) {
				throw new NotImplementedException();
			}

			internal static void Save(object dbContext, object user) {
				throw new NotImplementedException();
			}
		}
	}
}
