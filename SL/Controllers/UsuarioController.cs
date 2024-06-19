using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("Usuario/GetAll")]
        public IActionResult GetAll()
        {
            DTO.Result result = new DTO.Result();
            var task = BL.Usuario.GetAll();
            result.Success = task.Item1;
            result.Message = task.Item2;

            if (task.Item1)
            {
                result.Data = task.usaurio;
                return Ok(result);
            }else
            {
                result.Error = task.Item4;
            return BadRequest(result);
            }
        }

        [HttpGet]                                                                                         
        [Route("Usuario/GetById/{idUsuario}")]
        public IActionResult GetById(int idUsuario)
        {
            DTO.Result result = new DTO.Result();
            var task = BL.Usuario.GetById(idUsuario);
            result.Success = task.Item1;
            result.Message = task.Item2;
            if (task.Item1)
            {
                result.Data = task.Usuario;
                return Ok(result);
            }
            else
            {
                result.Error = task.Item4;
                return BadRequest(result);
            }
        }


        [HttpPost]
        [Route("Usuario/Add")]
        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            DTO.Result result = new DTO.Result();
            var task = BL.Usuario.Add(usuario);
            result.Success = task.Item1;
            result.Message = task.Item2;

            if (task.Item1)
            {
                return Ok(result);
            }
            else
            {
              
                return BadRequest(result);
            }
            
        }

        [HttpPut]
        [Route("Usuario/Update")]
        public IActionResult Update([FromBody] ML.Usuario usuario)
        {
            DTO.Result result = new DTO.Result();
            var task = BL.Usuario.Update(usuario);
            result.Success = task.Item1;
            result.Message = task.Item2;

            if(task.Item1)
            {
                return Ok(result);
            }
            else
            {
                result.Error = task.Item3;
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("Usuario/Delete/{idUsuario}")]
        public IActionResult Delete(int idUsuario)
        {
            DTO.Result result = new DTO.Result();
            var task = BL.Usuario.Delete(idUsuario);

            result.Success = task.Item1;
            result.Message = task.Item2;

            if (task.Item1)
            {
                return Ok(result);
            }
            else
            {
                result.Error = task.Item3;
                return BadRequest(result);
            }
        }
    }
}
