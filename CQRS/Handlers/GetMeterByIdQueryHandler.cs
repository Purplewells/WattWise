using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WattWise.CQRS.Queries;
using WattWise.CQRS.DTOs;
using WattWise.Data;

namespace WattWise.CQRS.Handlers
{
    public class GetMeterByIdQueryHandler : IRequestHandler<GetMeterByIdQuery, MeterDto?>
    {
        private readonly ApplicationDBContext _db;

        public GetMeterByIdQueryHandler(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<MeterDto?> Handle(GetMeterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.Meter
                .AsNoTracking()
                .Where(m => m.MeterId == request.Id)
                .Select(m => new MeterDto
                {
                    MeterId = m.MeterId,
                    SerialNumber = m.SerialNumber,
                    Description = m.Description,
                    Location = m.Location,
                    Latitude = m.Latitude,
                    Longitude = m.Longitude,
                    InstallationDate = m.InstallationDate,
                    LastMaintenanceDate = m.LastMaintenanceDate,
                    CurrentReading = m.CurrentReading,
                    PreviousReading = m.PreviousReading,
                    CreditLimit = m.CreditLimit,
                    TarriffRate = m.TarriffRate,
                    CurrentBalance = m.CurrentBalance,
                    Manufacturer = m.Manufacturer,
                    Model = m.Model,
                    FirmwareVersion = m.FirmwareVersion,
                    HardwareVersion = m.HardwareVersion,
                    UserId = m.UserId,
                    TamperStatusID = m.TamperStatusID,
                    MeterTypeID = m.MeterTypeID,
                    MeterStatusID = m.MeterStatusID,
                    TamperStatusName = m.TamperStatus != null ? m.TamperStatus.TamperStatusName : null,
                    MeterTypeName = m.MeterType != null ? m.MeterType.MeterTypeName : null,
                    MeterStatusName = m.MeterStatus != null ? m.MeterStatus.Status : null,
                    OwnerName = m.ApplicationUser != null ? (m.ApplicationUser.FirstName + " " + m.ApplicationUser.LastName) : null,
                    LastReadingAt = m.MeterReading.OrderByDescending(r => r.ReadingDate).Select(r => (DateTime?)r.ReadingDate).FirstOrDefault(),
                    IsActive = m.MeterStatus != null && m.MeterStatus.Status == "Active",
                    LastCommunication = null
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
