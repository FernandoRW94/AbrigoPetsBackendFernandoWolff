using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbrigoPetsBackend.Data.Models
{
    [Table("Shelters")]
    public class Shelter
    {
        [Key]
        public int ShelterId { get; set; }

        public string ShelterName { get; set; }

        public decimal ShelterMoney { get; set; }

        public decimal LastRevenue { get; set; }

        public decimal LastExpense { get; set; }

        public decimal TotalFood { get; set; }
    }
}
