using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDES.Auth
{
    public static class ApiKeyAuthExtensions
    {
        public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return builder.AddApiKey(options =>
            {
                options.ApiKey = key;
            });
        }

        public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, Action<ApiKeyAuthOptions> configureOptions)
        {
            return builder.AddScheme<ApiKeyAuthOptions, ApiKeyAuthHandler>(ApiKeyAuthDefaults.AuthenticationScheme, null, configureOptions);
        }
    }
}
