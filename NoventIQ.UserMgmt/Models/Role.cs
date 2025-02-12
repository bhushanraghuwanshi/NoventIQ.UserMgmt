using System.ComponentModel.DataAnnotations;
namespace NoventIQ.UserMgmt.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
