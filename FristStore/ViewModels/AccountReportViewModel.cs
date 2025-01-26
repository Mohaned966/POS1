using FristStore.Models;

namespace FristStore.ViewModels
{
    public class AccountReportViewModel
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
    }

}
