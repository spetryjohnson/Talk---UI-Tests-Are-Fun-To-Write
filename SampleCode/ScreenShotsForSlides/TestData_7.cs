using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using AdvancedUITesting.SeleniumTests;
using NUnit.Framework;

namespace AdvancedUITesting.ScreenShotsForSlides.TestData.Slide7 {

	[TestFixture]
	public class ApplicationDataEntryFormTests {
		ApplicationFormPage DataEntryPage;

		[Test]
		public void Applicants_can_submit_application_with_fee() {
			var dataEntryForm = new DataEntryForm(
				new Credential(new Interval(), new Board()),
				new Member(new Address(), new Address())
			);
			Database.Save(dataEntryForm);

			DataEntryPage.GoToPage(id: dataEntryForm.Id);
			
			// ...
		}

		private DataEntryForm CreateSingleTabFormWithApplicationFee(decimal fee) {
			throw new NotImplementedException();
		}
	}

	public class Address {
		public Address() {
		}
	}

	public class Board {
		public Board() {
		}
	}

	public class Interval {
		public Interval() {
		}
	}

	public static class DataEntryForms {
		public const int FORM_WITH_APPLICATION_FEE = 1;
		public const int FORM_WITH_APPLICATION_FEE_MULTI_TAB = 2;
		public const int FORM_WITH_AUDIT_AND_FEE = 3;
		public const int FORM_WITH_SINGLE_FILE_UPLOAD = 4;
		public const int FORM_WITH_MULTIPLE_FILE_UPLOADS = 5;
	}

	public static class Database {
		public static T Get<T>(int id) {
			return default(T);
		}

		internal static void Save(DataEntryForm dataEntryForm) {
			throw new NotImplementedException();
		}
	}

	public class DataEntryForm {
		private Credential credential;
		private Member member;

		public DataEntryForm(Credential credential, Member member) {
			this.credential = credential;
			this.member = member;
		}

		public bool IsMultiTab { get; internal set; }
		public int Id { get; set; }
	}

	public class Credential {
		private Board board;
		private Interval interval;

		public Credential() {
		}

		public Credential(Interval interval, Board board) {
			this.interval = interval;
			this.board = board;
		}
	}

	public class Member {
		private Address address1;
		private Address address2;

		public Member() {
		}

		public Member(Address address1, Address address2) {
			this.address1 = address1;
			this.address2 = address2;
		}
	}

	public class ApplicationFormPage : BasePageObject {

	}

	public class BasePageObject {

		protected IWebDriver WebDriver;

		public virtual void GoToPage(int id) {
		}

		public static TPage GetInstance<TPage>(IWebDriver webDriver) where TPage : BasePageObject, new() {
			var pageInstance = new TPage {
				WebDriver = webDriver
			};

			PageFactory.InitElements(webDriver, pageInstance);

			return pageInstance;
		}
	}
}
