using System;

namespace TheDark
{
    public static class IntExtensions
    {
        public static string SecondsToTimeString(this int seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);

            return time.ToString(@"mm\:ss");
        }
    }
}