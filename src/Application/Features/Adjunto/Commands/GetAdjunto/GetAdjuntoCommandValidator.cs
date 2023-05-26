
using FluentValidation;

namespace WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto
{

    public class GetAdjuntoCommandValidator : AbstractValidator<GetAdjuntoCommand>
    {
        public GetAdjuntoCommandValidator()
        {
            RuleFor(v => v.Identificacion)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .MinimumLength(10).WithMessage("{PropertyName} debe tener por lo menos {MinLength} caracteres")
                .Matches("^[0-9]+$").WithMessage("{PropertyName} debe contener ser solo numeros.");


            RuleFor(v => v.IdFeature)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");


        }
    }
}
