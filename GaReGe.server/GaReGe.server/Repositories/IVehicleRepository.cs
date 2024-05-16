using GaReGe.server.Dto;

namespace GaReGe.server.Repositories;

public interface IVehicleRepository
{
    Task<ICollection<VehicleDto>> GetAllVehicles();
}