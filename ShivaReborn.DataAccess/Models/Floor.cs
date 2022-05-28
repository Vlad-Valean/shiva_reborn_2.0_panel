using System.Text.Json.Serialization;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.DataAccess.Models;

public class Floor : BaseEntity
{
    public string name { get; set; }
    [JsonIgnore] public Place[]? places{get;set;}

}