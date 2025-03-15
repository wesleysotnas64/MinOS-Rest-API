using MinOS_Rest_API.Entities;
using MinOS_Rest_API.Services;
using Npgsql;

namespace MinOS_Rest_API.DAO
{
    public class AccessLevelDAO
    {
        private readonly ConnectionService connectionService;
        public AccessLevelDAO()
        { 
            connectionService = new ConnectionService();
        }

        public List<AccessLevelEntity> GetAllAccessLevels()
        {
            List<AccessLevelEntity> accessLevels = [];
            try
            {
                connectionService.OpenConnection();

                string query = "SELECT * FROM AccessLevels;";
                var cmd = new NpgsqlCommand(query, connectionService.connection);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accessLevels.Add(new AccessLevelEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }
            }
            catch
            { }
            finally
            {
                connectionService.CloseConnection();
            }

            return accessLevels;
        }
    }
}
