using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;

public class Floor : BaseEntity
{
    public string name;
    [JsonIgnore] public Place[] places { get; set; }
}