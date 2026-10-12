namespace Application.Dto
{
    public class ProductDto
{
    public Guid Id {get; set;}
    public string Name { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public Decimal Price { get; set; }
}
}
