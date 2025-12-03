namespace PrimeFixPlatform.API.CollectionDiagnosis.Domain.Model.Commands;
/// <summary>
///     Command to delete a Service
/// </summary>
/// <param name="ServiceId">
///     The ID of the service to be deleted
/// </param>
public record DeleteServiceCommand(int ServiceId);