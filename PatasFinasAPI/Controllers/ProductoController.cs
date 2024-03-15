using Microsoft.AspNetCore.Mvc;
using PatasFinasAPI.Models;

namespace PatasFinasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly db_Patas_FinasContext BD;
        public ProductoController(db_Patas_FinasContext context)
        {
            BD = context;
        }
        [HttpGet]
        public IEnumerable<Producto> ListaDeProductos()
        {
            return BD.Productos.ToList();
        }
    }
}
