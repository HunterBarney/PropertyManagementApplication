using System.ComponentModel.DataAnnotations;

namespace PropertyManagementApplication.ViewModels;

public class PropertyFormViewModel
{
    public int Id { get; set; } = 0;
    [Required]
    [Display(Name = "Street Address")]
    public string StreetAddress { get; set;} = string.Empty;
    [Required]
    [Display(Name = "City")]
    public string City { get; set; } = string.Empty;
    [Required] 
    [Display(Name = "Zip")] 
    public string Zip { get; set; } = string.Empty;
    [Required]
    [Display(Name = "State")]
    public string State { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Contact Phone Number")]
    [Phone]
    public string ContactPhone { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Contact Email")]
    [EmailAddress]
    public string ContactEmail { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Property Name")]
    public string Name { get; set; } = string.Empty;
}