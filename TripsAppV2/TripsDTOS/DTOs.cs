using TripsAppV2.Models;

namespace TripsAppV2;

public class DTOs
{
    public int IdTrip { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public ICollection<CoutryDtos> CoutryDtosCollection { get; set; } = new HashSet<CoutryDtos>();
  
    public List<ClientDto> ClientsDtOsCollection { get; set; } = new List<ClientDto>();

}


public class CoutryDtos
{
    public string Name { get; set; } = null!;
}


public class ClientsDTOs
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
