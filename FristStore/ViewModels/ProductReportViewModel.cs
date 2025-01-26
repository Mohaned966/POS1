using FristStore.Models;

namespace FristStore.ViewModels
{
    public class ProductReportViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityInStock { get; set; }
        public decimal TotalValue { get; set; }
    }

}
