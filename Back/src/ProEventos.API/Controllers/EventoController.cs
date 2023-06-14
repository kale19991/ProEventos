using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ProEventos.Persistence;
using ProEventos.Domain.Entities;

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
            return Ok(_context.Eventos);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Eventos.Where(x => x.Id == id));
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(int id)
        {
            return Ok(
                new 
                { 
                    data = _context.Eventos.Where(x => x.Id == id), 
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