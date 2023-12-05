using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time.Sheet.Web.DTO;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;
using TimeSheet.Core.Services;

namespace Time.Sheet.Web.Controlers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly CategoryService _categoryService;
        public readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(CategoryService categoryService, ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _categoryService.GetAll();
            var results = _mapper.Map<IEnumerable<CategoryDTO>>(category);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.FindById(id);

            if (category.HasNoValue)
            {
                return BadRequest();
            }

            var vrednost = category.Value.Name.ToString();

            var categoryResult = new CategoryDTO()
            {

                Name = category.Value.Name.ToString(),
               

            };

            return Ok(vrednost);
        }

        public Result Delete(int id)
        {
            if (_categoryRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _categoryRepository.Delete(id);
            return Result.Success();


        }
        public Result Update(Category category)
        {
            if (_categoryRepository.FindById(category.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _categoryRepository.Update(category);
            return Result.Success();
        }
    }
}
