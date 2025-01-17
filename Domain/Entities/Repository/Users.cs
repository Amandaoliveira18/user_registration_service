using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Repository
{
    [Table("USERS")]
    public class Users
    {
        public string Id { get; set; }
        public string Name_User { get; set; }
        public string Email { get; set; }
        public string Password_User { get; set; }
        public string Lincense_Number { get; set; }
        public string Cpf_User { get; set; }
        public string Profile_User { get; set;}
    }
}
