namespace MinOS_Rest_API.DTO.Request
{
    public class LoginRequestDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
