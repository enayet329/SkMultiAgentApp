// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//builder.AddOpenAIChatCompletion(
//	modelId: "openai/gpt-3.5-turbo",                            // deepseek/deepseek-r1-0528:free // deepseek/deepseek-chat-v3-0324:free // qwen/qwen3-235b-a22b-2507:free  // deepseek/deepseek-r1:free  // openai/gpt-3.5-turbo
//	apiKey: "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",
//	endpoint: new Uri("https://openrouter.ai/api/v1")
//);


using SkMultiAgentApp;
using System.Diagnostics.CodeAnalysis;

internal class Program
{
	[Experimental("SKEXP0110")]
	static async Task Main(string[] args)
	{
		var query = "My name is hamed fathi and I am looking for a senior .NET developer job.";

		var jobAssistantSystem = new JobAssistantSystem();
		await jobAssistantSystem.RunAsync(query);

		Console.WriteLine("\nJob assistance process complete!");
		Console.ReadLine();
	}
}