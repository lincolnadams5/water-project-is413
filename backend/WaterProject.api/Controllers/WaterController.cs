using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterProject.api.Data;
using Microsoft.EntityFrameworkCore;

namespace WaterProject.api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class WaterController : ControllerBase
    {
        private WaterDbContext _waterContext;
        public WaterController(WaterDbContext temp) => _waterContext = temp;
        public IEnumerable<Project> GetProjects()
        {
            var data = _waterContext.Projects.ToList();
            return data;
        }

        public IEnumerable<Project> GetFunctionalProjects()
        {
            var data = _waterContext.Projects.Where(x => x.ProjectFunctionalityStatus == "Functional").ToList();
            return data;
        }
    }
}