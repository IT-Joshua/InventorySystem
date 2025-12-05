namespace Backend.Entities;

public class Company
{
    public Guid Id { get; set; }
    public required string Company_Name { get; set; }
    public required string Prefix { get; set; }
    public required bool Is_Active { get; set; }
    public required string Transaction_Prefix { get; set; }
    public required int Transaction_Series { get; set; }
    public required string Transaction_Format { get; set; }
    public DateTime Created_Timestamp { get; set; }
    public DateTime Updated_Timestamp { get; set; }

}
