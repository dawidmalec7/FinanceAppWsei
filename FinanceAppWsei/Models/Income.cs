using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceAppWsei.Models
{
    public class Income
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Category Category { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public Guid? MoneyBoxId { get; set; }
        public MoneyBox MoneyBox { get; set; }

    }
}
