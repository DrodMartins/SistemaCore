using FluentValidation;

namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate
{
    public class Caracteristica : BaseCadastro<Caracteristica>
    {
       
        public int CodCaracteristica { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        private Caracteristica()
        {

        }

        public Caracteristica(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public override bool SeValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidaNome();
            ValidaDescricao();
            ValidationResult = Validate(this);
        }

        private void ValidaNome(int minTamanho = 1, int maxTamanho = 200)
        {
            RuleFor(c => c.Nome)
                 .NotEmpty().WithMessage("Nome da característica obrigatório")
                 .Length(minTamanho, maxTamanho).WithMessage($"Nome da característica deve conter de {minTamanho} a {maxTamanho} caracteres");
        }

        private void ValidaDescricao(int minTamanho = 0, int maxTamanho = 50)
        { 
            RuleFor(c => c.Descricao)
                .Length(minTamanho, maxTamanho).WithMessage($"Descrição da característica deve conter de {minTamanho} a {maxTamanho} caracteres");
        }
    }
}
