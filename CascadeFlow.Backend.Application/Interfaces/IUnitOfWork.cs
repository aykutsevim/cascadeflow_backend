using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeFlow.Backend.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IDynamicFormRepository DynamicForms { get; }
        IDynamicFormDataRepository DynamicFormsData { get; }
    }
}
