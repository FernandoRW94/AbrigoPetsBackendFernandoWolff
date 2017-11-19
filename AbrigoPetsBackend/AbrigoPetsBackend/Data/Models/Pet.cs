using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbrigoPetsBackend.Data.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public string Size { get; set; }

        public string Sex { get; set; }
   
        public int Age { get; set; }

        public bool UpToDateVaccines { get; set; }

        public bool ToBeAdopted { get; set; }

        public bool Castrated { get; set; }

        public DateTime DateOfArrival { get; set; }

        public DateTime NextVaccine { get; set; }
    }
}
