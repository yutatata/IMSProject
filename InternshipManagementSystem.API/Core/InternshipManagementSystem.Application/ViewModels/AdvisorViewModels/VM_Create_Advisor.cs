﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.ViewModels.AdvisorViewModels
{

    public class VM_Create_Advisor
    {
        public string AdvisorName { get; set; }
        public string AdviserSurname { get; set; }
        public string TC_NO { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public string ProgramName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        //public IFormFile File { get; set; }
    }
}
