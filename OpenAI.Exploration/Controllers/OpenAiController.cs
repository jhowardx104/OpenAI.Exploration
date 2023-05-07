using Microsoft.AspNetCore.Mvc;
using OpenAI.Exploration.Services;
using OpenAI.GPT3.ObjectModels.SharedModels;

namespace OpenAI.Exploration.Controllers;

[ApiController]
[Route("api/open-ai")]
public class OpenAiController : Controller
{
    private readonly OpenAiClient _openAiClient;

    public OpenAiController(OpenAiClient openAiClient)
    {
        _openAiClient = openAiClient;
    }
    [HttpGet("zelda/dungeon")]
    public async Task<string> GetZeldaDungeons()
    {
        var result = await _openAiClient.RunAPrompt();
        return result.First().Message.Content;
    }
}