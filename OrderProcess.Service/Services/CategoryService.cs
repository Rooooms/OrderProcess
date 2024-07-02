using Mapster;
using OrderProcess.Core.Entities;
using OrderProcess.Core.Interfaces.Repositories;
using OrderProcess.Core.Interfaces.Services;
using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;
        private readonly ICategoryGroupRepository _catGroup;

        public CategoryService(ICategoryRepository category, ICategoryGroupRepository catGroup)
        {
            _category = category;
            _catGroup = catGroup;
        }

        public async Task<CategoryResponse> Create(CategoryRequest request)
        {
            var catGroup = await _catGroup.GetByGroupno(request.groupno);

            if (catGroup == null) throw new Exception("No Group found");

            var category = request.Adapt<Category>();

            _category.Add(category);

            await _category.SaveChangesAsync();

            var categoryDto = category.Adapt<CategoryResponse>();

            return categoryDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _category.GetById(id);

            if (category == null) return false;

            _category.Delete(category);

            await _category.SaveChangesAsync();

            return true;
        }

        public async Task<List<CategoryResponse>> GetAll()
        {
            var category = await _category.GetAll();

            var categoryDto = category.Adapt<List<CategoryResponse>>();

            return categoryDto;
        }

        public async Task<CategoryResponse> GetById(Guid id)
        {
            var category = await _category.GetById(id);

            if (category == null) throw new Exception("No Category Found");

            var categoryDto = category.Adapt<CategoryResponse>();

            return categoryDto;
        }

        public async Task<CategoryResponse> Update(Guid id, CategoryRequest request)
        {
            var category = await _category.GetById(id);

            request.Adapt(category);

            var group = await _catGroup.GetByGroupno(category.groupno);
            if (group == null) throw new Exception("No Group Found");

            await _category.SaveChangesAsync();

            return category.Adapt<CategoryResponse>();
        }
    }
}
