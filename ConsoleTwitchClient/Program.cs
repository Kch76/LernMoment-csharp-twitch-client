using System;
using System.Threading.Tasks;
using TwitchLib;
using TwitchLib.TwitchAPIClasses;

namespace ConsoleTwitchClient
{
    class Program
    {
        // TODO: Ersetze bitte die Werte von clientId und tutorialUserName, weil ich
        // beides löschen werde oder es schon gelöscht habe!
        private static readonly string clientId = "865mxocrji3lctk8kscy3zgvkxm7t3e";
        private static readonly string tutorialUserName = "tutorialtestuser";
        private static readonly string manyFollowerUserName = "jonnyzocktyt";
        private static readonly string largeChannelName = "RedCityBoy23";

        static void Main(string[] args)
        {
            ShowUserDetails(tutorialUserName);
            ShowUserDetails(manyFollowerUserName);
            ShowChannelDetails(largeChannelName);
            ShowBadges(largeChannelName);

            Console.ReadLine();
        }

        private static async Task ShowUserDetails(string userName)
        {
            TwitchApi.SetClientId(clientId);

            Console.WriteLine("ShowUserDetails: Hole Informationen über den Benutzer: " + userName);

            // Asynchron die Anfrage absetzten und auf Antwort warten.
            User user = await TwitchApi.GetUser(userName);

            Console.WriteLine("\nShowUserDetails: Informationen über den Benutzer: " + user.Name);
            Console.WriteLine("Biographie: " + user.Bio);
            Console.WriteLine("Id: " + user.Id);
            Console.WriteLine("Type: " + user.Type);
            Console.WriteLine("Created at: " + user.CreatedAt);
        }

        private static async Task ShowChannelDetails(string channelName)
        {
            // Sicherstellen, dass die clientId gesetzt ist. Ohne läuft die TwitchAPI nicht!
            TwitchApi.SetClientId(clientId);

            Console.WriteLine("ShowChannelDetails: Hole Informationen über den Channel: " + channelName);

            // Asynchron die Anfrage absetzten und auf Antwort warten.
            Channel channel = await TwitchApi.GetTwitchChannel(channelName);

            Console.WriteLine("\nShowChannelDetails: Informationen über den Channel: " + channelName);
            Console.WriteLine("DisplayName: " + channel.DisplayName);
            Console.WriteLine("Spiel: " + channel.Game);
            Console.WriteLine("Background: " + channel.Background);
            Console.WriteLine("Follower: " + channel.Followers);
            Console.WriteLine("Logo: " + channel.Logo);
        }

        private static async Task ShowBadges(string channelName)
        {
            TwitchApi.SetClientId(clientId);

            Console.WriteLine("ShowBadges: Hole Informationen über die Badges vom Channel: " + channelName);

            // Asynchron die Anfrage absetzten und auf Antwort warten.
            BadgeResponse response = await TwitchApi.GetChannelBadges(channelName);
            var badges = response.ChannelBadges;

            Console.WriteLine("\nShowBadges: Channel {0} hat: {1} Badges", channelName, badges.Count);
            foreach (var badge in badges)
            {
                Console.WriteLine("BadgeName: " + badge.BadgeName);
            }
        }
    }
}
