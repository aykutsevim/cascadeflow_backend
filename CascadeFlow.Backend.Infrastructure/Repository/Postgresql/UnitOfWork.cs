using CascadeFlow.Backend.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Infrastructure.Repository.Postgresql
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository, IDynamicFormRepository dynamicFormRepository, IDynamicFormDataRepository dynamicFormsData)
        {
            Users = userRepository;
            DynamicForms = dynamicFormRepository;
            DynamicFormsData = dynamicFormsData;
        }
        public IUserRepository Users { get; }
        public IDynamicFormRepository DynamicForms { get; }
        public IDynamicFormDataRepository DynamicFormsData { get; }
    }
}
