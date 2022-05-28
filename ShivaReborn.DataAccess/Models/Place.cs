using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ShivaReborn.DataAccess.Models;

public class Place
{
    public string id { get; set; }
    public string name { get; set; }
    public bool isAssigned { get; set; }
    [ForeignKey("User")]
    public User assignedUser { get; set; }
}