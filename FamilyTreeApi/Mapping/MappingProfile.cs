using AutoMapper;
using FamilyTreeApi.Param;
using FamilyTreeApi.RequestModel;

namespace FamilyTreeApi.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<FamilyTreeParam, FamilyTreeMemberRequestModel>().ReverseMap();
        }
    }
}
