using FluentValidation;

namespace Application.DrinkLines.Commands.AddDrinkLineImage;

public class AddDrinkLineImageCommandValidator : AbstractValidator<AddDrinkLineImageCommand>
{
    public AddDrinkLineImageCommandValidator()
    {
        RuleFor(x => x.HostUrl).NotNull().NotEmpty();

        RuleFor(x => x.Image)
            .Must(image =>
                image.ContentType == "image/jpeg"
                || image.ContentType == "image/pjpeg"
                || image.ContentType == "image/png"
                || image.ContentType == "image/svg+xml"
                || image.ContentType == "image/webp"
            )
            .WithMessage("Неподдерживаемый тип изображения");

        RuleFor(x => x.DrinkLineId.Value).NotNull().NotEmpty();
    }
}
