using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Material { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public bool Availability { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public ICollection<RentalPlan> Rentals { get; set; }
    }