using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

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
    /// <param name="starRating">
    ///     The star rating of the rating
    /// </param>
    /// <param name="comment">
    ///     The comment of the rating
    /// </param>
    /// <param name="autoRepairId">
    ///     The identifier of the auto repair associated with the payment.
    /// </param>
    /// <param name="userAccountId">
    ///     The identifier of the user account associated with the payment.
    /// </param>
    public Rating( int starRating, string comment,
        int autoRepairId, int userAccountId)
    {
        if (starRating < 1 || starRating > 5)
            throw new ArgumentException("Star rating must be between 1 and 5.");
        StarRating = starRating;
        Comment = comment;
        AutoRepairId = autoRepairId;
        UserAccountId = userAccountId;
    }

    /// <summary>
    ///     Constructor for the rating aggregate root entity from CreateRatingCommand
    /// </summary>
    /// <param name="command">
    ///     The command object containing data to create a Rating
    /// </param>
    public Rating(CreateRatingCommand command) : this(
        command.StarRating,
        command.Comment,
        command.AutoRepairId,
        command.UserAccountId)
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
        RatingId = command.RatingId;
        StarRating = command.StarRating;
        Comment = command.Comment;
        AutoRepairId = command.AutoRepairId;
        UserAccountId = command.UserAccountId;
    }
    
    public int RatingId { get; private set; }
    public int StarRating { get; private set; }
    public string Comment { get; private set; }
    public int AutoRepairId { get; private set; }
    public int UserAccountId { get; private set; }
    
}