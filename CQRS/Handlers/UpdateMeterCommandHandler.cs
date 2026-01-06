using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WattWise.CQRS.Commands;
using WattWise.Data;
using WattWise.Models;

namespace WattWise.CQRS.Handlers
{
    public class UpdateMeterCommandHandler : IRequestHandler<UpdateMeterCommand, bool>
    {
        private readonly ApplicationDBContext _db;

        public UpdateMeterCommandHandler(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateMeterCommand request, CancellationToken cancellationToken)
        {
            var meter = request.Meter;
            var exists = await _db.Meter.AnyAsync(m => m.MeterId == meter.MeterId, cancellationToken);
            if (!exists) return false;

            _db.Entry(meter).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
