﻿using GaReGe.server.Data;
using GaReGe.server.Dto;
using GaReGe.server.Entity;
using Microsoft.EntityFrameworkCore;

namespace GaReGe.server.Repositories;
public class VehicleRepository : IVehicleRepository
{


    private readonly GaregeDbContext _context;

    public VehicleRepository(GaregeDbContext context) {
        _context = context;
    }


    public async Task<ICollection<VehicleDto>> GetAllVehicles() {
        return await _context.Vehicles.Select(v => VehicleToVehicleDto(v)).ToListAsync();
    }



    private static VehicleDto VehicleToVehicleDto(Vehicle vehicle) {
        return new VehicleDto(
            VehicleId: vehicle.VehicleId,
            LicensePlate: vehicle.LicensePlate,
            Color: vehicle.Color,
            Brand: vehicle.Brand,
            Model: vehicle.Model,
            NumWheels: vehicle.NumWheels,
            MemberId: vehicle.MemberId,
            VehicleTypeId: vehicle.VehicleTypeId,
            VehicleTypeName: vehicle.VehicleType.Name
        );
    }


}