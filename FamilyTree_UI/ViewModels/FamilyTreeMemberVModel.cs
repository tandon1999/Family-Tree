namespace FamilyTreeUI.ViewModels
{
    public class FamilyTreeMemberVModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string? GenderName { get; set; }
        public string? OccupationType { get; set; }
        public string? Description { get; set; }
        public DateTime DeathDate { get; set; }
        public string? MatrialStatus { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Address { get; set; }
    }
}
