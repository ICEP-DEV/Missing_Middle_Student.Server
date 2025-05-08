using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models.DTOs
{
    public class LoginDTO
    {
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
