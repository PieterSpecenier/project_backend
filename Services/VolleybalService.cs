using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using project_backend_dev.DataContext;
using project_backend_dev.DTO;
using project_backend_dev.Models;
using project_backend_dev.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace project_backend_dev.Services
{
    public interface IVolleybalService
    {
        Task<Player> AddPlayer(Player player);
        Task<List<MatchDTO>> GetMatchDTOs();
        Task<List<PlayerDTO>> GetPlayerDTOs();
        Task<Team> GetTeam(int teamId);
        Task<List<Team>> GetTeams();
    }

    public class VolleybalService : IVolleybalService
    {
        private IMatchRepository _matchRepository;
        private IPlayerRepository _playerRepository;
        private ITeamRepository _teamRepository;
        private IMapper _mapper;

        public VolleybalService(IMapper mapper, IMatchRepository matchRepository, IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Team> GetTeam(int teamId)
        {
            try
            {
                return await _teamRepository.GetTeam(teamId);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _teamRepository.GetTeams();
        }



        public async Task<List<PlayerDTO>> GetPlayerDTOs()
        {
            return _mapper.Map<List<PlayerDTO>>(await _playerRepository.GetPlayers());
        }

        public async Task<List<MatchDTO>> GetMatchDTOs()
        {
            return _mapper.Map<List<MatchDTO>>(await _matchRepository.GetMatches());
        }
        public async Task<Player> AddPlayer(Player player)
        {
            var newPlayer = await _playerRepository.AddPlayer(player);
            return newPlayer;
        }
    }
}
