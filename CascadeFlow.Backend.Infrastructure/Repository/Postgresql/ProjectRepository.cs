using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Infrastructure.Repository.Postgresql
{
    public class ProjectRepository : IProjectRepository
    {
        private const string TABLE_NAME = "public.project";

        private readonly IConfiguration configuration;

        public ProjectRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<int> AddAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Project>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TABLE_NAME}";
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var result = await connection.QueryAsync<Project>(sql);
            return result.ToList();
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Project>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Project>> GetByTenantIdAsync(Guid tenantId)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE tenantref = @TenantId";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Project>(sql, new { TenantId = tenantId });
                return result.ToList();
            }
        }


        public Task<int> UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
