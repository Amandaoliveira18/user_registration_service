using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Services
{
    public class ResultService
    {
        public string? Message {  get; set; }
        public bool Success { get; set; }

        public object? Data { get; set; }
    }
}
