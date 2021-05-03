using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project_backend_dev.DTO;
using project_backend_dev.Models;
using project_backend_dev.Services;

namespace project_backend_dev.Controllers
{
    [ApiController]
    [Route("api")]
    public class VolleybalController : ControllerBase
    {
 
        private readonly IVolleybalService _volleybalService;
        private readonly ILogger<VolleybalController> _logger;

        public VolleybalController(ILogger<VolleybalController> logger,IVolleybalService volleybalService)
        {
            _logger = logger;
            _volleybalService = volleybalService;
        }

        [HttpGet]
        [Route("matches")]
        public async Task<ActionResult<List<MatchDTO>>> Getmatches()
        {
            try{
                return new OkObjectResult(await _volleybalService.GetMatchDTOs());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("players")]
        public async Task<ActionResult<List<PlayerDTO>>> GetPlayers()
        {
            try{
                return new OkObjectResult(await _volleybalService.GetPlayerDTOs());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("teams")]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            try{
                return new OkObjectResult(await _volleybalService.GetTeams());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("teams/{teamId}")]
        public async Task<ActionResult<Team>> GetSneaker(int teamId)
        {
            try{
                return new OkObjectResult(await _volleybalService.GetTeam(teamId));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("player")]
        public async Task<ActionResult<Player>> AddPlayer(Player player)
        {
            try{
                return new OkObjectResult(await _volleybalService.AddPlayer(player));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }
    }
}
