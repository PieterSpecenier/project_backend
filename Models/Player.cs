using System;

namespace project_backend_dev.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int TeamId { get; set; }
    }
}
