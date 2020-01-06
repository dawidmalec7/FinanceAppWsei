using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceAppWsei.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime LifeTime { get; set; }
        public string Role { get; set; } = "User";
    }
}
