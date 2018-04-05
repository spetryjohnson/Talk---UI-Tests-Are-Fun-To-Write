using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestableCode.Slide2 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {

		[Test]
		public void When_user_is_licensed_then_cycle_dates_are_visible() {
			var user = UserHelper.Create(
				isLicensed: true,
				cycleEndDate: new DateTime(2018, 1, 1)
			);

			var model = new MyAccountViewModel(user);
			var result = model.RenderCycleDates();

			Assert.That(result, Is.EqualTo(user.CycleEnd));
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
