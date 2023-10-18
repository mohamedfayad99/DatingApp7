using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_Project.Extentions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddAuthentication( this IServiceCollection services 
            , IConfiguration config) 
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,  //signing key should be validated
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokenkey"])),//the key used to validate the token's signature.
                       ValidateIssuer = false, //the issure of  the token does not need to be validated
                       ValidateAudience = false //the audience of  the token does not need to be validated
                   };
               });
            return services;
        }
    }
}
