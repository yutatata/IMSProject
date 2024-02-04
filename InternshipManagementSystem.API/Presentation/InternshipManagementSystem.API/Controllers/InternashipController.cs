﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternashipController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInternships()
        {
            return Ok("Internships");
        }
        [HttpGet("{id}")]
        public IActionResult GetInternship(string id)
        {
            return Ok("Internship");
        }
        [HttpPost]
        public IActionResult CreateInternship()
        {
            return Ok("Internship Created");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateInternship(string id)
        {
            return Ok("Internship Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteInternship(string id)
        {
            return Ok("Internship Deleted");
        }

        [HttpPost("upload")]    
        public IActionResult UploadFile(IFormCollection files)
        {
            return Ok("File Uploaded");
        }

        [HttpGet("download/{id}")]
        public IActionResult DownloadFile(string id)
        {
            return Ok("File Downloaded");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteFile(string id)
        {
            return Ok("File Deleted");
        }

   


    }
}
