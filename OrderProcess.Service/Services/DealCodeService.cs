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
    public class DealCodeService : IDealCodeService
    {
        private readonly IDealcodeMasterRepository _dealcodeMaster;
        private readonly IDealCodeRepository _dealcode;

        public DealCodeService(IDealcodeMasterRepository dealcodeMaster, IDealCodeRepository dealcode)
        {
            _dealcode = dealcode;
            _dealcodeMaster = dealcodeMaster;
        }

        public async Task<DealCodeResponse> Create(DealCodeRequest request)
        {
            var existingDeal = await _dealcodeMaster.GetByDealType(request.dealno);

            if (existingDeal == null) throw new Exception("Deal not existing");


            var deal = request.Adapt<DealCodes>();
            if(existingDeal.type == 0)
            {
                deal.dealType = DealType.FixRate;
            }
            else if(existingDeal.type == 1)
            {
                deal.dealType = DealType.FixAmount;
            }
            else if (existingDeal.type == 2)
            {
                deal.dealType = DealType.FreeGoods;
            }

            if(deal.dealType == DealType.FixRate)
            {
                deal.Amount = 0;
                deal.freegoods = 0;
            }
            else if(deal.dealType == DealType.FixAmount) 
            {
                deal.rate = 0;
                deal.freegoods = 0;
            }
            else if (deal.dealType == DealType.FreeGoods)
            {
                deal.rate = 0;
                deal.Amount = 0;
            }

            deal.Status = "APPROVED";
            deal.DlTyoe = existingDeal.dldesc;

            _dealcode.Add(deal);

            await _dealcode.SaveChangesAsync();

            var dealDto = deal.Adapt<DealCodeResponse>();

            return dealDto;

        }

        public async Task<bool> Delete(Guid Id)
        {
            var deal = await _dealcode.GetById(Id);

            if (deal == null) return false;

            _dealcode.Delete(deal);

            await _dealcode.SaveChangesAsync();

            return true;
        }

        public async Task<List<DealCodeResponse>> GetAll()
        {
            var deal = await _dealcode.GetAll();
            var dealDto = deal.Adapt<List<DealCodeResponse>>();

            return dealDto;
        }

        public async Task<DealCodeResponse> Update(Guid Id, DealCodeRequest request)
        {
            var deal = await _dealcode.GetById(Id);

            if (deal == null) throw new Exception("No Deal Found to edit");

            request.Adapt(deal);

            var existingDeal = await _dealcodeMaster.GetByDealDesc(deal.DealDesc);

            if (existingDeal == null) throw new Exception("Deal not existing");
            if (existingDeal.type == 0)
            {
                deal.dealType = DealType.FixRate;
            }
            else if (existingDeal.type == 1)
            {
                deal.dealType = DealType.FixAmount;
            }
            else if (existingDeal.type == 2)
            {
                deal.dealType = DealType.FreeGoods;
            }

            if (deal.dealType == DealType.FixRate)
            {
                deal.Amount = 0;
                deal.freegoods = 0;
            }
            else if (deal.dealType == DealType.FixAmount)
            {
                deal.rate = 0;
                deal.freegoods = 0;
            }
            else if (deal.dealType == DealType.FreeGoods)
            {
                deal.rate = 0;
                deal.Amount = 0;
            }

            await _dealcode.SaveChangesAsync();

            return deal.Adapt<DealCodeResponse>();
        }
    }
}
