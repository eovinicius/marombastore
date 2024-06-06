using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Application.Dto;
using Marombastore.Inventory.Domain.Entity;
using Marombastore.Inventory.Domain.Repository;

namespace Marombastore.Inventory.Application.UseCases;
public class ReserveProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReserveProductUseCase(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork
    )
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UnreservebleProductOutputDto>> Execute(
        ReserveListProductsInputDto data)
    {
        // NOTE: dumb implementation, better luck next time
        // NOTE: next time, use async to get product by id

        var unreservebleProducts =
            new List<UnreservebleProductOutputDto>();

        foreach (var orderProduct in data.Products)
        {
            var productEntity = await _productRepository
                .GetById(orderProduct.ProductId);

            if (productEntity == null)
                throw new Exception("Product not found");

            var unreservebleProduct = ReserveProduct(
                productEntity, orderProduct.Quantity);

            if (unreservebleProduct != null)
                unreservebleProducts.Add(unreservebleProduct);
        }

        if (unreservebleProducts.Count < 1)
            await _unitOfWork.Commit();

        return unreservebleProducts;
    }

    public UnreservebleProductOutputDto? ReserveProduct(
        Product product, int quantity)
    {
        if (quantity > product.AvailableQuantity)
        {
            return new UnreservebleProductOutputDto(
                product.Id,
                product.AvailableQuantity
            );
        }

        product.ReserveQuantity(quantity);
        _productRepository.UpdateAsync(product);

        return null;
    }
}

