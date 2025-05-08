using Missing_Middle_Student.Model;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Model.Models.DTOs;
using Missing_Middle_Student.Model.Models.StaffModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Services.StaffService
{
    public class StaffService : IStaffService
    {
        readonly AppDBContext _context;
        public StaffService(AppDBContext context)
        {
            _context = context;
        }
        public bool CreateAdmin(StaffDTO staff)
        {
          var found_admin = _context.Admins.FirstOrDefault(a=>a.Email == staff.Email);
            if(found_admin != null)
            {
                return false;
            }
            else
            {
                try
                {
                    var admin = new Admin()
                    {
                        ApplicantID =0,
                        Email = staff.Email,
                        Contact = staff.Contact,
                        DeviceID = 0,
                        Initails = staff.Initails,
                        Password = staff.Password,
                        Surname = staff.Surname,

                    };
                  
                    _context.Add<Admin>(admin);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex) {
                    return false;
                }
              
            }
        }

        public bool CreateTechnician(StaffDTO tech)
        {
            var found_admin = _context.Technician.FirstOrDefault(a => a.Email == tech.Email);
            if (found_admin != null)
            {
                return false;
            }
            else
            {
                try
                {
                    var technician = new Technician()
                    {
                        
                        Email = tech.Email,
                        Contact = tech.Contact,
                        DeviceID = 0,
                        Initails = tech.Initails,
                        Password = tech.Password,
                        Surname = tech.Surname,

                    };
                    _context.Add<Technician>(technician);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        Dictionary<string,int> GetDevicesInfo()
        {
            var devices = _context.Devices.ToList();
            var info = new Dictionary<string, int>();
            if(devices != null)
            {
                info.Add("Total_devices", devices.Count);
                var Unallocated_devices = devices.FindAll(a => a.Status == "Unallocated");
                if(Unallocated_devices != null)
                {
                    info.Add("Unallocated_devices", Unallocated_devices.Count);
                }
                else
                {
                    info.Add("Unallocated_devices", 0);
                }
                var Allocated_devices = devices.FindAll(a => a.Status == "Allocated");
                if (Allocated_devices != null)
                {
                    info.Add("Allocated_devices", Allocated_devices.Count);
                }
                else
                {
                    info.Add("Allocated_devices", 0);
                }
                return info;
            }
            else
            {
                info.Add("Total_devices",0);
                info.Add("Unallocated_devices", 0);
                info.Add("Allocated_devices",0);
                return info;
            }

          
        }

        public AdminResponse? LoginAdmin(LoginDTO staff)
        {
            var found_admin = _context.Admins.FirstOrDefault(a => a.Password == staff.Password && a.Email == staff.Email);
            if (found_admin != null)
            {
                AdminResponse res = new AdminResponse()
                {
                    Device_Info = this.GetDevicesInfo(),
                    Applicants = "not available"
                };

                return res;
            }
            else
            {
                return null;
            }
        }

        public bool LoginTechnician(LoginDTO staff)
        {
            var found_admin = _context.Technician.FirstOrDefault(a => a.Password == staff.Password && a.Email == staff.Email);
            if (found_admin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegisterDevice(DeviceDTO dev)
        {
            try
            {
                var device = new Device()
                {
                    Condition = dev.Condition,
                    Brand = dev.Brand,
                    Model = dev.Model,  
                    Status ="Unallocated",
                
                };
                var res = _context.Add<Device>(device);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
