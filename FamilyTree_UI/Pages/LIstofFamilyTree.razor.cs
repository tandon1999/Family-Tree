using Blazored.Toast.Services;
using FamilyTreeUI.Manager.Interface;
using FamilyTreeUI.Models;
using FamilyTreeUI.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FamilyTree_UI.Pages
{
    public partial class LIstofFamilyTree
    {
        [Inject] public IFamilyTreeMemberManager _familyTreeMemberManager { get; set; } = default!;
        [Inject] public IToastService _toastservice { get; set; } = default!;

        public FamilyMemberSetupModel memberSetupModel { get; set; } = new();
        public FamilyTreeMemberVModel familyTreeMembervmodel { get; set; } = new();
        public List<FamilyTreeMemberVModel> familyTreeMemberlist { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await GetAllFamilyDetails();
            }
            catch (Exception ex)
            {
                _toastservice.ShowWarning(ex.Message);
            }
        }

        public async Task GetAllFamilyDetails()
        {
            try
            {
                var response = await _familyTreeMemberManager.GetFamilyTreeMembers();
                if (response?.Data != null && response.Data.Count > 0)
                {
                    familyTreeMemberlist = response.Data;
                }

            }
            catch (Exception ex)
            {
                _toastservice.ShowWarning(ex.Message);
            }
        }

        public async Task Delete(int Id)
        {
            try
            {
                var response = await _familyTreeMemberManager.DeleteFamilyTreeMember(Id);
                if (response.Succeeded)
                {
                    _toastservice.ShowSuccess(response.Messages);
                    await GetAllFamilyDetails();
                }
            }
            catch (Exception ex)
            {
                _toastservice.ShowWarning(ex.Message);
            }
        }
        public async Task Edit(int Id)
        {
            try
            {
                var response = await _familyTreeMemberManager.GetFamilyTreeMemberByid(Id);
                memberSetupModel = response;
            }
            catch (Exception ex)
            {
                _toastservice.ShowWarning(ex.Message);
            }
        }
    }
}