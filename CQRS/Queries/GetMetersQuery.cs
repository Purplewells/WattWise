using System.Collections.Generic;
using MediatR;
using WattWise.CQRS.DTOs;

namespace WattWise.CQRS.Queries
{
    public record GetMetersQuery() : IRequest<List<MeterDto>>;
}
