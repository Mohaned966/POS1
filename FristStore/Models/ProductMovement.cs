using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class ProductMovement
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; } 
    }


    public enum MovementType
    {
        شراء,
        بيع
    }
}
