using FristStore.Models;

namespace FristStore.ViewModels
{
    public class AccountTransactionViewModel
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
