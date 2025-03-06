using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RentalPlan
{
    [Key]
    public int RentalId { get; set; }

    [Required]
    public DateTime RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    [ForeignKey("Equipment")]
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
