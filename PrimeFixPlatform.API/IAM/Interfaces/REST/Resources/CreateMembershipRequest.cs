using System.ComponentModel.DataAnnotations;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Request to create a membership
/// </summary>
/// <param name="Description">
///     The description of the membership to be created
/// </param>
/// <param name="Started">
///     The start date of the membership to be created
/// </param>
/// <param name="Over">
///     The end date of the membership to be created
/// </param>
public record CreateMembershipRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    string Description,
    
    [Required]
    [DataType(DataType.Date)]
    DateOnly Started,
    
    [Required]
    DateOnly Over);