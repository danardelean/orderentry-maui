namespace OrderEntry.Services;

public class MockProductRepository : IProductRepository
{
    IList<Product> _products = new List<Product>
    {
        new Product{Id=1, Description="Argento proteinato", Barcode="0WXCBU"},
        new Product{Id=2, Description="Maniva Acqua Naturale", Barcode="8022966312005"}
    };

    public Task<IList<Product>> GetAllProductsAsync()
    {
        return Task.FromResult<IList<Product>>(_products);
    }

    public async Task<Product> GetProductAsync(string barcode)
    {
        //Simulate delay in search
       // await Task.Delay(TimeSpan.FromSeconds(3));
        return _products.Where(p => p.Barcode == barcode).FirstOrDefault();
    }
}

