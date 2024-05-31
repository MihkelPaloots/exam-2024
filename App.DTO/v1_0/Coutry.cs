using System.ComponentModel.DataAnnotations;


namespace App.DTO.v1_0;

public class Country
{
    [MaxLength(128)]
    public string CountryName { get; set; } = default!;
    public string CountryAlpha2Code { get; set; } = default!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

}