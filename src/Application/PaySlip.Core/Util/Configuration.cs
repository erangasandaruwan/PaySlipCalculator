using Microsoft.Extensions.Configuration;
using PaySlip.Application.Core;
using System;

namespace PaySlip.Core.Util
{
    public static class Config
    {
        public static IConfiguration Configuration;

        public static T Get<T>(string key)
        {
            if (Configuration == null)
                throw new PaySlipException("Configurations are not set");

            return (T)Convert.ChangeType(Configuration[key], typeof(T));
        }
    }
}
