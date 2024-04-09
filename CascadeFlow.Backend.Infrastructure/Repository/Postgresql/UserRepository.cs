using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;

namespace CascadeFlow.Backend.Infrastructure.Repository.Postgresql
{
    public class UserRepository : IUserRepository
    {
        private const string TABLE_NAME = "public.user";

        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public async Task<int> AddAsync(User entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreDate = DateTime.Now;

            var sql = $"insert into {TABLE_NAME} (id, username, passwordhash, passwordsalt, refreshtoken, refreshtokencreatedat, refreshtokenexpiresat, credate, moddate, name, surname, email, phonenumber) " +
                $" values (@Id, @Username, @PasswordHash, @PasswordSalt, null, null, null, @CreDate, @ModDate, @Name, @Surname, @Email, @PhoneNumber)";

            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);

            return result;
        }

        public async Task<int> UpdateAsync(User entity)
        {
            entity.ModDate = DateTime.Now;
            var sql = $"UPDATE {TABLE_NAME} " +
                $"SET username = @Username, passwordhash = @PasswordHash, passwordsalt = @PasswordSalt, refreshtoken = @RefreshToken, refreshtokencreatedat = @RefreshTokenCreatedAt, " +
                $"refreshtokenexpiresat = @RefreshTokenExpiresAt, moddate = @ModDate, name = @Name, surname = @Surname, email = @Email, " +
                $"phonenumber = @PhoneNumber " +
                $"WHERE Id = @Id";

            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {TABLE_NAME} WHERE id = @Id";

            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();

            var result = await connection.ExecuteAsync(sql, new { Id = id });

            return result;
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TABLE_NAME}";
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var result = await connection.QueryAsync<User>(sql);
            return result.ToList();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<User> GetByNameAsync(string username)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE username = @Username";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
                return result;
            }
        }


    }
}
