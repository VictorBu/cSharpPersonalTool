using System;

namespace VictorBu.Tool
{
    public class StringHelper
    {
        /// <summary>
        /// 字符串反转
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string Reverse(string original)
        {
            char[] charArray = original.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
