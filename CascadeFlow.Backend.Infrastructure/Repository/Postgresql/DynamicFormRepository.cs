using Dapper;
using CascadeFlow.Backend.Application.Interfaces;
using CascadeFlow.Backend.Core.Model;
using CascadeFlow.Backend.Core.Model.DynamicForms;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Infrastructure.Repository.Postgresql
{
    public class DynamicFormRepository : IDynamicFormRepository
    {
        private const string TABLE_NAME = "public.form";
        private const string CHILD_TABLE_NAME = "public.formelement";

        private readonly IConfiguration configuration;
        public DynamicFormRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<int> AddAsync(Form entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Form>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TABLE_NAME}";
            using var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var result = await connection.QueryAsync<Form>(sql);

            if (result != null)
            {
                foreach (var form in result)
                {
                    var childElementsSql = $"SELECT * FROM {CHILD_TABLE_NAME} WHERE formref = @FormRef";
                    var childResult = await connection.QueryAsync<FormElement>(childElementsSql, new { FormRef = form.Id });
                    form.Elements = childResult.ToList();
                }
            }

            return result.ToList();
        }

        public async Task<Form> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TABLE_NAME} WHERE id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Form>(sql, new { Id = id });

                if (result != null)
                {
                    var childElementsSql = $"SELECT * FROM {CHILD_TABLE_NAME} WHERE formref = @Id";
                    var childResult = await connection.QueryAsync<FormElement>(childElementsSql, new { Id = id });
                    result.Elements = childResult.ToList();
                }

                return result;
            }
        }

        public Task<int> UpdateAsync(Form entity)
        {
            throw new NotImplementedException();
        }
    }
}
