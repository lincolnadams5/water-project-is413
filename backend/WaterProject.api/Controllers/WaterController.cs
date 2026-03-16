using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterProject.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WaterProject.api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class WaterController : ControllerBase
    {
        private WaterDbContext _waterContext;
        public WaterController(WaterDbContext temp) => _waterContext = temp;
        [HttpGet("AllProjects")]
        public IActionResult GetProjects(int pageSize, int pageNum = 1)
        {
            var data = _waterContext.Projects
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalNumProjects = _waterContext.Projects.Count();

            var response = new
            {
                Projects = data,
                TotalNumProjects = totalNumProjects
            };

            return Ok(response);
        }

        [HttpGet("FunctionalProjects")]
        public IEnumerable<Project> GetFunctionalProjects()
        {
            var data = _waterContext.Projects.Where(x => x.ProjectFunctionalityStatus == "Functional").ToList();
            return data;
        }
    }
}