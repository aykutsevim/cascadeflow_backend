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
    public class WorkItemTypeRepository : IWorkItemTypeRepository
    {
        private const string TABLE_NAME = "public.workitemtype";

        private readonly IConfiguration configuration;

        public WorkItemTypeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<int> AddAsync(WorkItemType entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<WorkItemType>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TABLE_NAME}";
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var result = await connection.QueryAsync<WorkItemType>(sql);
            return result.ToList();
        }

        public async Task<WorkItemType> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<WorkItemType>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(WorkItemType entity)
        {
            throw new NotImplementedException();
        }
    }
}
