using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WattWise.CQRS.Commands;
using WattWise.Data;
using WattWise.Models;

namespace WattWise.CQRS.Handlers
{
    public class CreateMeterCommandHandler : IRequestHandler<CreateMeterCommand, int>
    {
        private readonly ApplicationDBContext _db;

        public CreateMeterCommandHandler(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateMeterCommand request, CancellationToken cancellationToken)
        {
            var meter = request.Meter;
            _db.Meter.Add(meter);
            await _db.SaveChangesAsync(cancellationToken);
            return meter.MeterId;
        }
    }
}
