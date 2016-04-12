using System;
using Android.Text;

namespace PepperNuts.Android.Controls {
	public class TimeOnlyInputFilter : Java.Lang.Object, IInputFilter {
		#region IInputFilter implementation
		public Java.Lang.ICharSequence FilterFormatted (Java.Lang.ICharSequence newInput, int newStart, int newEnd, ISpanned target, int targetStart, int targetEnd) {
			// Android expects a string with the filtered result. We pass an empty string every time we get a edit that is not allowed:
			Java.Lang.String DO_NOT_ALLOW_EDIT = new Java.Lang.String (string.Empty);
			// Android expects a null when there is nothing to filter:
			Java.Lang.String ALLOW_EDIT = null;

			if (newInput.Length() == 0) {
				return ALLOW_EDIT;// new input is empty, means we are deleting. We'll allow it
			}

			try {
				String result = "";
				result += target.ToString().Substring(0, targetStart);
				result += newInput.ToString().Substring(newStart, newEnd);
				result += target.ToString().Substring(targetEnd, target.Length()-targetEnd);

				if (result.Length > 5) {
					return DO_NOT_ALLOW_EDIT;// do not allow this edit
				}
				bool allowChange = true;
				char c;
				if (result.Length > 0) {
					// [h]h:mm
					c = result[0];
					allowChange &= (c >= '0' && c <= '2' && !(char.IsLetter(c)));
				}
				if (result.Length > 1) {
					// h[h]:mm
					c = result[1];
					if (result[0] == '2') {
						// 20-23 is allowed
						allowChange &= (c >= '0' && c <= '3' && !(char.IsLetter(c)));
					} else {
						// 00-19 is allowed
						allowChange &= (c >= '0' && c <= '9' && !(char.IsLetter(c)));
					}
				}
				if (result.Length > 2) {
					// hh[:]mm
					c = result[2];
					allowChange &= (c == ':'&&!(char.IsLetter(c)));
				}
				if (result.Length > 3) {
					// hh:[m]m
					c = result[3];
					allowChange &= (c >= '0' && c <= '5' && !(char.IsLetter(c)));
				}
				if (result.Length > 4) {
					// hh:m[m]
					c = result[4];
					allowChange &= (c >= '0' && c <= '9'&& !(char.IsLetter(c)));
				}
				return allowChange ? ALLOW_EDIT : DO_NOT_ALLOW_EDIT;

			} catch(Exception) {
				return ALLOW_EDIT; // we can't filter, we will just allow it.
			}
		}
		#endregion
	}
}

