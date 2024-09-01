using NK.ChatGPTClone.Application.Common.Models.Jwt;

namespace NK.ChatGPTClone.Application.Common.Interfaces
{
    public interface IJwtService
    {
        JwtGenerateTokenResponse GenerateToken(JwtGenerateTokenRequest request);
    }
}
