using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel;
using SkMultiAgentApp.Agent;
using SkMultiAgentApp.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI;
using System.Diagnostics.CodeAnalysis;
using System.ClientModel;

namespace SkMultiAgentApp
{
	[Experimental("SKEXP0110")]
	public class JobAssistantSystem
	{
		private readonly Kernel _kernel;
		private readonly AgentGroupChat _chat;

		public JobAssistantSystem()
		{
			_kernel = CreateKernel();
			_chat = CreateAgentGroupChat();
		}

		private Kernel CreateKernel()
		{
			var builder = Kernel.CreateBuilder();

			// Correct OpenAIClient initialization for OpenRouter
			var openAIClient = new OpenAIClient(new ApiKeyCredential("your-apikey"), new OpenAIClientOptions { Endpoint = new Uri("https://openrouter.ai/api/v1") });
			builder.AddOpenAIChatCompletion("openai/gpt-3.5-turbo", openAIClient);

			builder.Plugins.AddFromType<JobAssistantPlugin>();

			return builder.Build();
		}

		public async Task RunAsync(string initialUserMessage)
		{
			Console.WriteLine("Job Assistant Multi-Agent System");
			Console.WriteLine("--------------------------------");

			_chat.AddChatMessage(new ChatMessageContent(AuthorRole.User, initialUserMessage));

			await foreach (var content in _chat.InvokeAsync())
			{
				if (!string.IsNullOrWhiteSpace(content.Content))
				{
					Console.WriteLine($"# {content.Role} - {content.AuthorName ?? "*"}: '{content.Content}'");
					Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
				}
			}

			Console.WriteLine($"# IS COMPLETE: {_chat.IsComplete}");
		}

		private AgentGroupChat CreateAgentGroupChat()
		{
			var resumeParserAgent = new ResumeParserAgent(_kernel);
			var jobMatcherAgent = new JobMatcherAgent(_kernel);
			var careerAdvisorAgent = new CareerAdvisorAgent(_kernel);
			var interviewCoachAgent = new InterviewCoachAgent(_kernel);

			var resumeParser = resumeParserAgent.Create();
			var jobMatcher = jobMatcherAgent.Create();
			var careerAdvisor = careerAdvisorAgent.Create();
			var interviewCoach = interviewCoachAgent.Create();

			var chatOrchestrator = new AgentGroupOrchestrator(_kernel);

			return new AgentGroupChat(resumeParser, jobMatcher, careerAdvisor, interviewCoach)
			{
				ExecutionSettings = chatOrchestrator.CreateExecutionSettings([interviewCoach])
			};
		}
	}
}