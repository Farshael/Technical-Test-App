using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TechnicalTest.ViewModels
{
    public class EditProfileViewModel
    {
        public string Id { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        public string? FullName { get; set; }

        public IFormFile? ProfileImage { get; set; }

        public string? CurrentProfileImagePath { get; set; }
    }
}
