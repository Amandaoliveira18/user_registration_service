using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Entities.Services
{
    public class NutritionistUser : User
    {
        public string? License_Number { get; set; }
        public string? Cpf { get; set; }

    }
}
