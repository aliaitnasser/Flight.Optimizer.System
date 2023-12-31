﻿using Flight.Optimizer.API.Data;
using Flight.Optimizer.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.Optimizer.API.Repository;

public class PassengerRepository: IPassengerRepository
{
    private readonly DataContext _context;

    public PassengerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Passenger>> GetAllPassengersAsync()
    {
        return await _context.Passengers.ToListAsync();
    }
}
