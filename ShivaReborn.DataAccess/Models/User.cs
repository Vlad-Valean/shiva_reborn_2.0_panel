<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShivaReborn.DataAccess.Models;

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
}