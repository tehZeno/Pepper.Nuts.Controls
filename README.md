
1.0.0 - Initial release to NuGet
- Introduces TimeOnlyInputFilter for use with EditText's on android
  (will only allow times in the format HH:mm )
- Also supply a custom EditText control (TimeOnlyEditText) that has the
  inputfilter as it's default.

1.0.1
- Make sure we can set times to a max of 23:59 instead of 24:XX  
