using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
