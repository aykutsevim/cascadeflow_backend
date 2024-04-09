using CascadeFlow.Backend.Application.Interfaces;
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
    internal class DynamicFormDataRepository : IDynamicFormDataRepository
    {

        private readonly IConfiguration configuration;
        private readonly IDynamicFormRepository formRepository;

        public DynamicFormDataRepository(IConfiguration configuration, IDynamicFormRepository formRepository)
        {
            this.configuration = configuration;
            this.formRepository = formRepository;
        }

        public Task<int> AddAsync(Guid formRef, FormData entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid formRef, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<FormData>> GetAllAsync(Guid formRef)
        {
            throw new NotImplementedException();
        }

        public async Task<FormData> GetByIdAsync(Guid formId, Guid entityId)
        {
            var form = await this.formRepository.GetByIdAsync(formId);

            var newFormData = new FormData()
            {
                FormRef = formId,
            };

            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                await using var command = new NpgsqlCommand($"SELECT * FROM {form.EntityTable} WHERE id = '{ entityId }'" , connection);
                await using var reader = await command.ExecuteReaderAsync();

                if (reader != null)
                {
                    
                    if (await reader.ReadAsync())
                    {
                        /*var schema = await reader.GetColumnSchemaAsync();
                        foreach(var item in schema)
                        {
                            Console.WriteLine(item.ColumnName);
                        }*/
                        foreach(var element in form.Elements)
                        {
                            try
                            {
                                var fieldIndex = reader.GetOrdinal(element.FieldName);

                                var newFormElementData = new FormElementData()
                                {
                                    FormElementRef = element.Id,
                                    FieldName = element.FieldName,
                                };

                                switch (element.DtypeString)
                                {
                                    case "GSelect":
                                        newFormElementData.Value = reader.GetInt32(fieldIndex).ToString();
                                        break;
                                    case "GTextbox":
                                        newFormElementData.Value = reader.GetString(fieldIndex);
                                        break;
                                }

                                newFormData.Elements.Add(newFormElementData);
                            }
                            catch (IndexOutOfRangeException ex) 
                            { 
                                newFormData.Errors.Add($"Element [{element.FieldName}] is not found in resultset for table [{form.EntityTable}]");
                            }


                        }
                    }

                }

            }


            return newFormData;
        }

        public Task<int> UpdateAsync(Guid formRef, FormData entity)
        {
            throw new NotImplementedException();
        }
    }
}
