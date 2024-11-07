using dj_shop.Models;

namespace dj_shop.Interfaces;

public interface IProductService   
{
    Task<string> GetJsonAsStringAsync();
    Task<List<ProductModel>> GetProductsAsync();
    Task<ProductModel> GetProductByIdAsync(int id);
    Task<List<ProductModel>> GetProductByCategory(string category);
}