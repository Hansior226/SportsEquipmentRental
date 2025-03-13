using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    public ICollection<RentalPlan>? Rentals { get; set; }
}
