using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class AccountTransaction
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
