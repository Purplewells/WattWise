using MediatR;
using WattWise.CQRS.DTOs;

namespace WattWise.CQRS.Queries
{
    public record GetMeterByIdQuery(int Id) : IRequest<MeterDto?>;
}
