using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Missing_Middle_Student.Model.Models
{
    public class ApplicantDbContext: DbContext
    {
            
       public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) : base(options) { }
           
        
        public DbSet<Applicant> Applicants { get; set; }
    }
}

