using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProEventos.Domain.Entities;

namespace ProEventos.Domain.Validations
{
    public class PalestranteEventoValidation : AbstractValidator<PalestranteEvento>
    {
        public PalestranteEventoValidation()
        {
            
        }
    }
}