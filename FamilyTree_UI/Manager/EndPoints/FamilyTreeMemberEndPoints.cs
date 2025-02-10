namespace FamilyTreeUI.Manager.EndPoints
{
    public static class FamilyTreeMemberEndPoints
    {
        public static string CreateFamilyTreeMember = "https://localhost:7140/api/FamilyMember/CreateFamilyMember";
        public static string GetFamilyTreeMembers = "https://localhost:7140/api/FamilyMember/GetAllFamilyMember";
        public static string DeleteFamilyTreeMember(int Id)
        {
            return $"https://localhost:7140/api/FamilyMember/DeleteFamilyMember?Id={Id}";
        }
        public static string GetFamilyTreeMemberByid(int Id)
        {
            return $"https://localhost:7140/api/FamilyMember/GetFamilyMemberById?Id={Id}";
        }
    }
}
