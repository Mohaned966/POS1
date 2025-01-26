using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
