using AutoMapper;
using FamilyTreeApi.Param;
using FamilyTreeApi.RequestModel;
using FamilyTreeApi.ResponseModel;
using FamilyTreeApi.Service.Interface;
using FamilyTreeApi.Shared;
using FamilyTreeApi.Shared.DataBaseAccess.GenericRepository.Interface;
using Shared.Services.Interface;

namespace FamilyTreeApi.Service.Implementation
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileuploadservice;

        public FamilyMemberService(IGenericRepository genericRepository, IMapper mapper,IFileUploadService fileUploadService)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _fileuploadservice = fileUploadService;
        }
        private readonly string StoreProc = "SpFamilyTreeSetup";
        public async Task<IResponse> CreateFamilyTreeMember(FamilyTreeMemberRequestModel model)
        {
            try
            {
                if(model.imageUpload != null)
                {
                    var FolderName = "";
                    var newFolderName = "TandanImage";
                    var newFolderPath = Path.Combine(FolderName, newFolderName);
                    var filedata = await _fileuploadservice.UploadFileAsync(model.imageUpload.FileByte, model.imageUpload.FileName, newFolderPath);
                    model.ImagePath = filedata.ToString();
                }
                FamilyTreeParam param = new();
                param = _mapper.Map<FamilyTreeParam>(model);
                param.Flag = 'C';
                var response = await _genericRepository.GetAsync<Response>(StoreProc, param);
                return await Response.SuccessAsync(response.Messages);
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
                var response = await _genericRepository.GetAsync<Response>(StoreProc, param);
                return await Response.SuccessAsync(response.Messages);
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
