using MediatR;

namespace WattWise.CQRS.Commands
{
    public record DeleteMeterCommand(int Id) : IRequest<bool>;
}
