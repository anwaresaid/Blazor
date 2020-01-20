using Microsoft.AspNetCore.Mvc;
using OmnitroTool.Server.Service;
using System.Threading.Tasks;

namespace OmnitroTool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly TenantService _tenantService;

        public TenantsController(TenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _tenantService.GetTenants());
        }
    }
}