namespace PropertyManagementApplication.Models;

public class Property
{
    public int Id { get; set; }
    public string StreetAddress { get; set;}
    public string City { get; set; }
    public string Zip { get; set; }
    public string State { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public string Name { get; set; }
    public List<Unit> Units { get; set; } = new();
}