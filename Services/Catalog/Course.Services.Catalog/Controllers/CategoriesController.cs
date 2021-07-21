using System.Threading.Tasks;
using Course.Services.Catalog.Dtos.Category;
using Course.Services.Catalog.Services;
using Course.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Course.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            CreateActionResultInstance(await _categoryService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            CreateActionResultInstance(await _categoryService.GetByIdAsync(id));
    
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
            => CreateActionResultInstance(await _categoryService.CreateAsync(categoryDto));

    }
}