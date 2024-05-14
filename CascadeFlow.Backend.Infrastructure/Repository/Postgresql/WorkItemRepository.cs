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
    public class WorkItemRepository : IWorkItemRepository
    {
        private const string TABLE_NAME = "public.work_item";

        private readonly IConfiguration configuration;

        public WorkItemRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(WorkItem entity)
        {
            entity.Id = Guid.NewGuid();

            var sql = $"insert into {TABLE_NAME} (id, work_item_type_ref, work_item_state_ref, assignee, title, description, priority) " +
                $" values (@Id, @WorkItemTypeRef, @WorkItemStateRef, @Assignee, @Title, @Description, @Priority)";

            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);

            return result;
        }

        public async Task<int> UpdateAsync(WorkItem entity)
        {
            var sql = $"UPDATE {TABLE_NAME} " +
                $"SET work_item_type_ref = @WorkItemTypeRef, work_item_state_ref = @WorkItemStateRef, assignee = @Assignee, title = @Title, description = @Description, " +
                $"priority = @Priority " +
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

        public async Task<IReadOnlyList<WorkItem>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TABLE_NAME}";
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var result = await connection.QueryAsync<WorkItem>(sql);
            return result.ToList();
        }

        public async Task<WorkItem> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<WorkItem>(sql, new { Id = id });
                return result;
            }
        }


    }
}
