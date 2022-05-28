using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;

public class Building : BaseEntity
{
    public string? country { get; set; }
    public string? city{ get; set; }
    
}