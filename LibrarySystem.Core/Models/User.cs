using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Core.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format email")]
        [Column("Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Column("PasswordHash")]
        public string PasswordHash { get; set; }
        
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        [Column("FirstName")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [Column("LastName")]
        public string LastName { get; set; }
        
        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }
        
        [Column("IsActive")]
        public bool IsActive { get; set; } = true;
        
        [Column("Role")]
        public string Role { get; set; } = "User";
    }
}