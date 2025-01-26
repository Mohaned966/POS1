using System.ComponentModel.DataAnnotations;

namespace FristStore.Models
{
    public class AccountReport
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public DateTime ReportDate { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalDebits { get; set; }
        public decimal TotalCredits { get; set; }
    }

}
