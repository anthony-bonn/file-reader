namespace FileReader.Domain.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string FormatForDisplay(this string input)
        {
            var trailingwhitespaces = input.Length - input.TrimStart().Length;

            // empty line
            if (string.IsNullOrWhiteSpace(input))
            {
                input = "\xA0";
            }
            // starts with tab
            else if (input.StartsWith("\t"))
            {
                input = input.Replace("\t", "\xA0\xA0\xA0\xA0\xA0");
            }
            // trailing whitespaces
            else if (trailingwhitespaces > 0)
            {
                input = input.TrimStart();
                for (int i = 1; i <= trailingwhitespaces; i++)
                {
                    input = input.Insert(0, "\xA0");
                }
            }

            return input;
        }
    }
}
