using MediatR;
using WattWise.Models;

namespace WattWise.CQRS.Commands
{
    public record UpdateMeterCommand(Meter Meter) : IRequest<bool>;
}
