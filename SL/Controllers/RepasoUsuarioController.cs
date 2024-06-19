using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepasoUsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("RepasoUsuario/GetAll")]
        public IActionResult GetAll()
        {
            DTO.Result result = new DTO.Result();
            var task = BL.Usuario.GetAll();

            result.Success = task.Item1;
            result.Message = task.Item2;

            if (task.Item1)
            {
                result.Data = task.usaurio;
                return Ok (result);
            }
            else
            {
                result.Error = task.Item4;
                return BadRequest(result);
            }
        }
    }
}
