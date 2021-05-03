using System;

namespace project_backend_dev.Models
{
    public class MatchTeams
    {
        public int TeamId { get; set; }
        public Guid MatchId { get; set; }
        public Team Team { get; set; }
    }
}
