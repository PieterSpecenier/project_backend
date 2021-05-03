using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using project_backend_dev.Models;
using Volleybal.Test;

namespace project_backend
{
    public class VolleybalControllerTest : IClassFixture<CustomApiWebApplicationFactory>
    {
        public HttpClient Client { get; set;}

        public VolleybalControllerTest(CustomApiWebApplicationFactory fixture)
        {
            Client = fixture.CreateClient();
        }
        [Fact]
        public async Task GetTeams()
        {
            var response = await Client.GetAsync("/api/teams");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var brands = JsonConvert.DeserializeObject<List<Team>>(await response.Content.ReadAsStringAsync());
            Assert.True(brands.Count > 0);
        }
        [Fact]
        public async Task GetMatches()
        {
            var response = await Client.GetAsync("/api/matches");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var occasions = JsonConvert.DeserializeObject<List<Match>>(await response.Content.ReadAsStringAsync());
            Assert.True(occasions.Count > 0);
        }
        [Fact]
        public async Task GetPlayers()
        {
            var response = await Client.GetAsync("/api/players");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var sneakers = JsonConvert.DeserializeObject<List<Player>>(await response.Content.ReadAsStringAsync());
            Assert.True(sneakers.Count > 0);
        }  
        [Fact]
        public async Task AddPlayer()
        {
            var player = new Player(){
                PlayerId = 1,
                FirstName = "Pieter",
                LastName = "Specenier"
            };

            string json = JsonConvert.SerializeObject(player);
            var response = await Client.PostAsync("/api/player", new StringContent(json,Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var addedPlayer = JsonConvert.DeserializeObject<Player>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(addedPlayer);
            Assert.Equal<string>("Test player",addedPlayer.FirstName);
        }
    }
}
