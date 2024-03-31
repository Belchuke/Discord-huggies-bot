using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using HuggiesBot.Huggies;
using HuggiesBot.Kisses;

namespace HuggiesBot.commands
{
    public class TestCommand : BaseCommandModule
    {

        [Command("hug")]
        public async Task SendHuggies(CommandContext ctx, DiscordMember member)
        {
            try
            {
                HuggiesReader huggeis = new HuggiesReader();
                string gif = await huggeis.GetHugGif();

                string nickname = ctx.Member.Nickname ?? ctx.Member.Username;

                string memberNickname = member.Nickname ?? member.Username;

                var embed = new DiscordEmbedBuilder
                {
                    Title = $"{memberNickname}, you have been hugged by {nickname}!",
                    Color = DiscordColor.Purple,
                    ImageUrl = gif,
                };

                embed.Build();
                await ctx.Channel.SendMessageAsync(embed: embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await ctx.Channel.SendMessageAsync("There was an error while trying to send a huggie!");
            }
        }

        [Command("count-hug")]
        public async Task HuggiesCount(CommandContext ctx)
        {
            HuggiesReader huggeis = new HuggiesReader();
            int count = await huggeis.HuggiesCount();

            await ctx.Channel.SendMessageAsync($"There are {count} huggies in the database!");
        }

        [Command("add-hug")]
        public async Task AddHuggies(CommandContext ctx, string url)
        {
            try
            {
                HuggiesReader huggeis = new HuggiesReader();
                await huggeis.AddHugGif(url);

                await ctx.Channel.SendMessageAsync("Huggie has been added to the database! UwU");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await ctx.Channel.SendMessageAsync("There was an error while trying to add a huggie!");
            }
        }

        [Command("kiss")]
        public async Task SendKisses(CommandContext ctx, DiscordMember member)
        {
            try
            {
                KissREeader kisses = new KissREeader();
                string gif = await kisses.GetKissGif();

                string nickname = ctx.Member.Nickname ?? ctx.Member.Username;

                string memberNickname = member.Nickname ?? member.Username;

                var embed = new DiscordEmbedBuilder
                {
                    Title = $"{memberNickname}, you have been kissed by {nickname}!",
                    Color = DiscordColor.Purple,
                    ImageUrl = gif,
                };

                embed.Build();
                await ctx.Channel.SendMessageAsync(embed: embed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await ctx.Channel.SendMessageAsync("There was an error while trying to send a kiss!");
            }
        }

        [Command("count-kiss")]
        public async Task KissCount(CommandContext ctx)
        {
            KissREeader kisses = new KissREeader();
            int count = await kisses.KissCount();

            await ctx.Channel.SendMessageAsync($"There are {count} kisses in the database!");
        }

        [Command("add-kiss")]
        public async Task AddKisses(CommandContext ctx, string url)
        {
            try
            {
                KissREeader kisses = new KissREeader();
                await kisses.AddKissGif(url);

                await ctx.Channel.SendMessageAsync("Kiss has been added to the database! UwU");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await ctx.Channel.SendMessageAsync("There was an error while trying to add a kiss!");
            }
        }
    }
}
