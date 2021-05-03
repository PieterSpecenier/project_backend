using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_backend_dev.DataContext;
using project_backend_dev.Models;

namespace project_backend_dev.Repositories
{
    public interface IMatchRepository
    {
        Task<List<Match>> GetMatches();
    }

    public class MatchRepository : IMatchRepository
    {
        private IVolleybalContext _context;

        public MatchRepository(IVolleybalContext context)
        {
            _context = context;
        }

        public async Task<List<Match>> GetMatches()
        {
            return await _context.Match.ToListAsync();
        }
    }
}
