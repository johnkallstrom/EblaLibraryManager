namespace EblaLibraryManager.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsDigitsOnly(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string EnsureEndsWithDots(this string value)
        {
            if (!value.EndsWith("...")) return $"{value}...";
            return value;
        }
    }
}
