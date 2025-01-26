using FristStore.Models;

namespace FristStore.ViewModels
{
    public class ProductMovementViewModel
    {
        public int Id { get; set; }
        public DateTime MovementDate { get; set; }
        public int ProductId { get; set; }
        public int QuantityMoved { get; set; }
        public string Description { get; set; }
    }

}
