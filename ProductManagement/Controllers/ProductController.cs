namespace ProductManagementApi;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    List<Product> products = new();
    public ProductController()
    {
        for (int i = 1; i <= 9; i++)
        {
            products.Add(new Product()
            {
                ProductId = i,
                Name = "P" + i,
                Description = "kind of product",
                StockQuantity = i,
                Price = 100 + i,
                CreateDate = DateTime.Now
            });
        }
    }

    [HttpGet("get")]
    public IEnumerable<Product> Get()
    {
        return products;
    }

    [HttpPost("post")]
    public Product Post([FromBody] Product product)
    {
        try
        {

            if (ModelState.IsValid & product is not null)
                products.Add(product);
        } 

        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        return product;
    }

    [HttpDelete("{id}")]
    public int  Delete(int id)
    {
        var toRemoveProduct = products.FirstOrDefault(e => e.ProductId == id);
        
        if (toRemoveProduct.ProductId != null)
        {
            products.Remove(toRemoveProduct);

            return products.Count();
        }

        return 0;
    }
}
