using System;
using System.Threading.Tasks;
using TwitchLib;
using TwitchLib.TwitchAPIClasses;

namespace ConsoleTwitchClient
{
    class Program
    {
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
            User user = await TwitchApi.GetUser(userName);

            Console.WriteLine("DisplayName: " + user.DisplayName);
            Console.WriteLine("Bio: " + user.Bio);
        }
    }
}
