/*
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto
{
    internal class ProcesarAdjuntoCommandValidator
    {
    }
}
*/

using FluentValidation;

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto
{

    public class ProcesarAdjuntoCommandValidator : AbstractValidator<ProcesarAdjuntoCommand>
    {
        public ProcesarAdjuntoCommandValidator()
        {

            RuleFor(v => v.request.NombreArchivo)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");


            RuleFor(v => v.request.Identificacion)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres")
                .MinimumLength(10).WithMessage("{PropertyName} debe tener por lo menos {MinLength} caracteres")
                .Matches("^[0-9]+$").WithMessage("{PropertyName} debe contener ser solo numeros."); ;


            RuleFor(v => v.request.ArchivoBase64)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");


            RuleFor(v => v.request.ExtensionArchivo)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");


        }
    }
}