using System.Text.RegularExpressions;

namespace EblaLibraryManager.Core.Utilities
{
    public static class RegexUtilities
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
