using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_backend_dev.DataContext;
using project_backend_dev.Models;
namespace project_backend_dev.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> AddTeam(Team team);
        Task<Team> GetTeam(int teamId);
        Task<List<Team>> GetTeams();
    }

    public class TeamRepository : ITeamRepository
    {
        private IVolleybalContext _context;

        public TeamRepository(IVolleybalContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Team.Include(s => s.Name).Include(s => s.FoundingYear).ToListAsync();
        }

        public async Task<Team> AddTeam(Team team)
        {
            await _context.Team.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> GetTeam(int teamId)
        {
            return await _context.Team.Where(s => s.TeamId == teamId)
            .Include(s => s.Name).SingleOrDefaultAsync();
        }
    }
}
