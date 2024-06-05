using Marombastore.Core.Seedwork;
using Marombastore.Order.Application.dto;
using Marombastore.Order.Domain.Entity;
using Marombastore.Order.Domain.Repository;

namespace Marombastore.Order.Application.UseCase;

public class PlaceOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlaceOrderUseCase(IOrderRepository orderRepository, IItemRepository itemRepository, ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
        _couponRepository = couponRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(PlaceOrderInput input)
    {
        var order = new Domain.Entity.Order(input.CustomerId);

        foreach (var orderItem in input.OrderItems)
        {
            Item item = await _itemRepository.GetById(orderItem.ItemId)
            ?? throw new Exception($"Item {orderItem.ItemId} not found");

            order.AddItem(item, orderItem.Quantity);
        }

        if (input.CouponId != null)
        {
            Coupon coupon = await _couponRepository.GetById(input.CouponId.Value)
            ?? throw new Exception($"Coupon {input.CouponId} not found");
            order.ApplyCoupon(coupon);
        }

        await _orderRepository.CreateAsync(order);
        await _unitOfWork.Commit();
    }
}