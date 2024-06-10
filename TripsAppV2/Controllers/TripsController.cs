using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsAppV2.Context;
using TripsAppV2.Models;
using TripsAppV2.Repositories;

namespace TripsAppV2.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TripsController : ControllerBase
{


    private readonly ITripRepository _context;

    public TripsController(ITripRepository context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllclients()
    {
        var x = await _context.GetAlltrips();

        return Ok(x.Select(e => new DTOs()
        {
            Name = e.Name,
            Description = e.Description,
            DateFrom = e.DateFrom,
            DateTo = e.DateTo,
            MaxPeople = e.MaxPeople,
            CoutryDtosCollection = e.IdCountries.Select(e=> new CoutryDtos()
            {
                Name = e.Name
                
            }).ToList(),
            ClientsDtOsCollection = e.ClientTrips.Select(e=> new ClientDto()
            {
                FirstName = e.IdClientNavigation.FirstName,
                LastName = e.IdClientNavigation.LastName
            }).ToList()
        }).ToList());
        
        
    }



    [HttpDelete]
    public async Task<IActionResult> DeleteClient(int id)
    {

        var res = await _context.DoesClientHasATrips(id);

        if (res)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
        else
        {
            return Ok();
        }
    }



    [HttpPost]
    public async Task<IActionResult> AssignClientToTrip(NewTripDTOs newTripDtOs)
    {

        var x =await _context.CheckIfClintWithGivenpeselExists(newTripDtOs.Pesel);

        if (!x)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }


        return Ok();
    }







}