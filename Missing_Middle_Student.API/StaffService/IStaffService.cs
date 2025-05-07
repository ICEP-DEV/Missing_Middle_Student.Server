using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missing_Middle_Student.Model.Models.StaffModels;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Model.Models.DTOs;




namespace Missing_Middle_Student.Services.StaffService
{
    public interface IStaffService
    {
        public bool LoginAdmin(StaffDTO staff);
        public bool LoginTechnician(StaffDTO staff);
        public bool CreateTechnician(StaffDTO tech);
        public bool CreateAdmin(StaffDTO staff);
       // public bool ProveApplication(Applicant  applicant);
       // public bool RejectApplication(Applicant applicant);
        public bool RegisterDevice(DeviceDTO device);




    }
}
