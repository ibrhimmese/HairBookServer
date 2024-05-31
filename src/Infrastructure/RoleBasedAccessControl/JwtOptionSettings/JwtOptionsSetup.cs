using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.RoleBasedAccessControl.JwtOptionSettings;

public class JwtOptionsSetup(
    IConfiguration configuration
    ) : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection("JwtOptions").Bind(options);
    }
}