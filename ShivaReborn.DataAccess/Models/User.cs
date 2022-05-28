using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ShivaReborn.DataAccess.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [ForeignKey("Place")] string AssignedPlaceId { get; set; }
    private bool IsAdmin { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}