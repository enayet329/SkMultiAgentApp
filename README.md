# Job Assistant Multi-Agent System

This project is a .NET 9 console application that demonstrates a multi-agent system for job assistance using Microsoft Semantic Kernel and OpenAI. It orchestrates several specialized agents to help users with resume parsing, job matching, career advice, and interview coaching.

## Features
- **Multi-Agent Orchestration:** Combines Resume Parser, Job Matcher, Career Advisor, and Interview Coach agents.
- **Semantic Kernel Integration:** Uses Microsoft Semantic Kernel for agent orchestration and chat completion.
- **OpenAI/OpenRouter Support:** Connects to OpenRouter for LLM-powered chat and reasoning.
- **Plugin Architecture:** Extensible via plugins (see `JobAssistantPlugin`).
- **Sample Resume:** Includes a sample resume for demonstration and testing.

## Getting Started
1. **Requirements:**
   - .NET 9 SDK
   - Internet connection (for OpenAI/OpenRouter API)
2. **Setup:**
   - Clone the repository.
   - Restore NuGet packages.
   - Build the solution.
3. **Run:**
   - Execute the console application. The main entry point is in `Program.cs`.
   - The system will process a sample job query and display agent responses.

## Main Components
- `JobAssistantSystem.cs`: Core orchestration logic for agents and chat.
- `Program.cs`: Application entry point.
- `Resume.cs`: Contains a sample resume for agent processing.
- `Agent/`: Contains agent implementations (ResumeParserAgent, JobMatcherAgent, etc).
- `Plugins/`: Contains plugins for extending agent capabilities.

## Dependencies
- [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel)
- [Microsoft.SemanticKernel.Agents.Core](https://www.nuget.org/packages/Microsoft.SemanticKernel.Agents.Core)
- [Microsoft.SemanticKernel.Connectors.OpenAI](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.OpenAI)

## Example Usage
```
My name is hamed fathi and I am looking for a senior .NET developer job.
```
The system will:
- Parse the resume
- Match jobs
- Advise on career
- Coach for interviews

## Customization
- Update `Resume.cs` with your own resume.
- Modify or extend agents in the `Agent/` directory.
- Add plugins in the `Plugins/` directory.

## License
This project is for demonstration purposes. Please review dependencies for their respective licenses.
