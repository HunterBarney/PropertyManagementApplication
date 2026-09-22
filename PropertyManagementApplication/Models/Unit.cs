namespace PropertyManagementApplication.Models;

public class Unit
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
    public int UnitNumber { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int MonthlyRent { get; set; }
    //TODO: Add UnitType
    //TODO: Add RentalApplications
    //TODO: Add Lease
}