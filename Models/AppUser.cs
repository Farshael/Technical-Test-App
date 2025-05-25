using Microsoft.AspNetCore.Identity;

namespace TechnicalTest.Models
{
    public class AppUser : IdentityUser
    {
        // Kalau pakai IdentityUser, Id sudah ada (string). Jadi jangan buat Id int lagi.
        // Hapus properti Id, Email, PasswordHash, EmailConfirmed, karena sudah ada di IdentityUser.
        public string? FullName { get; set; } // Tambahkan ini
        public string? ProfilePicture { get; set; }
        public string? ProfileImagePath { get; set; }
        public string? ConfirmationToken { get; set; }
    }
}
