using System.ComponentModel.DataAnnotations;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

/// <summary>
///     Representation of a request to update a membership.
/// </summary>
/// <param name="Description">
///     The new description for the membership.
/// </param>
/// <param name="Started">
///     The start date of the membership to update.
/// </param>
/// <param name="Over">
///     The end date of the membership to update.
/// </param>
public record UpdateMembershipRequest(
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    string Description,
    
    [Required]
    [DataType(DataType.Date)]
    DateOnly Started,
    
    [Required]
    [DataType(DataType.Date)]
    DateOnly Over);