using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szop.Authentication
{
    public class AuthenticationModule
    {
        //private const string communicationKey = "GQDstc21ewfffffffffffFiwDffVvVBrk";
        //SecurityKey signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));


        //// The Method is used to generate token for user
        //public string GenerateTokenForUser(string userName, int userId)
        //{


        //    var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
        //    var now = DateTime.UtcNow;
        //    var signingCredentials = new SigningCredentials(signingKey,
        //       SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

        //    var claimsIdentity = new ClaimsIdentity(new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, userName),
        //        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        //    }, "Custom");

        //    var securityTokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        AppliesToAddress = "http://www.example.com",
        //        TokenIssuerName = "self",
        //        Subject = claimsIdentity,
        //        SigningCredentials = signingCredentials,
        //        Lifetime = new Lifetime(now, now.AddYears(1)),
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
        //    var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

        //    return signedAndEncodedToken;

        //}

        ///// Using the same key used for signing token, user payload is generated back
        //public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        //{

        //    var tokenValidationParameters = new TokenValidationParameters()
        //    {
        //        ValidAudiences = new string[]
        //              {
        //            "http://www.example.com",
        //              },

        //        ValidIssuers = new string[]
        //          {
        //              "self",
        //          },
        //        IssuerSigningKey = signingKey
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    SecurityToken validatedToken;

        //    try
        //    {

        //        tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
        //    }
        //    catch (Exception)
        //    {
        //        return null;

        //    }

        //    return validatedToken as JwtSecurityToken;

        //}

        //private JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        //{
        //    string name = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "unique_name").Value;
        //    string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "nameid").Value;
        //    return new JWTAuthenticationIdentity(name) { UserId = Convert.ToInt32(userId), UserName = name };

        //}
    }
}