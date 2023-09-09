namespace HomeWork.Service.Models.AuthModel;

public class JwtSettings
{
    public string? Key { get; set; }
    public double DurationInMinutes { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
}
