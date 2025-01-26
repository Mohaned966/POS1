using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class ProductReport
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime ReportDate { get; set; }
        public decimal QuantityInStock { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalPurchases { get; set; }
    }

}
