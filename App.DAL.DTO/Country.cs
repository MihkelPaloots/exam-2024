using Base.Contracts.Domain;
using Base.Domain;

namespace App.DAL.DTO;

public class Country: BaseEntityIdMetadata, IDomainEntityId
{
public string CountryName { get; set; } = default!;
public string CountryAlpha2Code { get; set; } = default!;
public double Latitude { get; set; }
public double Longitude { get; set; }
    
public ICollection<City>? Cities { get; set; }
}