using CascadeFlow.Backend.Core.Model;
using CascadeFlow.Backend.WebApi.DTO;
using CascadeFlow.Backend.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CascadeFlow.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : Controller
    {
        private readonly IWorkItemService workItemService;

        public WorkItemController(IWorkItemService workItemService)
        {
            this.workItemService = workItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<WorkItem>>> GetAllWorkItems()
        {
            var workItems = await workItemService.GetAllWorkItemsAsync();
            return Ok(workItems);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<WorkItemType>>> GetAllWorkItemTypes()
        {
            var workItemTypes = await workItemService.GetAllWorkItemTypesAsync();
            return Ok(workItemTypes);
        }

        [HttpGet("states")]
        public async Task<ActionResult<IReadOnlyList<WorkItemState>>> GetAllWorkItemStates()
        {
            var workItemStates = await workItemService.GetAllWorkItemStatesAsync();
            return Ok(workItemStates);
        }

    }
}
