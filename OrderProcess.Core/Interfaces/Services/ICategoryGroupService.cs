using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface ICategoryGroupService
    {
        Task<List<CategoryGroupResponse>> GetAll();

        Task<CategoryGroupResponse> GetById(Guid Id);

        Task<CategoryGroupResponse> GetByGroupno(int groupno);

        Task<CategoryGroupResponse> Create(CategoryGroupRequest request);

        Task<CategoryGroupResponse> Update(Guid id, CategoryGroupRequest request);

        Task <bool> Delete (Guid id);
    }
}
