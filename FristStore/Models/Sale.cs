using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalPrice { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public DateTime SaleDate { get; set; }
    }

}
