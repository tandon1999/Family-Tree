using FamilyTreeUI.Manager.Interface;
using FamilyTreeUI.Models;
using FamilyTreeUI.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.CodeAnalysis;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Forms;
using FamilyTree_UI.Shared;

namespace FamilyTree_UI.Pages
{
    public partial class FamilyTreeMemberSetupPage
    {
        [Inject] public IFamilyTreeMemberManager _familyTreeMemberManager { get; set; } = default!;
        [Inject] public IToastService _toastservice { get; set; } = default!;

        public FamilyMemberSetupModel memberSetupModel { get; set; } = new();
        public FamilyTreeMemberVModel familyTreeMembervmodel { get; set; } = new();
        public List<FamilyTreeMemberVModel> familyTreeMemberlist { get; set; } = new();

        private int age;
        private DateTime dob;
        private string uploadedImageUrl;
        protected override async Task OnInitializedAsync()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                _toastservice.ShowWarning(ex.Message);
            }
        }
        public async Task Save()
        {
            try
            {
                var response = await _familyTreeMemberManager.CreateFamilyTreeMember(memberSetupModel);
                if (response.Succeeded)
                {
                    _toastservice.ShowSuccess(response.Messages);
                    memberSetupModel = new();
                }
            }
            catch (Exception ex)
            {
                _toastservice.ShowWarning(ex.Message);
            }
        }

        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            var _file = e.File;
            if (_file != null)
            {
                var extension = Path.GetExtension(_file.Name);
                var filename = $"{Guid.NewGuid()}{extension}";
                var format = "";
                if (extension == ".pdf")
                {
                    format = "Application/pdf";
                }
                else if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                {
                    format = $"image/{extension.TrimStart('.')}";
                }
                using var stream = _file.OpenReadStream(51200000000);
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                byte[] buffer = ms.ToArray();

                if (format.StartsWith("image/"))
                {
                    var base64 = Convert.ToBase64String(buffer);
                    uploadedImageUrl = $"data:{format};base64,{base64}";
                }
                memberSetupModel.imageUpload = new ImageUpload { FileByte = buffer, FileName = filename, Extension = extension };
            }
        }

        private async Task CalculateAge(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out dob))
            {
                memberSetupModel.Age = await CalculateAgeFromDateOfBirth(dob);
                memberSetupModel.DOB = dob;
            }
        }

        private async Task<int> CalculateAgeFromDateOfBirth(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}