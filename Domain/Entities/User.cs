using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        #region Validations
        public void Validate()
        {
            ValidateName();
            ValidateEmail();
            ValidatePassword();
        }

        private void ValidatePassword()
        {
            throw new NotImplementedException();
        }

        private void ValidateEmail()
        {
            throw new NotImplementedException();
        }

        //TODO: Criar outras validacoes
        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Please, inform a name.");

            if (Name.Length <= 3)
                throw new Exception("Name should have at least 3 chars.");

            if (Name.Length >= 100)
                throw new Exception("Name should have no more than 100 chars.");
        }
        #endregion
    }
}
