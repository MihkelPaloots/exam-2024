using App.Contracts.DAL;
using App.DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Identity;
using App.DTO;
using App.DTO.v1_0;
using App.DTO.v1_0.Identity;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Subject = App.DTO.v1_0.Subject;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeacherController : ControllerBase
    {
        private readonly IAppUnitOfWork _context;
        private readonly UserManager<AppUser> _userManager;

        public TeacherController(IAppUnitOfWork context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/UserSubjectHomeworks
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherData>>> GetSubjectsWithStudents()
        {
            var id = _userManager.GetUserId(User);
            var result = new TeacherData()
            {
                subjects = ( await _context.UserSubjects.GetSubjectsWithStudents(Guid.Parse(id))).ToList(),
                successRate = 55.1
            };
            return Ok(result);
        }
        
        //Enroll students
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TeacherData>>> EnrollStudents([FromBody] EnrollStudentsBody enrollStudents)
        {
            var id = _userManager.GetUserId(User);
               await _context.UserSubjects.EnrollStudents(enrollStudents);
            return Created();
        }
        
        // Add homework
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TeacherData>>> AddHomework([FromBody] AddHomeworkBody addHomework)
        {
            var id = _userManager.GetUserId(User);
            var hw = new App.DAL.DTO.Homework()
            {
                SubjectId = addHomework.SubjectId,
                Description = addHomework.Homework.Description,
                Title = addHomework.Homework.Title,
                DueDate = addHomework.Homework.DueDate.ToUniversalTime()
            };
            _context.Homeworks.Add(hw);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}
