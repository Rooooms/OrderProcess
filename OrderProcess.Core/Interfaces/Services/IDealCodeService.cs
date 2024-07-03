using OrderProcess.Core.Models.Requests;
using OrderProcess.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Core.Interfaces.Services
{
    public interface IDealCodeService
    {
        Task<List<DealCodeResponse>> GetAll();

        Task<DealCodeResponse>Create(DealCodeRequest request);

        Task<DealCodeResponse> Update(Guid Id , DealCodeRequest request);

        Task<bool>Delete(Guid Id);
    }
}
