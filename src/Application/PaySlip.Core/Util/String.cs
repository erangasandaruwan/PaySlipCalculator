using PaySlip.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlip.Core.Util
{
    public static class String
    {
        public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new PaySlipException("Input value cannot be null"),
              "" => throw new PaySlipException("Input value cannot be empty"),
               _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
    }
}
