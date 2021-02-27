using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securitykey)
        {
            return new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
