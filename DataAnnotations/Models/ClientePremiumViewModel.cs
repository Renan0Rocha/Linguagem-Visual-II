using System.ComponentModel.DataAnnotations;

namespace DataAnnotations.Models
{
    public class ClientePremiumViewModel
    {
        // 1. NomeCompleto
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome completo deve ter entre 5 e 100 caracteres.")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; } = string.Empty;

        // 2. DataNascimento
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        // 3. CPF
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "O CPF deve estar no formato 000.000.000-00.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;

        // 4. TelefoneCelular
        [Required(ErrorMessage = "O telefone celular é obrigatório.")]
        [Phone(ErrorMessage = "Informe um número de telefone válido.")]
        [Display(Name = "Telefone Celular")]
        public string TelefoneCelular { get; set; } = string.Empty;

        // 5. UrlPerfilLinkedIn (opcional)
        [Url(ErrorMessage = "Informe uma URL válida para o perfil do LinkedIn.")]
        [Display(Name = "Perfil do LinkedIn")]
        public string? UrlPerfilLinkedIn { get; set; }

        // 6. RendaMensal
        [Required(ErrorMessage = "A renda mensal é obrigatória.")]
        [Range(3000, 1000000, ErrorMessage = "A renda mensal deve estar entre R$ 3.000,00 e R$ 1.000.000,00.")]
        [DataType(DataType.Currency, ErrorMessage = "Informe um valor monetário válido.")]
        [Display(Name = "Renda Mensal")]
        public decimal RendaMensal { get; set; }

        // 7. NumeroCartaoCredito
        [Required(ErrorMessage = "O número do cartão de crédito é obrigatório.")]
        [CreditCard(ErrorMessage = "Informe um número de cartão de crédito válido.")]
        [Display(Name = "Número do Cartão de Crédito")]
        public string NumeroCartaoCredito { get; set; } = string.Empty;

        // 8. SenhaAcesso
        [Required(ErrorMessage = "A senha de acesso é obrigatória.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "A senha deve conter ao menos 8 caracteres, uma letra maiúscula, uma minúscula, um número e um caractere especial.")]
        [Display(Name = "Senha de Acesso")]
        public string SenhaAcesso { get; set; } = string.Empty;

        // 9. ConfirmarSenhaAcesso
        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Compare("SenhaAcesso", ErrorMessage = "A confirmação de senha deve ser idêntica à senha de acesso.")]
        [Display(Name = "Confirmar Senha de Acesso")]
        public string ConfirmarSenhaAcesso { get; set; } = string.Empty;
    }
}
