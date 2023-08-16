using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Options;
using PulseemCMS.Application.Clients.Commands.CreateClient;
using PulseemCMS.Application.Clients.Commands.UpdateClient;
using PulseemCMS.Application.Clients.Queries;
using PulseemCMS.Application.Common.Interfaces;
using PulseemCMS.Domain.AppSettings;
using PulseemCMS.Domain.Entities;

namespace PulseemCMS.Infrastructure.Services;
public class ClientDbService : IClientDbService
{

    readonly string _connectionString;

    public ClientDbService(IOptions<DatabaseOptions> databaseOptions)
    {
        _connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<(Client, int)> CreatClientAsync(CreateClientCommand request)
    {
        var clientEntity = GetMappedClientDtoToEntity(request);

        int returnVal = 0;

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand("CreateClient", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter returnValue = new SqlParameter();

                returnValue.Direction = ParameterDirection.ReturnValue;

                command.Parameters.Add(returnValue);

                command.Parameters.Add(outputIdParam);

                command.Parameters.AddWithValue("@Cellphone", request.Cellphone);

                command.Parameters.AddWithValue("@Email", request.Email);

                command.Parameters.AddWithValue("@ClientName", request.ClientName);

                await command.ExecuteNonQueryAsync();

                returnVal = (int)returnValue.Value;

                clientEntity.ClientID = returnVal > 0 ? Convert.ToInt64(outputIdParam.Value) : 0;
            }

            con.Close();
        }

        return (clientEntity, returnVal);

        static Client GetMappedClientDtoToEntity(CreateClientCommand request)
        {
            return new Client()
            {
                Cellphone = request.ClientName,

                Email = request.ClientName,

                ClientName = request.ClientName,

                EmailStatus = true,

                SmsStatus = true
            };
        }
    }

    public async Task DeleteClientsAsync(long id)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand("DELETE FROM Clients WHERE ClientId=@ClientId", con))
            {
                command.Parameters.AddWithValue("@ClientId", id);

                await command.ExecuteNonQueryAsync();
            }

            con.Close();
        }
    }

    public async Task UpdateClientAsync(UpdateClientCommand request)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand("UpdateClient", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Cellphone", request.Cellphone);

                command.Parameters.AddWithValue("@Email", request.Email);

                command.Parameters.AddWithValue("@ClientName", request.ClientName);

                command.Parameters.AddWithValue("@EmailStatus", request.EmailStatus);

                command.Parameters.AddWithValue("@SmsStatus", request.SmsStatus);

                command.Parameters.AddWithValue("@ClientId", request.ClientId);

                await command.ExecuteNonQueryAsync();
            }

            con.Close();
        }
    }

    public async Task<IReadOnlyCollection<Client>> ListClientsAsync()
    {
        var clients = new List<Client>();

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            con.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Clients", con))

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (await reader.ReadAsync())
                {
                    var client = new Client();

                    client.ClientID = Convert.ToInt64(reader["ClientID"]);

                    client.Cellphone = reader["Cellphone"].ToString() ?? "";

                    client.Email = reader["Email"].ToString() ?? "";

                    client.ClientName = reader["ClientName"].ToString() ?? "";

                    client.EmailStatus = Convert.ToBoolean(reader["EmailStatus"]);

                    client.SmsStatus = Convert.ToBoolean(reader["SmsStatus"]);

                    clients.Add(client);
                }
            }

            con.Close();

            return clients;
        }
    }
}
