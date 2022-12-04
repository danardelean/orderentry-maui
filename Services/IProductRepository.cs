namespace OrderEntry.Services;

public interface IProductRepository
{
    Task<IList<Product>> GetAllProductsAsync();
    Task<Product> GetProductAsync(string barcode);
}

