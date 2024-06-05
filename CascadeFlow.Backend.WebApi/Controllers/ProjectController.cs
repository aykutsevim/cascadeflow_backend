using CascadeFlow.Backend.Core.Model;
using CascadeFlow.Backend.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CascadeFlow.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Project>>> GetAllProjects()
        {
            var projects = await projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("tenant")]
        public async Task<ActionResult<IReadOnlyList<Project>>> GetProjectsByTenantId()
        {
            var projects = await projectService.GetProjectsByTenantIdAsync();
            return Ok(projects);
        }

    }
}
