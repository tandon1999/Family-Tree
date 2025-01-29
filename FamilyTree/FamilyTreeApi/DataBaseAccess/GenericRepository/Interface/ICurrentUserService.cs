namespace FamilyTreeApi.DataBaseAccess.GenericRepository.Interface
{
    public interface ICurrentUserService
    {
        string? Name { get; }
        string? UserName { get; }
        int? UserId { get; }
        string? Role { get; }
        int? BranchId { get; }
        string? BranchType { get; }
    }
}
