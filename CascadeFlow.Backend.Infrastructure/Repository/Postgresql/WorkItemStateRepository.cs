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
    public class WorkItemStateRepository : IWorkItemStateRepository
    {
        private const string TABLE_NAME = "public.workitemstate";

        private readonly IConfiguration configuration;

        public WorkItemStateRepository(IConfiguration configuration) { 
            this.configuration = configuration;
        }

        public Task<int> AddAsync(WorkItemState entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<WorkItemState>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TABLE_NAME}";
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var result = await connection.QueryAsync<WorkItemState>(sql);
            return result.ToList();
        }

        public async Task<WorkItemState> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<WorkItemState>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(WorkItemState entity)
        {
            throw new NotImplementedException();
        }
    }
}
