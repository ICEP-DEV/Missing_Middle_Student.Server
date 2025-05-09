﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Missing_Middle_Student.Model.Models;

namespace Missing_Middle_Student.Services.Studentservices
{
    public class ApplicantService: IApplicantService
    {

        private readonly ApplicantDbContext _context;

        public ApplicantService(ApplicantDbContext context) { 
            
            _context = context; 
        
        }
         public async Task AddApplicantAsync(Applicant applicant)
        {
           _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
        }
         public async Task<Applicant>FindApplicationAsync(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);

            return applicant;
        }
    }
}
