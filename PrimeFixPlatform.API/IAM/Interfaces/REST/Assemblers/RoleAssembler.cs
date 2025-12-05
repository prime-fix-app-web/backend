using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Role-related requests, commands, and responses.
/// </summary>
public static class RoleAssembler
{
    public static RoleResponse ToResponseFromEntity(Role entity)
    {
        return new RoleResponse(entity.Id, entity.GetStringName());
    }
}