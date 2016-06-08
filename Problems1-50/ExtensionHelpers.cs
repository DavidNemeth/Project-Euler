using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems1_50
{
    public static class ExtensionHelpers
    {
        public static string Reverse(this int input)
        {
            return new string(input.ToString().ToCharArray().Reverse().ToArray());
        }
    }
}
