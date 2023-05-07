using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.SharedModels;

namespace OpenAI.Exploration.Services;

public class OpenAiClient
{
    private readonly IOpenAIService _openAiService;

    public OpenAiClient(IOpenAIService openAiService)
    {
        _openAiService = openAiService;
    }

    public async Task<List<ChatChoiceResponse>> RunAPrompt()
    {
        var result = "";
        //TODO: Calculate user bounce before sending request
        var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = new List<ChatMessage>
            {
                ChatMessage.FromUser("Create an activity that will be used during a group counseling session for patients struggling with the guilt and shame associated with their Drug and/or Alcohol addiction and recovery."),
                ChatMessage.FromUser("This activity should include talking points to encourage group members to share their experiences."),
                ChatMessage.FromUser("I would like this activity to recommend a short video clip on the topic from YouTube that could be shared with the group."),
                ChatMessage.FromUser("Please provide a handout to be provided to group members."),
                ChatMessage.FromUser("Include sources for all found materials.")
            },
            Model = Models.ChatGpt3_5Turbo,
        });
        if (completionResult.Successful)
        {
            result = completionResult.Choices.First().Message.Content;
        }
        
        return completionResult.Choices;
    }
}