using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System.Globalization;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no mínimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CNPJ)} não pode ser vazio")
                .Must(ValidarCNPJ).WithMessage(x => $"O campo {nameof(x.CNPJ)} deve conter um CNPJ de 14 digitos");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser vazio");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio")
                .Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage(x => $"O campo {nameof(x.Telefone)} deve estar no formato (XX) XXXXX-XXXX");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio")
                 .Must(ValidarFormatoEmail).WithMessage(x => $"O campo {nameof(x.Email)} deve estar no formato email@email.com");

            RuleFor(x => x.CriadoEm)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser vazio");
        }

        private bool ValidarCNPJ(string cnpj)
        {
            return cnpj.Length == 14 && long.TryParse(cnpj, out _);
        }

        private bool ValidarFormatoEmail(string email)
        {
            var regex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, regex);
        }
    }
}
