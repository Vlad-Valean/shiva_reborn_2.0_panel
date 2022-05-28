using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;

public class Building : BaseEntity
{
    public string country { get; set; }
    public string city { get; set; }
    [JsonIgnore] public Floor[] floors { get; set; }
}