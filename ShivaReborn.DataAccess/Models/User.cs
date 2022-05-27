namespace ShivaReborn.DataAccess.Models;
public class User
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public Building building { get; set; }
    public Place assignedPlace { get; set; }
    private bool isAdmin { get; set; }
}