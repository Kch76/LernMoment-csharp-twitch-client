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
    }
}
