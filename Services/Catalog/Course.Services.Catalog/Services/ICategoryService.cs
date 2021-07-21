﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Course.Services.Catalog.Dtos.Category;
using Course.Shared.Dtos;

namespace Course.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}