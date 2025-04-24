using Microsoft.AspNetCore.Identity.Data;
using MinOS_Rest_API.DTO.Request;
using MinOS_Rest_API.DTO.Response;
using MinOS_Rest_API.Entities;
using MinOS_Rest_API.Services;
using Npgsql;

namespace MinOS_Rest_API.DAO
{
    public class AuthDAO
    {
        private readonly ConnectionService connectionService;
        public AuthDAO()
        {
            connectionService = new ConnectionService();
        }

        public LoginResponseDTO Login(LoginRequestDTO loginRequestDTO)
        {
            try
            {
                connectionService.OpenConnection();

                string query = @"
                    SELECT u.name, a.name AS access_level
                    FROM Users u
                    JOIN AccessLevels a ON u.accesslevelid = a.id
                    WHERE u.username = @username AND u.password = @password;
                ";

                using var cmd = new NpgsqlCommand(query, connectionService.connection);
                cmd.Parameters.AddWithValue("@username", loginRequestDTO.Username);
                cmd.Parameters.AddWithValue("@password", loginRequestDTO.Password);

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new LoginResponseDTO
                    {
                        Message = "success",
                        Payload = new
                        {
                            Name = reader.GetString(0),
                            AccessLevel = reader.GetString(1)
                        }
                    };
                }
                else
                {
                    return new LoginResponseDTO
                    {
                        Message = "error",
                        Payload = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResponseDTO
                {
                    Message = "error",
                    Payload = null
                };
            }
            finally
            {
                connectionService.CloseConnection();
            }
        }
    }
}
