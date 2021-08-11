using System.Globalization;

namespace Kuant.Utils
{
    /// <summary>
    /// Useful ?
    /// </summary>
    public static class CultureManager
    {
        public static CultureInfo _culture = CultureInfo.CurrentCulture;
        public static CultureInfo Culture 
        {get => _culture;
         set {
            _culture = value;
        }}

        public static DateTimeFormatInfo _dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;

    }
}