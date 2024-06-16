using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.Application.Interfaces.Tokens;
using Api.Infrastructure.Tokens;
using Api.Infrastructure.RedisCache;
using Api.Application.Interfaces.RedisCache;

namespace Api.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));

            services.AddTransient<ITokenService,TokenService>();

            services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));

            services.AddTransient<IRedisCacheService, RedisCacheService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters=new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                   

                };
            });
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisCacheSettings:ConnectingString"];
                opt.InstanceName = configuration["RedisCacheSettings:InstanceName"];
            });
        }

    }
}
//Encoding.UTF8.GetBytes(configuration["JWT:Secret"]