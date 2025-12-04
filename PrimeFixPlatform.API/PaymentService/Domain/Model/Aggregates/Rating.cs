using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;

/// <summary>
///     Rating aggregate root entity
/// </summary>
public partial class Rating
{
    /// <summary>
    ///     Private constructor for ORM and serialization purposes
    /// </summary>
    private Rating() {}
    
    /// <summary>
    ///     The constructor for the Rating aggregate root entity
    /// </summary>
    /// <param name="idRating">
    ///     The unique identifier for the rating.
    /// </param>
    /// <param name="starRating">
    ///     The star rating of the rating
    /// </param>
    /// <param name="comment">
    ///     The comment of the rating
    /// </param>
    /// <param name="idAutoRepair">
    ///     The identifier of the auto repair associated with the payment.
    /// </param>
    /// <param name="idUserAccount">
    ///     The identifier of the user account associated with the payment.
    /// </param>
    public Rating(string idRating, int starRating, string comment,
        IdAutoRepair idAutoRepair, IdUserAccount idUserAccount)
    {
        if (starRating < 1 || starRating > 5)
            throw new ArgumentException("Star rating must be between 1 and 5.");
        IdRating = idRating;
        StarRating = starRating;
        Comment = comment;
        IdAutoRepair = idAutoRepair;
        IdUserAccount = idUserAccount;
    }

    /// <summary>
    ///     Constructor for the rating aggregate root entity from CreateRatingCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing data to create a Rating
    /// </param>
    public Rating(CreateRatingCommand command) : this(
        command.IdRating,
        command.StarRating,
        command.Comment,
        command.IdAutoRepair,
        command.IdUserAccount)
    {
    }

    /// <summary>
    ///     Update the rating details based on the UpdateRatingCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing updated data for the Rating
    /// </param>
    public void UpdateRating(UpdateRatingCommand command)
    {
        if (command.StarRating < 1 || command.StarRating > 5)
            throw new ArgumentException("Star rating must be between 1 and 5.");
        IdRating = command.IdRating;
        StarRating = command.StarRating;
        Comment = command.Comment;
        IdAutoRepair = command.IdAutoRepair;
        IdUserAccount = command.IdUserAccount;
    }
    
    public string IdRating { get; private set; }
    public int StarRating { get; private set; }
    public string Comment { get; private set; }
    public IdAutoRepair IdAutoRepair { get; private set; }
    public IdUserAccount IdUserAccount { get; private set; }
    
}