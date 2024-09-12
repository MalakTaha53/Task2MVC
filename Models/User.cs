using System.ComponentModel.DataAnnotations;

namespace Task2MVC.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public String? UserName { get; set; }
        [DataType(DataType.Password)]
        public String? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
