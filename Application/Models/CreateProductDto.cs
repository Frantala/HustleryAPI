namespace Application.Dto
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public Decimal Price { get; set; }
    }
}