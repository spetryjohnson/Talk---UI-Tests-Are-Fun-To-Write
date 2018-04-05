using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedUITesting.Web.Models {
	public class SomeHelper {
		public bool Foo { get; set; }
		public bool Bar { get; set; }
		public bool Bat { get; set; }

		public bool IsLicensed { get; set; }
		public string CycleEndDate { get; set; }

		public string RenderWhatever(bool x, bool y, bool z) {
			return null;
		}

		public string RenderCycleDates() {
			return null;
		}
	}

}