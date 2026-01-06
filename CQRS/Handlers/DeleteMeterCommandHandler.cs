using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WattWise.CQRS.Commands;
using WattWise.Data;

namespace WattWise.CQRS.Handlers
{
    public class DeleteMeterCommandHandler : IRequestHandler<DeleteMeterCommand, bool>
    {
        private readonly ApplicationDBContext _db;

        public DeleteMeterCommandHandler(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteMeterCommand request, CancellationToken cancellationToken)
        {
            var meter = await _db.Meter.FindAsync(new object[] { request.Id }, cancellationToken: cancellationToken);
            if (meter == null) return false;
            _db.Meter.Remove(meter);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
