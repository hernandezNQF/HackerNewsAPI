using HackerNewsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HackerNewsController : ControllerBase
{
    private readonly HackerNewsService _hackerNewsService;

    public HackerNewsController(HackerNewsService hackerNewsService)
    {
        _hackerNewsService = hackerNewsService;
    }

    [HttpGet("beststories")]
    public async Task<IActionResult> GetBestStories([FromQuery] int n = 10)
    {
        try
        {
            var stories = await _hackerNewsService.GetTopStoriesAsync(n);

            var response = stories.Select(s => new
            {
                s.Title,
                Uri = s.Url,
                PostedBy = s.By,
                Time = DateTimeOffset.FromUnixTimeSeconds(s.Time).ToString("o"),
                s.Score,
                CommentCount = s.Descendants
            });

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}