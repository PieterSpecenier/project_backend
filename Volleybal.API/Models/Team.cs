using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace project_backend_dev.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public String Name { get; set; }
        public int FoundingYear { get; set; }
        [JsonIgnore]
        public List<MatchTeams> MatchTeams { get; set; }
    }
}
