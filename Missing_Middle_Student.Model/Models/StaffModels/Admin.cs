using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model.Models.StaffModels
{
    public class Admin:Staff
    {
        public int ApplicantID { get; set; }
        public int DeviceID { get; set; }
    }
}
