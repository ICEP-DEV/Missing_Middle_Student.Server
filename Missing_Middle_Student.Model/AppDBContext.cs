using Microsoft.EntityFrameworkCore;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Model.Models.StaffModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Model
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Technician> Technician { get; set; }
        public DbSet<Device> Devices { get; set; }

    }
}
