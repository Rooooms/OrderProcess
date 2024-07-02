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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrderProcess.Service.Services
{
    public class CategoryGroupService : ICategoryGroupService
    {

        private readonly ICategoryGroupRepository _categoryGroup;
        public CategoryGroupService(ICategoryGroupRepository categoryGroup)
        {
            _categoryGroup = categoryGroup;   
        }

        public async Task<CategoryGroupResponse> Create(CategoryGroupRequest request)
        {
            var categoryGroup = request.Adapt<categorygroup>();

            _categoryGroup.Add(categoryGroup);

            await _categoryGroup.SaveChangesAsync();

            var categoryGroupDto = categoryGroup.Adapt<CategoryGroupResponse>();

            return categoryGroupDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var categoryGroup = await _categoryGroup.GetById(id);

            if (categoryGroup == null)
            {
                return false;
            }

            _categoryGroup.Delete(categoryGroup);

            await _categoryGroup.SaveChangesAsync();

            return true;

        }

        public async Task<List<CategoryGroupResponse>> GetAll()
        {
            var categoryGroup = await _categoryGroup.GetAll();  

            var categoryGroupDto = categoryGroup.Adapt<List<CategoryGroupResponse>>();

            return categoryGroupDto;
        }

        public async Task<CategoryGroupResponse> GetByGroupno(int groupno)
        {
            var categoryGroup = await _categoryGroup.GetByGroupno(groupno);

            if (categoryGroup == null) throw new Exception("No Group found");

            var categoryGroupDto = categoryGroup.Adapt<CategoryGroupResponse>();

            return categoryGroupDto;
        }

        public async Task<CategoryGroupResponse> GetById(Guid Id)
        {
            var categoryGroup = await _categoryGroup.GetById(Id);

            if (categoryGroup == null) throw new Exception("No Group found");

            var categoryGroupDto = categoryGroup.Adapt<CategoryGroupResponse>();

            return categoryGroupDto;
        }

        public async Task<CategoryGroupResponse> Update(Guid id, CategoryGroupRequest request)
        {
            var categoryGroup = await _categoryGroup.GetById(id);

            if (categoryGroup == null) throw new Exception("No Group found");

            request.Adapt(categoryGroup);

            await _categoryGroup.SaveChangesAsync();

            return categoryGroup.Adapt<CategoryGroupResponse>();
        }
    }
}
