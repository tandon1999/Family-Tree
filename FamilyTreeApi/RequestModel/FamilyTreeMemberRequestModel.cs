﻿using FamilyTreeApi.Shared.Model;

namespace FamilyTreeApi.RequestModel
{
    public class FamilyTreeMemberRequestModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }= DateTime.Now;
        public int Age { get; set; }
        public int Gender { get; set; }
        public int Occupation { get; set; }
        public int FatherName { get; set; }
        public int MotherName { get; set; }
        public string? Description { get; set; }
        public DateTime? DeathDate { get; set; }
        public int MatrialStatus { get; set; }
        public int NoOfChildren { get; set; }
        public ImageUpload imageUpload { get; set; }
        public string? ImagePath { get; set; }


    }
}
