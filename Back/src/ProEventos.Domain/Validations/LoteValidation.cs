using System;
using FluentValidation;
using ProEventos.Domain.Entities;

namespace ProEventos.Domain.Validations
{
    public class LoteValidation : AbstractValidator<Lote>
    {
        public LoteValidation()
        {
            
        }
    }
}