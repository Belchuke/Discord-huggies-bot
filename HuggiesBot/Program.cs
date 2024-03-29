using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using HuggiesBot.commands;
using HuggiesBot.Config;
using HuggiesBot.Huggies;

internal class Program
{
    private static DiscordClient _client { get; set; }

    private static CommandsNextExtension _commands { get; set; }

    private static async Task Main()
    {

        var configJsonFile = new JSONReader();
        await configJsonFile.ReadJSON();

        DiscordConfiguration discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = configJsonFile.token,
            TokenType = TokenType.Bot,
            AutoReconnect = true
        };

        _client = new DiscordClient(discordConfig);

        _client.Ready += OnClientReady;

        CommandsNextConfiguration commandsConfig = new CommandsNextConfiguration()
        {
            StringPrefixes = new string[] { configJsonFile.prefix },
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = false,
        };


        _commands = _client.UseCommandsNext(commandsConfig);
        _commands.RegisterCommands<TestCommand>();

        await _client.ConnectAsync();
        await Task.Delay(-1);
    }


    private static Task OnClientReady(DiscordClient sender, ReadyEventArgs args)
    {
        return Task.CompletedTask;
    }
}