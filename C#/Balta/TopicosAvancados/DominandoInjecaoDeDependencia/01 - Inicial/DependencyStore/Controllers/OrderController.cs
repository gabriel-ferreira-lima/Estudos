using Dapper;
using DependencyStore.Models;
using DependencyStore.Repository;
using DependencyStore.Repository.Contracts;
using DependencyStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase {

    private readonly ICustomerRepository _costumerRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;
    private readonly IPromoCodeRepository _promoCodeRepository;

    public OrderController(
        ICustomerRepository costumerRepository, 
        IDeliveryFeeService deliveryFeeService, 
        IPromoCodeRepository promoCodeRepository) {

        _costumerRepository = costumerRepository;
        _deliveryFeeService = deliveryFeeService;
        _promoCodeRepository = promoCodeRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products) {

        var customer = await _costumerRepository.GetByIdAsync(customerId);
        if (customer == null) {
            return NotFound();
        }

        decimal deliveryFee = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);
        var cupom = await _promoCodeRepository.GetPromoCodeAsync(promoCode);
        var discount = cupom?.Value ?? 0M;

        var order = new Order(deliveryFee, discount, new List<Product>());

        return Ok(new {
            Message = $"Pedido {order.Code} gerado com sucesso!"
        });
    }
}