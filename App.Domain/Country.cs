using System.ComponentModel.DataAnnotations;
using Base.Contracts.Domain;
using Base.Domain;

namespace App.Domain;

public class Country: BaseEntityIdMetadata, IDomainEntityId
{
    [MaxLength(128)]
    public string CountryName { get; set; } = default!;
    public string CountryAlpha2Code { get; set; } = default!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public ICollection<City>? Cities { get; set; }
}