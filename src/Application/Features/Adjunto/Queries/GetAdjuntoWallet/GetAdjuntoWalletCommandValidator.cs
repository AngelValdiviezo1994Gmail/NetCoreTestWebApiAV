/*
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto;

namespace WebApiTest.Application.Features.Adjunto.Queries.GetAdjuntoWallet
{
    internal class GetAdjuntoWalletCommandValidator
    {
    }
}
*/

using FluentValidation;

namespace WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto
{

    public class GetAdjuntoWalletCommandValidator : AbstractValidator<GetAdjuntoWalletCommand>
    {
        public GetAdjuntoWalletCommandValidator()
        {
            RuleFor(v => v.Identificacion)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .MinimumLength(10).WithMessage("{PropertyName} debe tener por lo menos {MinLength} caracteres")
                .Matches("^[0-9]+$").WithMessage("{PropertyName} debe contener ser solo numeros."); ;


            RuleFor(v => v.IdFeature)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");


        }
    }
}