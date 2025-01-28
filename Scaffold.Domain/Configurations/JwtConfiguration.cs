namespace Scaffold.Domain.Configurations;

public record JwtConfiguration
{
    public string Key { get; init; } 
    public string Issuer { get; init; } 
    public string Audience { get; init; }
}
