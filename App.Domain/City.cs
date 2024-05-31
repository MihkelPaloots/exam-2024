using System.ComponentModel.DataAnnotations;
using App.Domain.Identity;
using Base.Contracts.Domain;
using Base.Domain;

namespace App.Domain;

public class City: BaseEntityIdMetadata, IDomainEntityId
{
    [MaxLength(128)]
    public string CityName { get; set; } = default!;
    
    public Guid CountryId { get; set; }
    public Country? Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

}