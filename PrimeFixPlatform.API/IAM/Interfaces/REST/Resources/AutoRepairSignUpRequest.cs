using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

public record AutoRepairSignUpRequest(
    [property: JsonPropertyName("auto_repair_name")]
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string AutoRepairName,
    
    [property: JsonPropertyName("phone_number")]
    [Required]
    [StringLength(15, MinimumLength = 7)]
    string PhoneNumber,
    
    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    string Username,
    
    [property: JsonPropertyName("contact_email")]
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    string ContactEmail,
    
    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    string Password,
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    string Ruc,
    
    
    [Required]
    [MaxLength(100)]
    string Address,
    
    [Required]
    [MaxLength(50)]
    string District,
    
    [Required]
    [MaxLength(50)]
    string Department,
    
    [property: JsonPropertyName("membership_description")]
    [Required]
    [MaxLength(100)]
    string MembershipDescription, 

    [Required]
    [DataType(DataType.Date)]
    DateOnly Started,
    
    [Required]
    [DataType(DataType.Date)]
    DateOnly Over,
    
    [property: JsonPropertyName("card_number")]
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string CardNumber,
    
    [property: JsonPropertyName("card_type")]
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    string CardType,
    
    [Required]
    int Month,
    
    [Required]
    int Year,
    
    [Required]
    int Cvv);