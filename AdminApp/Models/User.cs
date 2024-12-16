using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace AdminApp.Models
{
    // Represents a User fetched from the backend
    public class User
    {
        public string Id { get; set; } // Unique ID from the database
        public string Email { get; set; } // User's email address
    }
}
