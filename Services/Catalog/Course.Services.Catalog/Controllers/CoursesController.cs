using System.Threading.Tasks;
using Course.Services.Catalog.Dtos.Course;
using Course.Services.Catalog.Services;
using Course.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Course.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> GetAll() =>
            CreateActionResultInstance(await _courseService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            CreateActionResultInstance(await _courseService.GetByIdAsync(id));

        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId) =>
            CreateActionResultInstance(await _courseService.GetAllByUserIdAsync(userId));

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
            => CreateActionResultInstance(await _courseService.CreateAsync(courseCreateDto));

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
            => CreateActionResultInstance(await _courseService.UpdateAsync(courseUpdateDto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) =>
            CreateActionResultInstance(await _courseService.DeleteAsync(id));
    }
}