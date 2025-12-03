namespace PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;

public record AddServiceToAutoRepairServiceCatalogCommand(int AutoRepairId, int ServiceId, decimal Price);