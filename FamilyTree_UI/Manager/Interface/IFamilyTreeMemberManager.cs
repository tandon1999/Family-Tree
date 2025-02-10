using FamilyTree_UI.Shared;
using FamilyTreeUI.Models;
using FamilyTreeUI.Pages.Shared;
using FamilyTreeUI.ViewModels;

namespace FamilyTreeUI.Manager.Interface
{
    public interface IFamilyTreeMemberManager : IManager
    {
        Task<IResponse> CreateFamilyTreeMember(FamilyMemberSetupModel model);
        Task<IResponse> DeleteFamilyTreeMember(int Id);
        Task<IResponse<List<FamilyTreeMemberVModel>>> GetFamilyTreeMembers();
        Task<FamilyMemberSetupModel> GetFamilyTreeMemberByid(int Id);
    }
}
