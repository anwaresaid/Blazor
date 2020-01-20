using Microsoft.AspNetCore.Mvc;
using OmnitroTool.Server.Service;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OmnitroTool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            this._productsService = productsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(await _productsService.GetAllProducts());
        }
    }
}
