using Microsoft.AspNetCore.Identity;
namespace ShivaReborn.DataAccess.Models;
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Building? Building { get; set; }
    public Place? AssignedPlace { get; set; }
    private bool IsAdmin { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
}