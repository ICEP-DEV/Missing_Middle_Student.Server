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

        public bool LoginAdmin(StaffDTO staff)
        {
            var found_admin = _context.Admins.FirstOrDefault(a => a.Password == staff.Password && a.Email == staff.Email);
            if (found_admin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginTechnician(StaffDTO staff)
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
                    Name = dev.Name,    
                    Status = dev.Status,
                
                };
                var res = _context.Add<Device>(device);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
