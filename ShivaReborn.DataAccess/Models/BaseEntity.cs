using Microsoft.AspNetCore.Identity;

namespace ShivaReborn.DataAccess.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
}