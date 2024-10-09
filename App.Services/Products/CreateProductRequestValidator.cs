using FluentValidation;

namespace App.Services.Products;
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {

        // NotNull validasyonu integer bir value için çalışmaz.

        RuleFor(x => x.Name).NotNull().
            WithMessage("Product name is required.").
            NotEmpty().WithMessage("Product name is required.")
            .Length(3, 10).WithMessage("Product name must be between the length 3 and 10.");

        RuleFor(x => x.Price).GreaterThan(0).
         WithMessage("Product price must be larger than 0.");

        RuleFor(x => x.Stock)
            .InclusiveBetween(1, 100).WithMessage("Stock quantity must be between 1,100");
    }
}
