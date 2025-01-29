using AutoMapper;
using FamilyTreeApi.DataBaseAccess.GenericRepository.Interface;
using FamilyTreeApi.Param;
using FamilyTreeApi.RequestModel;
using FamilyTreeApi.ResponseModel;
using FamilyTreeApi.Service.Interface;
using FamilyTreeApi.Shared;

namespace FamilyTreeApi.Service.Implementation
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        private readonly string StoreProc = "SpFamilyTreeSetup";
        public async Task<IResponse> CreateFamilyTreeMember(FamilyTreeMemberRequestModel model)
        {
            try
            {
                FamilyTreeParam param = new();
                param = _mapper.Map<FamilyTreeParam>(model);
                param.Flag = 'C';
                var response = await _genericRepository.InsertAsync(StoreProc, param);
                return await Response.SuccessAsync(response.Message);
            }
            catch (Exception ex)
            {
                return await Response.FailAsync(ex.Message);
            }
        }

        public async Task<IResponse> DeleteFamilyTreeMember(int Id)
        {
            try
            {
                FamilyTreeParam param = new();
                param.Flag = 'D';
                param.Id = Id;
                var response = await _genericRepository.DeleteAsync(StoreProc, param);
                return await Response.SuccessAsync(response.Message);
            }
            catch (Exception ex)
            {
                return await Response.FailAsync(ex.Message);
            }
        }

        public async Task<IResponse<FamilyTreeMemberRequestModel>> GetFamilyTreeMemberByid(int Id)
        {
            try
            {
                FamilyTreeParam param = new();
                param.Flag = 'I';
                param.Id = Id;
                var response = await _genericRepository.GetAsync<FamilyTreeMemberRequestModel>(StoreProc, param);
                return await Response<FamilyTreeMemberRequestModel>.SuccessAsync(response);

            }
            catch (Exception ex)
            {
                return await Response<FamilyTreeMemberRequestModel>.FailAsync(ex.Message);
            }
        }

        public async Task<IResponse<List<FamilyTreeMemberResponseModel>>> GetFamilyTreeMembers()
        {
            try
            {
                FamilyTreeParam param = new();
                param.Flag = 'G';
                var response = await _genericRepository.GetAllAsync<FamilyTreeMemberResponseModel>(StoreProc, param);
                return await Response<List<FamilyTreeMemberResponseModel>>.SuccessAsync(response.ToList());
            }
            catch (Exception ex)
            {
                return await Response<List<FamilyTreeMemberResponseModel>>.FailAsync(ex.Message);
            }
        }
    }
}
