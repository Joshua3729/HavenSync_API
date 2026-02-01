namespace HavenSync_api.DTOs.Auth
{
    public record RegisterRequest(string Email, string Password, string Role);
    
}