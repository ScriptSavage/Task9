using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsAppV2.Context;
using TripsAppV2.Models;

namespace TripsAppV2.Repositories;

public class TripsRepository : ITripRepository
{

    private readonly TripsContext _context;

    public TripsRepository(TripsContext context)
    {
        _context = context;
    }




    public async Task<ICollection<Trip>> GetAlltrips()
    {

        var x =await _context.Trips
            .Include(e => e.ClientTrips)
            .ThenInclude(e => e.IdClientNavigation)
            .Include(e => e.IdCountries)
            .ThenInclude(e => e.IdTrips).ToListAsync();



        return x;
    }

    public async Task<bool> DoesClientHasATrips(int id)
    {

        var x = await _context.ClientTrips.AnyAsync(e => e.IdClient == id);
        
        return x;
    }

    public Task<bool> CheckIfClintWithGivenpeselExists(string pesel)
    {

        var x = _context.Clients.AnyAsync(e => e.Pesel == pesel);
        
        throw new NotImplementedException();
    }
}