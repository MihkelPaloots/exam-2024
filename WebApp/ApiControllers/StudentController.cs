using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Contracts.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using App.Domain.Identity;
using App.DTO.v1_0;
using App.DTO.v1_0.Identity;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;
        private readonly UserManager<AppUser> _userManager;

        public StudentController(IAppUnitOfWork uow, UserManager<AppUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }

        // GET: api/UserSubjects
        [HttpGet]
        public async Task<ActionResult<StudentData>> GetStudentData()
        {
            var id = _userManager.GetUserId(User);
            return await _uow.UserSubjects.GetStudentData(Guid.Parse(id));
        }
        
        // Post: register to a subject
        [HttpPost]
        public async Task<ActionResult<UserSubject>> RegisterToSubject([FromBody] GuidBody subjectId)
        {
            var id = _userManager.GetUserId(User);
            var userSubject = new App.DAL.DTO.UserSubject();
            userSubject.SubjectId = subjectId.SubjectId;
            userSubject.AppUserId = Guid.Parse(id);
            userSubject.RoleId = Guid.Parse("5493acf2-db54-4445-abc1-35f469ba2f69");
            userSubject.Enrolled = false;
            _uow.UserSubjects.Add(userSubject);
            await _uow.SaveChangesAsync();
            return Created();
        }
    }
}
