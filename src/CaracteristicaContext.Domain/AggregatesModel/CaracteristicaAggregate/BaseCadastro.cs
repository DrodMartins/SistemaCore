using FluentValidation;
using FluentValidation.Results;
using System;

namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate
{
    public abstract class BaseCadastro<T>: AbstractValidator<T> where T: BaseCadastro<T>
    {
        public BaseCadastro()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool SeValido();

        public ValidationResult ValidationResult { get; protected set; }

        public int CodUsuarioCadastro { get; set; }

        public DateTime DataCadastro { get; set; }

        public int? CodUsuarioAlteracao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
