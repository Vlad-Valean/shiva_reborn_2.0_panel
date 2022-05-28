using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;

public class Floor : BaseEntity
{
    public string Name;
    [JsonIgnore] public Place[] places { get; set; }
}