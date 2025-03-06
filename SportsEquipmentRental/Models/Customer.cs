using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using SportsEquipmentRental.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    public ICollection<RentalPlan> Rentals { get; set; }
}
