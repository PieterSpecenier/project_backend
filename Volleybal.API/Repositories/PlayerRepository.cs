using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_backend_dev.DataContext;
using project_backend_dev.Models;

namespace project_backend_dev.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> AddPlayer(Player player);
        Task<List<Player>> GetPlayers();
    }

    public class PlayerRepository : IPlayerRepository
    {
        private IVolleybalContext _context;

        public PlayerRepository(IVolleybalContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayers()
        {
            try
            {
                return await _context.Player.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
        public async Task<Player> AddPlayer(Player player)
        {
            await _context.Player.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        // public async Task<Player> GetPlayer(int playerId)
        // {
        //         return await _context.Player.Where(o => o.PlayerId == playerId).SingleOrDefaultAsync();
        // }
    }
}
