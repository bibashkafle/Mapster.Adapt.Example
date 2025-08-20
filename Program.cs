using Mapster;
using System.Text.Json;
public class Program
{
    public static void Main(string[] args)
    {
        // Register mapping configuration
        TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);

        var user = new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            PhoneNumber = "123-456-7890",
            DateOfBirth = new DateTime(1990, 5, 20),
            Address = "123 Main St, Fair Fax, VA 10001",
            IsActive = true,
            PasswordHash = "hashed-password"
        };

        var userDto = user.Adapt<UserDto>();

        var product = new Product { Id = 101, Name = "Laptop", Price = 999.99m, CreatedOn = DateTime.UtcNow };
        var productDto = product.Adapt<ProductDto>();

        Console.WriteLine(userDto.ToString());

        Console.WriteLine(productDto.ToString());
    }


    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public string? PasswordHash { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string PriceLabel { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }


    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // User->UserDto
            config.NewConfig<User, UserDto>()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");

            // Product -> ProductDto
            config.NewConfig<Product, ProductDto>()
                .Map(dest => dest.DisplayName, src => src.Name.ToUpper())
                .Map(dest => dest.PriceLabel, src => $"${src.Price:F2}")
                .IgnoreNonMapped(true);
        }
    }
}