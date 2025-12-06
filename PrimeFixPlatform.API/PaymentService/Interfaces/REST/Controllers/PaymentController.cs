using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Queries;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.PaymentService.Interfaces.REST.Assemblers;
using PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Controllers;

/// <summary>
///     REST controller for managing payments.
/// </summary>
/// <param name="paymentQueryService">
///     The payment query service for handling read operations.
/// </param>
/// <param name="paymentCommandService">
///     The payment command service for handling write operations.
/// </param>
[ApiController]
[Route("api/v1/payments")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Payments Endpoints")]
public class PaymentController(IPaymentQueryService paymentQueryService, 
                            IPaymentCommandService paymentCommandService) 
: ControllerBase
{
    /// <summary>
    ///     Create a new payment
    /// </summary>
    /// <param name="request">
    ///     The payment creation request data
    /// </param>
    /// <returns>
    ///     The created payment response details
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new payment",
        Description = "Creates a new payment with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status201Created,
        "Payment created successfully",
        typeof(PaymentResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
    {
        var createPaymentCommand = PaymentAssembler.ToCommandFromRequest(request);
        var paymentId = await paymentCommandService.Handle(createPaymentCommand);
        
        /*if (string.IsNullOrWhiteSpace(paymentId)) return BadRequest();*/

        var getPaymentByIdQuery = new GetPaymentByIdQuery(paymentId);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        
        if (payment is null) return NotFound();

        var paymentResponse = PaymentAssembler.ToResponseFromEntity(payment);
        return Ok(paymentResponse);
    }

    /// <summary>
    ///     Get all payments, optionally filtered by user account ID
    /// </summary>
    /// <param name="user_account_id">
    ///     The user account ID to filter payments by (optional)
    /// </param>
    /// <returns>
    ///     The list of payments
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieve all payments",
        Description = "Retrieves a list of all payments"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Payments retrieved successfully",
        typeof(IEnumerable<PaymentResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetAllPayments([FromQuery] int user_account_id)
    {
        IEnumerable<Payment> payments;
        if (user_account_id == 0)
        {
            var getAllPaymentsQuery = new GetAllPaymentsQuery();
            payments = await paymentQueryService.Handle(getAllPaymentsQuery);
        }
        else
        {
            var query = new GetPaymentByIdUserAccountQuery(user_account_id);
            payments = await paymentQueryService.Handle(query);
        }
        
        var paymentResponses = payments
            .Select(PaymentAssembler.ToResponseFromEntity)
            .ToList();
        
        return Ok(paymentResponses);
    }
    
    
    /// <summary>
    ///     Get a payment by its ID
    /// </summary>
    /// <param name="payment_id">
    ///     The unique ID of the payment
    /// </param>
    /// <returns>
    ///     The payment response details
    /// </returns>
    [HttpGet("{payment_id}")]
    [SwaggerOperation(
        Summary = "Retrieve a payment by its ID",
        Description = "Retrieves a payment using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Payment retrieved successfully",
        typeof(PaymentResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Payment not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> GetPaymentById(int payment_id)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(payment_id);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        
        if (payment is null) return NotFound();
        
        var paymentResponse = PaymentAssembler.ToResponseFromEntity(payment);
        return Ok(paymentResponse);
    }
    
    /// <summary>
    ///     Update an existing payment
    /// </summary>
    /// <param name="payment_id">
    ///     The unique ID of the payment to update
    /// </param>
    /// <param name="request">
    ///     The payment update request data
    /// </param>
    /// <returns>
    ///     The updated payment response details
    /// </returns>
    [HttpPut("{payment_id}")]
    [SwaggerOperation(
        Summary = "Update an existing payment",
        Description = "Update an existing payment with the provided data"
    )]
    [SwaggerResponse(StatusCodes.Status200OK,
        "Payment updated successfully",
        typeof(PaymentResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid input data",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Payment not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status409Conflict, 
        "Conflict", 
        typeof(ConflictResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> UpdateVehicle(int payment_id, [FromBody] UpdatePaymentRequest request)
    {
        var updatePaymentCommand = PaymentAssembler.ToCommandFromRequest(request, payment_id);
        var payment = await paymentCommandService.Handle(updatePaymentCommand);
        if (payment is null) return BadRequest();
        
        var paymentResponse = PaymentAssembler.ToResponseFromEntity(payment);
        return Ok(paymentResponse);
    }
    
    
    /// <summary>
    ///     Delete a payment by its ID
    /// </summary>
    /// <param name="payment_id">
    ///     The unique ID of the payment to delete
    /// </param>
    /// <returns>
    ///     No content on successful deletion
    /// </returns>
    [HttpDelete("{payment_id}")]
    [SwaggerOperation(
        Summary = "Delete a payment by its ID",
        Description = "Deletes a payment using its unique ID"
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent,
        "Payment deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
        "Bad request - Invalid payment ID",
        typeof(BadRequestResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
        "Payment not found",
        typeof(NotFoundResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, 
        "Internal server error", 
        typeof(InternalServerErrorResponse))]
    public async Task<IActionResult> DeleteVehicle(int payment_id)
    {
        var deletePaymentCommand = new DeletePaymentCommand(payment_id);
        var result = await paymentCommandService.Handle(deletePaymentCommand);
        
        if (!result) return BadRequest();
        
        return NoContent();
    }
}