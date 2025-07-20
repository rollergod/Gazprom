namespace Gazprom.API.Domain;

public class Offer
{
    public int Id { get; set; }
    public required string Mark { get; set; }
    public required string Model { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public Supplier Supplier { get; set; }
    public int SupplierId { get; set; }
}