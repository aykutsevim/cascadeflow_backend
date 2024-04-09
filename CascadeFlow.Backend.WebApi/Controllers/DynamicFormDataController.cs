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
    public class DynamicFormDataController : ControllerBase
    {
        private readonly IDynamicFormDataService dynamicFormDataService;

        public DynamicFormDataController(IDynamicFormDataService dynamicFormDataService)
        {
            this.dynamicFormDataService = dynamicFormDataService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FormDataDto>>> GetAll()
        {
            //var result = await dynamicFormDataService.GetAllAsync();
            return Ok();
        }

        [HttpGet("{formId}/{entityId}")]
        public async Task<ActionResult<FormDataDto>> Get(Guid formId, Guid entityId)
        {
            var result = await dynamicFormDataService.GetByIdAsync(formId, entityId);
            return Ok(result);
        }


    }
}
