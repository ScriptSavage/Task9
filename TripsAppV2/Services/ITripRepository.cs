using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsAppV2.Models;

namespace TripsAppV2.Repositories;

public interface ITripRepository
{

    Task<ICollection<Trip>> GetAlltrips();


    Task<bool> DoesClientHasATrips(int id);

    Task<bool> CheckIfClintWithGivenpeselExists(string pesel);


}