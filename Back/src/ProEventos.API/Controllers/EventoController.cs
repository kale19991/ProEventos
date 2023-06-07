using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using System.Collections.Generic;
using System.Linq;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<Evento> _logger;
        private readonly DataContext _context;
        public EventoController(ILogger<Evento> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { data = _context.Eventos, sucesso = true});
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(
                new 
                { 
                    data = _context.Eventos.Where(x => x.EventoId == id), 
                    sucesso = true
                });
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(int id)
        {
            return Ok(
                new 
                { 
                    data = _context.Eventos.Where(x => x.EventoId == id), 
                    sucesso = true
                });
        }
        [HttpPost()]
        public IActionResult Post(Evento model)
        {
            _context.Eventos.Add(model);
            _context.SaveChanges();

            return Ok(
                new 
                { 
                    data = model, 
                    sucesso = true
                });
        }
    }
}