using FluentValidation;

namespace Application.DrinkLines.Queries.GetRangeOfDrinkLines;

public class GetRangeOfDrinkLinesQueryValidator : AbstractValidator<GetRangeOfDrinkLinesQuery>
{
    public GetRangeOfDrinkLinesQueryValidator()
    {
        RuleFor(x => x.Page).Must(page => page > 0);

        RuleFor(x => x.Limit).Must(limit => limit > 0 && limit <= 25);
    }
}
