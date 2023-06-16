using FluentValidation;
using ProEventos.Domain.Entities;


namespace ProEventos.Domain.Validations
{
    public class EventoValidation : AbstractValidator<Evento>
    {
        public EventoValidation()
        {
            RuleForEach(e => e.Lotes).SetValidator(new LoteValidation());
            RuleForEach(e => e.RedesSociais).SetValidator(new RedeSocialValidation());
            RuleForEach(e => e.PalestrantesEventos).SetValidator(new PalestranteEventoValidation());
        }
    }
}