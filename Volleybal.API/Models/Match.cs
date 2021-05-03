using System;
using System.Collections.Generic;

namespace project_backend_dev.Models
{
    public class Match
    {
        public Guid MatchId { get; set; }
        public String Result { get; set; }
        public List<MatchTeams> MatchTeams { get; set; }
        
    }
}
