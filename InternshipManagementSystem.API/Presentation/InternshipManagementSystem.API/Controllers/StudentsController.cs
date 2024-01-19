﻿using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels.StudentViewModels;
using InternshipManagementSystem.Application.ViewModels.StuentViewModels;
using InternshipManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IAdvisorReadRepository _advisorReadRepository;
        private readonly IAdvisorWriteRepository _advisorWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentsController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()

        {
            var x = _studentReadRepository.GetAll();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var advisor = await _studentReadRepository.GetByIdAsync(id, false);
            return Ok(advisor);
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Student model)
        {
            Student student = new()
            {
                AdvisorID = model.AdvisorID,
                Address = model.Address,
                Email = model.Email,
                GPA = model.GPA,
                StudentGSMNumber = model.StudentGSMNumber,
                StudentName = model.StudentName,
                StudentNo = model.StudentNo,
                StudentSurname = model.StudentSurname,
                TC_No = model.TC_No,
                DepartmentName = model.DepartmentName,
                ProgramNameName = model.ProgramName,
                FacultyName = model.FacultyName,
            };

            var advisor = await _advisorReadRepository.GetAll().Include(x => x.Students).FirstOrDefaultAsync(x => x.ID == model.AdvisorID);
            advisor.Students.Add(student);
            await _advisorWriteRepository.SaveAsync();
            await _studentWriteRepository.SaveAsync();
            return Ok(student);
        }
        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Student model)
        {
            var student = await _studentReadRepository.GetByIdAsync(model.ID.ToString());
            student.TC_No = model.TC_No;
            student.Email = model.Email;
            student.Address = model.Address;
            student.StudentName = model.StudentName;
            student.StudentSurname = model.StudentSurname;
            student.StudentNo = model.StudentNo;
            student.StudentGSMNumber = model.StudentGSMNumber;
            student.GPA = model.GPA;
            student.DepartmentName = model.DepartmentName;
            student.ProgramNameName = model.ProgramName;
            await _studentWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _studentWriteRepository.RemoveAsync(id);
            await _studentWriteRepository.SaveAsync();
            return Ok(
                new
                {
                    Deletion_Process = "Successful",
                    StatusCode = 200
                });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var req = Request;
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "files");

            Guid guid = Guid.NewGuid();
            string fullPath = Path.Combine(uploadPath, $"{guid.ToString()}{file.FileName.Replace(" ", "_")}");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            try
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return Ok("completed");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                await fileStream.FlushAsync();
                return Ok("not completed");

            }



            return Ok("Some Problems");

        }
    }
}
