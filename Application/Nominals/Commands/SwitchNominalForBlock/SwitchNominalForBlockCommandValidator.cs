using FluentValidation;

namespace Application.Nominals.Commands.SwitchNominalForBlock;

public class SwitchNominalForBlockCommandValidator : AbstractValidator<SwitchNominalForBlockCommand>
{
    public SwitchNominalForBlockCommandValidator()
    {
        RuleFor(x => x.NominalId.Value).Must(nominalId => nominalId > 0);
    }
}
