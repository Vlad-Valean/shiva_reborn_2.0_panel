namespace ShivaReborn.DataAccess.Models;

public class Place
{
    public string name { get; set; }
    public bool isAssigned { get; set; }
    public User assignedUser { get; set; }
}