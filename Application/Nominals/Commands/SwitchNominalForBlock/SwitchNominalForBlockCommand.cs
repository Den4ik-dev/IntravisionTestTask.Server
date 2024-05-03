using Domain.Nominal.ValueObject;
using FluentResults;
using MediatR;

namespace Application.Nominals.Commands.SwitchNominalForBlock;

public record SwitchNominalForBlockCommand(NominalId NominalId) : IRequest<Result>;
