using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace TokenTools
{
    public class TokenManager : ITokenManager
    {
        public static string SecretKey = "ah oui on va teste un truc de beacoup plus grand";
        public static string Issuer = "monsiteapi.com";
        public static string Audience = "maconsomation.com";
        public User Authenticate(User user)
        {
            if(user.Speudo is null && user.Mdp is null)
            {
                throw new ArgumentNullException();
            }
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials credetials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512);

            Claim[] MyClaims = new[]
            {
                new Claim("UserLogin",user.Speudo),
                new Claim(ClaimTypes.Role,user.Roles),
                new Claim("UserId",user.Id.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims:MyClaims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: credetials,
                issuer:Issuer,
                audience:Audience
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            user.Token = tokenHandler.WriteToken(token);
            return user;

        }
    }
}
