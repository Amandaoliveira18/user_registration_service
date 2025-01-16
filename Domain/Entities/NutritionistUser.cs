using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class NutritionistUser : User
    {
        public string? License_Number { get; set; }
        public string? Cpf {  get; set; }

        public void Validate()
        {
            var validateCpf = CpfValidator.IsValidCpf(Cpf) ? throw new ValidationException("Erro ao cadastrar Nutricionista (CPF inválido)") : true; 
            ValidateLicenseNumber();
        }
        private void ValidateLicenseNumber()
        {
            if (String.IsNullOrEmpty(License_Number))
                throw new ValidationException("Erro ao cadastrar Nutricionista (CRN nulo)");
        }
    }
}
