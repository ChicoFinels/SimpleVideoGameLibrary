﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleVideoGameLibrary.Shared;

namespace SimpleVideoGameLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames()
        {
            var videoGames = new List<VideoGame>()
            {
                new VideoGame { Id = 1, Name ="Tetris", Publisher = "Nintendo", ReleaseYear = 1989},
                new VideoGame { Id = 2, Name ="Pong", Publisher = "Atari", ReleaseYear = 1972}
            };

            return Ok(videoGames);
        }
    }
}