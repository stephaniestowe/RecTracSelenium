using System;
using System.Linq;

namespace RecTracActions
{
    public static class Utilities
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetCurrentYearString() => DateTime.Now.Year.ToString();

    }
}
