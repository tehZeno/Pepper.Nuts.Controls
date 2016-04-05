using System;
using Android.Runtime;
using Android.Widget;

using Android.Util;
using Android.Text;
using Android.Content;

namespace PepperNuts.Android.Controls {
	
	[Register("PepperNuts.Android.Controls.TimeOnlyEditText")]
	public class TimeOnlyEditText : EditText {
		public TimeOnlyEditText (Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context,attrs,defStyleAttr,defStyleRes) {
			SetTimeFilter();
		}

		public TimeOnlyEditText (Context context, IAttributeSet attrs, int defStyleAttr) : base(context,attrs,defStyleAttr) {
			SetTimeFilter();
		}

		public TimeOnlyEditText (Context context, IAttributeSet attrs) : base(context,attrs) {
			SetTimeFilter();
		}

		private void SetTimeFilter() {
			// time filters:
			var timeOnlyInputFilter = new IInputFilter[]{ new TimeOnlyInputFilter () };
			this.SetFilters(timeOnlyInputFilter);
			this.SetSelectAllOnFocus (true); // make sure we always select all the text when we focus.
		}

	}
}

