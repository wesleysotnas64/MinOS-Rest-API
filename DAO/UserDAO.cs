using MinOS_Rest_API.Entities;
using MinOS_Rest_API.Services;
using Npgsql;

namespace MinOS_Rest_API.DAO
{
    public class UserDAO
    {
        private readonly ConnectionService connectionService;

        public UserDAO()
        {
            connectionService = new ConnectionService();
        }

        public List<UserEntity> GetAllUsers()
        {
            List<UserEntity> users = [];
            try
            {
                connectionService.OpenConnection();

                string query = @"
                    SELECT u.Id, u.Username, u.Password, u.Name, a.Id AS AccessLevelId, a.Name AS AccessLevelName
                    FROM Users u
                    JOIN AccessLevels a ON u.AccessLevelId = a.Id;";
                var cmd = new NpgsqlCommand(query, connectionService.connection);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserEntity
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Name = reader.GetString(3),
                        AccessLevel = new AccessLevelEntity
                        {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(5)
                        }
                    });
                }
            }
            catch
            { }
            finally
            {
                connectionService.CloseConnection();
            }

            return users;
        }
    }
}
