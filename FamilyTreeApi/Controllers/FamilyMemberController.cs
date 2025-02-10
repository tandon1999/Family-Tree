using FamilyTreeApi.RequestModel;
using FamilyTreeApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMemberController : ControllerBase
    {
        private readonly IFamilyMemberService _familyMemberService;
        public FamilyMemberController(IFamilyMemberService familyMemberService)
        {
            _familyMemberService= familyMemberService;
        }

        [HttpPost("CreateFamilyMember")]
        public async Task<IActionResult> CreateFamilyMemberAsync(FamilyTreeMemberRequestModel model)
        {
            var response = await _familyMemberService.CreateFamilyTreeMember(model);
            return Ok(response);
        }

        [HttpDelete("DeleteFamilyMember")]
        public async Task<IActionResult> DeleteFamilyMemberAsync(int Id)
        {
            var response = await _familyMemberService.DeleteFamilyTreeMember(Id);
            return Ok(response);
        }

        [HttpGet("GetAllFamilyMember")]
        public async Task<IActionResult> GetAllFamilyMemberAsync()
        {
            var response = await _familyMemberService.GetFamilyTreeMembers();
            return Ok(response);
        }

        [HttpGet("GetFamilyMemberById")]
        public async Task<IActionResult> GetFamilyMemberByIdAsync(int Id)
        {
            var response = await _familyMemberService.GetFamilyTreeMemberByid(Id);
            return Ok(response);
        }
    }
}
