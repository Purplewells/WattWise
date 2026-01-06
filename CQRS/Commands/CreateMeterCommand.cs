using MediatR;
using WattWise.Models;

namespace WattWise.CQRS.Commands
{
    public record CreateMeterCommand(Meter Meter) : IRequest<int>;
}
