using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models
{
    public class Device
    {
       public int DeviceId { get; set; }
        public string DeviceContract { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public DateOnly AllowcationDate { get; set; }

    }
}
