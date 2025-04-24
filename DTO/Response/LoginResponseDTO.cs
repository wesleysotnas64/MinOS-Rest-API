namespace MinOS_Rest_API.DTO.Response
{
    public class LoginResponseDTO
    {
        public required string Message { get; set; }
        public object? Payload { get; set; }
    }
}
