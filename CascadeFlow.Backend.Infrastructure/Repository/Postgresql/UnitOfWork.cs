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
        public UnitOfWork(IUserRepository userRepository, 
            IWorkItemRepository workItemRepository,
            IWorkItemStateRepository workItemStateRepository,
            IWorkItemTypeRepository workItemTypeRepository,
            IDynamicFormRepository dynamicFormRepository,
            IProjectRepository projectRepository,
            IDynamicFormDataRepository dynamicFormsData)
        {
            Users = userRepository;
            DynamicForms = dynamicFormRepository;
            DynamicFormsData = dynamicFormsData;
            Projects = projectRepository;
            WorkItems = workItemRepository;
            WorkItemTypes = workItemTypeRepository;
            WorkItemStates = workItemStateRepository;
        }
        public IUserRepository Users { get; }
        public IDynamicFormRepository DynamicForms { get; }
        public IDynamicFormDataRepository DynamicFormsData { get; }
        public IProjectRepository Projects { get; }
        public IWorkItemRepository WorkItems { get; }
        public IWorkItemTypeRepository WorkItemTypes { get; }
        public IWorkItemStateRepository WorkItemStates { get; }
    }
}
