using System.Net.Http.Json;
using HackerNewsAPI.Models;

namespace HackerNewsAPI.Services;

public class HackerNewsService
{
    private readonly HttpClient _httpClient;

    public HackerNewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para obtener los IDs de las mejores historias
    public async Task<List<int>> GetBestStoryIdsAsync()
    {
        var storyIds = await _httpClient.GetFromJsonAsync<List<int>>("https://hacker-news.firebaseio.com/v0/beststories.json");
        return storyIds ?? new List<int>();
    }

    // Método para obtener los detalles de una historia por su ID
    public async Task<HackerNewsStory?> GetStoryDetailsAsync(int storyId)
    {
        return await _httpClient.GetFromJsonAsync<HackerNewsStory>($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
    }

    // Método para obtener las mejores n historias
    public async Task<IEnumerable<HackerNewsStory>> GetTopStoriesAsync(int n)
    {
        var storyIds = await GetBestStoryIdsAsync();
        var tasks = storyIds.Take(n).Select(GetStoryDetailsAsync);
        var stories = await Task.WhenAll(tasks);
        return stories.Where(s => s != null).OrderByDescending(s => s.Score)!;
    }
}