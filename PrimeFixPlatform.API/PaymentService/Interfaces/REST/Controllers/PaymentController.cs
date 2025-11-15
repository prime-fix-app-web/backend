using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
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
    ///     The created payment resopnse details
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
        
        if (string.IsNullOrWhiteSpace(paymentId)) return BadRequest();

        var getPaymentByIdQuery = new GetPaymentByIdQuery(paymentId);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        
        if (payment is null) return NotFound();

        var paymentResponse = PaymentAssembler.ToResponseFromEntity(payment);
        return Ok(paymentResponse);
    }

    /// <summary>
    ///     Get all payments, optionally filtered by user account ID
    /// </summary>
    /// <param name="idUserAccount">
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
    public async Task<IActionResult> GetAllPayments([FromBody] string? idUserAccount)
    {
        IEnumerable<Payment> payments;
        if (idUserAccount is null)
        {
            var getAllPaymentsQuery = new GetAllPaymentsQuery();
            payments = await paymentQueryService.Handle(getAllPaymentsQuery);
        }
        else
        {
            var query = new GetPaymentByIdUserAccountQuery(idUserAccount);
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
    /// <param name="id_payment">
    ///     The unique ID of the payment
    /// </param>
    /// <returns>
    ///     The payment response details
    /// </returns>
    [HttpGet("{id_payment}")]
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
    public async Task<IActionResult> GetPaymentById(string id_payment)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(id_payment);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        
        if (payment is null) return NotFound();
        
        var paymentResponse = PaymentAssembler.ToResponseFromEntity(payment);
        return Ok(paymentResponse);
    }
    
    /// <summary>
    ///     Update an existing payment
    /// </summary>
    /// <param name="id_payment">
    ///     The unique ID of the payment to update
    /// </param>
    /// <param name="request">
    ///     The payment update request data
    /// </param>
    /// <returns>
    ///     The updated payment response details
    /// </returns>
    [HttpPut("{id_payment}")]
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
    public async Task<IActionResult> UpdateVehicle(string id_payment, [FromBody] UpdatePaymentRequest request)
    {
        var updatePaymentCommand = PaymentAssembler.ToCommandFromRequest(request, id_payment);
        var payment = await paymentCommandService.Handle(updatePaymentCommand);
        if (payment is null) return BadRequest();
        
        var paymentResponse = PaymentAssembler.ToResponseFromEntity(payment);
        return Ok(paymentResponse);
    }
    
    
    /// <summary>
    ///     Delete a payment by its ID
    /// </summary>
    /// <param name="id_payment">
    ///     The unique ID of the payment to delete
    /// </param>
    /// <returns>
    ///     No content on successful deletion
    /// </returns>
    [HttpDelete("{id_payment}")]
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
    public async Task<IActionResult> DeleteVehicle(string id_payment)
    {
        var deletePaymentCommand = new DeletePaymentCommand(id_payment);
        var result = await paymentCommandService.Handle(deletePaymentCommand);
        
        if (!result) return BadRequest();
        
        return NoContent();
    }
    
    
    
    
    
    
    
}