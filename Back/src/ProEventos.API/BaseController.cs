using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using System;

namespace ProEventos.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected ILogger<ControllerBase> _logger;
        public BaseController(ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        public IActionResult CustomResponse<T>(BaseResult<T> obj, int statusCodes = StatusCodes.Status200OK)
        {
            try
            {
                if (!obj.Success)
                    return BadRequest(new { data = obj.Data, success = false, message = obj.ErrorMessage });

                if (statusCodes == StatusCodes.Status204NoContent)
                    return NoContent();

                if (statusCodes == StatusCodes.Status201Created)
                    return Created("", new { data = obj.Data, success = true });

                return Ok(new { data =  obj.Data, success = true } );
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro interno!");
            }
        }
    }
}
