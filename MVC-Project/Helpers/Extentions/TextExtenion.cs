using System;
namespace MVC_Project.Helpers.Extentions
{
    public static class TextExtension
    {
        public static string Truncate(this string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }

            return source;
        }
    }
}

