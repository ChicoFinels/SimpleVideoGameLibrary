using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleVideoGameLibrary.Server.Data;
using SimpleVideoGameLibrary.Shared;

namespace SimpleVideoGameLibrary.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideoGameController : ControllerBase
	{
		private readonly DataContext _context;

		public VideoGameController(DataContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames()
		{
			var videoGames = await _context.VideoGames.OrderBy(g => g.ReleaseYear).ToListAsync();

			return Ok(videoGames);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
		{
			var dbGame = await _context.VideoGames.FindAsync(id);
			if (dbGame == null)
			{
				return NotFound("This video game doesn't exist!");
			}

			return Ok(dbGame);
		}

		[HttpPost]
		public async Task<ActionResult<List<VideoGame>>> CreateVideoGame(VideoGame game)
		{
			_context.VideoGames.Add(game);
			await _context.SaveChangesAsync();

			return await GetAllVideoGames();
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<List<VideoGame>>> UpdateVideoGame(int id, VideoGame game)
		{
			var dbGame = await _context.VideoGames.FindAsync(id);
			if (dbGame == null)
			{
				return NotFound("This video game doesn't exist!");
			}

			dbGame.Name = game.Name;
			dbGame.Publisher = game.Publisher;
			dbGame.ReleaseYear = game.ReleaseYear;

			await _context.SaveChangesAsync();

			return await GetAllVideoGames();
		}
	}
}
