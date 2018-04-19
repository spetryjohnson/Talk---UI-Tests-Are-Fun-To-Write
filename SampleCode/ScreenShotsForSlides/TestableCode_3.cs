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

		[TestCase(true, "1/1/2018")]
		[TestCase(false, "Not licensed")]
		public void When_user_is_licensed_then_shows_cycle_dates(bool licensed, string date) {
			var user = UserHelper.Create(
				isLicensed: licensed,
				cycleEndDate: licensed ? DateTime.Parse(date) : DateTime.MinValue
			);

			var model = new MyAccountViewModel(user);
			var result = model.RenderCycleDates();

			Assert.That(result, Is.EqualTo(date));
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
			internal static User Create(bool isLicensed, DateTime? cycleEndDate) {
				throw new NotImplementedException();
			}

			internal static void Save(object dbContext, object user) {
				throw new NotImplementedException();
			}
		}
	}
}
