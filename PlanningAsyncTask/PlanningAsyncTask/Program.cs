using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using PlanningAsyncTask.Helper;
using PlanningAsyncTask.Plugins;

namespace PlanningAsyncTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //自定义HttpClientHandler，重定向OpenAI url为国内大模型
            var config = ConfigExtensions.FromConfig<OpenAIConfig>("OneApiDeepSeek");
            var openAICustomHandler = new OpenAICustomHandler(config.Endpoint);
            using HttpClient client = new(openAICustomHandler);

            //Create Kernel
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: config.ModelId,
                    apiKey: config.ApiKey,
                    httpClient: client);

            // add Plugins
            builder.Plugins.AddFromType<NewsPlugin>();
            builder.Plugins.AddFromType<TimePlugin>();

            var kernel = builder.Build();

            var chatService = kernel.GetRequiredService<IChatCompletionService>();

            ChatHistory chatHistory = [];

            //Chat task service
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("User>>");
                var userMessage = Console.ReadLine();

                chatHistory.AddUserMessage(userMessage);

                var response =
                    chatService.GetStreamingChatMessageContentsAsync(
                        chatHistory,
                        executionSettings: new OpenAIPromptExecutionSettings()
                        {
                            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
                        },
                        kernel: kernel);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("AI Response>>");

                string fullMessage = "";

                await foreach (var chat in response)
                {
                    Console.Write(chat);
                    fullMessage += chat;
                }
                chatHistory.AddAssistantMessage(fullMessage);

                Console.WriteLine("\n");
            }
        }
    }
}