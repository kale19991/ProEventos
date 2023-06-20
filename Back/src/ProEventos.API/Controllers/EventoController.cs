using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ProEventos.Persistence;
using ProEventos.Domain.Entities;
using ProEventos.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    public class EventoController : BaseController
    {
        private readonly IEventoService _service;
        public EventoController(ILogger<EventoController> logger, IEventoService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(Evento[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery]bool includePalestrante = false)
        {
            return CustomResponse<Evento[]>(await _service.GetAllEventosAsync(includePalestrante));
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> Get([FromRoute] string tema, [FromQuery] bool includePalestrante = false)
        {
            return CustomResponse<Evento[]>(await _service.GetAllEventosByTemaAsync(tema, includePalestrante));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] bool includePalestrante = false)
        {
            return CustomResponse<Evento>(await _service.GetEventoByIdAsync(id, includePalestrante));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Evento model)
        {
            return CustomResponse<Evento>(await _service.Update(id, model));
        }
        [HttpPost()]

        public async Task<IActionResult> Post([FromBody] Evento model)
        {
            return CustomResponse<Evento>(await _service.Add(model));
        }
    }
}