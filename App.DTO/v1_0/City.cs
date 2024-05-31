namespace App.DTO.v1_0;

public class City
{
    public string CityName { get; set; } = default!;
    public Guid CountryId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}