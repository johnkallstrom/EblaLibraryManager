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
    }
}
