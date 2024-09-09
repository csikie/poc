using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using poc.Options;

namespace poc;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = new AuthOptions();
        configuration.GetSection(AuthOptions.SectionName).Bind(authOptions);
        var supabaseSignatureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Secret));
        services.AddAuthentication(o => o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = supabaseSignatureKey,
                    ValidAudiences = authOptions.ValidAudience,
                    ValidIssuer = authOptions.ValidIssuer,
                };
            });
        services.AddAuthorization();

        services.AddHttpContextAccessor();

        services.AddHttpContextAccessor();
        services.AddProblemDetails();
        
        return services;
    }
}