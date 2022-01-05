namespace ASP.NETCORE5._0.Utility
{
    public static class SharedCommonFunction
    {
        public static string Truncate(this string text, int maxLength, string suffix = "...")
        {
            return text != null && text.Length > maxLength ? text.Substring(0, maxLength) + suffix : text;
        }
    }
}