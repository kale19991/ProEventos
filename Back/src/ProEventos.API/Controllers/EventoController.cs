using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<Evento> _logger;
        private readonly IList<Evento> _eventos;
        public EventoController(ILogger<Evento> logger)
        {
            _logger = logger;
            _eventos = new List<Evento>() 
            {
                new Evento() 
                {
                    EventoId = 1,
                    Tema = "Angular 11 e .NET 5" ,
                    Local = "Belo Horizonte",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento() 
                {
                    EventoId = 2,
                    Tema = "Angular Suas novidades" ,
                    Local = "Belo Horizonte",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                }
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { data = _eventos, sucesso = true});
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(
                new 
                { 
                    data = _eventos.FirstOrDefault(x => x.EventoId == id), 
                    sucesso = true
                });
        }
    }
}