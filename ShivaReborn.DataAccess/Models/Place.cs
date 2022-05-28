using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ShivaReborn.DataAccess.Models;

public class Place : BaseEntity
{
    public string name { get; set; }
    public bool isAssigned { get; set; }
    [ForeignKey("Floor")]public string floorId { get; set; }
}