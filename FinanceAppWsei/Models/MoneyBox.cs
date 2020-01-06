using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceAppWsei.Models
{
    public class MoneyBox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Target { get; set; }
        [NotMapped]
        public double Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }

    }
}
