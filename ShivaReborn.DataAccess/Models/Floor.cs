using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.DataAccess.Models;

public class Floor : BaseEntity
{
    public string name { get; set; }
    [ForeignKey("Building")] public string buildingId { get; set; }

}