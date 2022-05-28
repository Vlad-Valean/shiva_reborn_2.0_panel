using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ShivaReborn.DataAccess.Models;

public class  User : BaseEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    [ForeignKey("Place")]
    public string assignedPlaceId { get; set; }
    
    public bool isAdmin { get; set; }
}