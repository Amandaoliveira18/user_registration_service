using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public void Validate()
        {
            ValidateEmail();
            ValidatePassword();
        }

        private void ValidateEmail()
        {
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ValidationException("Erro ao cadastrar Nutricionista (Email invalido)");
        }

        private void ValidatePassword()
        {
            if (Password.Length < 5)
                throw new ValidationException("Erro ao cadastrar Nutricionista (Minimo 5 caracteres)");
        }
    }
}
