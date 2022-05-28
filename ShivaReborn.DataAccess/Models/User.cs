<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ShivaReborn.DataAccess.Models;

<<<<<<< HEAD
=======
﻿using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;
>>>>>>> parent of 41b9311... login done
public class User : BaseEntity
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
<<<<<<< HEAD
    [ForeignKey("Place")] string assignedPlaceId { get; set; }
=======
    public Building? building { get; set; }
    public Place? assignedPlace { get; set; }
>>>>>>> parent of 41b9311... login done
    private bool isAdmin { get; set; }
=======
public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [ForeignKey("Place")] string AssignedPlaceId { get; set; }
    private bool IsAdmin { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
>>>>>>> basePanel
}