using Microsoft.AspNetCore.Authentication;
using System;

namespace EDES.Auth
{
    public class ApiKeyAuthOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentNullException(nameof(ApiKey));
            }
        }
    }
}