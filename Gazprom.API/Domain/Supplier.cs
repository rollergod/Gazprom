using System.Text.Json.Serialization;

namespace Gazprom.API.Domain;

public class Supplier
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    [JsonIgnore]
    public ICollection<Offer> Offers { get; set; }
}