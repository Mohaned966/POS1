using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public object Reports { get; internal set; }
    }
}
