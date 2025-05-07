﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models.StaffModels
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string Initails { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
