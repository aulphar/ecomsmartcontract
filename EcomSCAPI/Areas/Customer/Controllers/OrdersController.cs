﻿using EcomSCAPI.Common.Enums;
using EcomSCAPI.Services.Dtos.APIResponse;
using EcomSCAPI.Services.Dtos.OrderHeader;
using EcomSCAPI.Services.Dtos.Shipping;
using EcomSCAPI.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomSCAPI.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICustomerOrderOperation _customerOrderOperation;
        public OrdersController(ICustomerOrderOperation customerOrderOperation)
        {
            _customerOrderOperation = customerOrderOperation;
        }

        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<OrderOverviewResponse>>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetAll(OrderStatus? orderStatus, int? page)
        {
            APIResponse<IEnumerable<OrderOverviewResponse>> listOfOrders =
                await _customerOrderOperation.GetOrdersAsync(orderStatus, page);

            return Ok(listOfOrders);
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<OrderResponse>>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetOrderById(string orderId)
        {
            APIResponse<OrderResponse> orderDetails = await _customerOrderOperation.GetOrderByIdAsync(orderId);

            return Ok(orderDetails);
        }

        [HttpGet("Cancel/{orderId}")]
        [ProducesResponseType(typeof(APIResponse<UpdateOrderStatusResponse>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CancelOrder(string orderId)
        {
            APIResponse<UpdateOrderStatusResponse> orderStatusUpdateResponse =
                await _customerOrderOperation.CancelOrderAsync(orderId);

            return Ok(orderStatusUpdateResponse);
        }

        [HttpPut("{orderId}/Shipping")]
        [ProducesResponseType(typeof(APIResponse<ShippingDetailsResponse>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateShippingAddress(string orderId, UpdateShippingAddressRequest shippingAddressRequest)
        {

            APIResponse<ShippingDetailsResponse> shippingDetailsResponse =
                await _customerOrderOperation.UpdateOrderShippingAddressAsync(orderId, shippingAddressRequest);

            return Ok(shippingDetailsResponse);
        }
    }
}
