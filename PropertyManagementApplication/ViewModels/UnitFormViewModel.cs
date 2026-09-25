using Microsoft.Build.Framework;

namespace PropertyManagementApplication.ViewModels;

public class UnitFormViewModel
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    [Required]
    public int UnitNumber { get; set; }
    [Required]
    public int Bedrooms { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int MonthlyRent { get; set; }
    [Required]
    public int SquareFootage { get; set; }
    [Required]
    public string UnitType { get; set; }
}