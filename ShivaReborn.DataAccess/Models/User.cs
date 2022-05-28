using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;

public class User : BaseEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    [ForeignKey("Place")] public string assignedPlaceId { get; set; }
    public bool isAdmin { get; set; }
}