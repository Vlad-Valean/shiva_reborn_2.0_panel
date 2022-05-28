namespace ShivaReborn.DataAccess.Models;

public class Building
{
    public string id { get; set; }
    public string country { get; set; }
    public string city { get; set; }
    public Floor[] floors { get; set; }
}