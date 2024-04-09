using CascadeFlow.Backend.Core.Model.DynamicForms;
using CascadeFlow.Backend.WebApi.DTO;
using CascadeFlow.Backend.WebApi.DTO.DynamicForms;
using CascadeFlow.Backend.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadeFlow.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicFormController : ControllerBase
    {
        private readonly IDynamicFormService dynamicFormService;

        public DynamicFormController(IDynamicFormService dynamicFormService)
        {
            this.dynamicFormService = dynamicFormService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FormDto>>> GetAll()
        {
            var result = await dynamicFormService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormDto>> Get(Guid id)
        {
            var result = await dynamicFormService.GetByIdAsync(id);
            return Ok(result);
        }


    }
}
