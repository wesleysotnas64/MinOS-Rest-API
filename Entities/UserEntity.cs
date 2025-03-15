namespace MinOS_Rest_API.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public AccessLevelEntity? AccessLevel { get; set; }
    }
}
