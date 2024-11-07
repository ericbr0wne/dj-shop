using dj_shop.Interfaces;
using dj_shop.Models;
using System.Text.Json;

namespace dj_shop.Services;

public class ProductService : IProductService
{
    private readonly string _jsonFilePath;


    public ProductService()
    {
        _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "products.json");
    }

    public async Task<string> GetJsonAsStringAsync()
    {
        if (!File.Exists(_jsonFilePath))
            return null;

        return await File.ReadAllTextAsync(_jsonFilePath);
    }

    public async Task<List<ProductModel>> GetProductsAsync()
    {
        var json = await GetJsonAsStringAsync();
        if (string.IsNullOrEmpty(json))
            return null;


        using (JsonDocument doc = JsonDocument.Parse(json))
        {
            var products = doc.RootElement.EnumerateArray()
                .Select(element => new ProductModel
                {
                    Id = element.GetProperty("id").GetInt32(),
                    ProductName = element.GetProperty("name").GetString(),
                    Description = element.GetProperty("description").GetString(),
                    Price = element.GetProperty("price").GetDecimal(),
                    StockQuantity = element.GetProperty("stockQuantity").GetInt32(),
                    Category = element.GetProperty("category").GetString()
                }).ToList();

            return products;
        }
    }

    public async Task<ProductModel> GetProductByIdAsync(int id)
    {
        var products = await GetProductsAsync();
        if (products == null)
        {
            return null;
        }
        return products.FirstOrDefault(p => p.Id == id);
    }

    public async Task<List<ProductModel>> GetProductByCategory(string category)
    {
        var products = await GetProductsAsync();
        if (products == null)
        {
            return null;
        }
        return products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

