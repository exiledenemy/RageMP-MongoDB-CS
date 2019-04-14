using System;
using GTANetworkAPI;
using DataModels;
using Utilities;

namespace resourceone
{
    public class Main : Script
    {
        // Create a single instance of the database
        private static readonly DB db = new DB();

        // New User command
        [Command("newuser")]
        public void CMD_NewUser(Client client, String username, String password)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Client = client.Name
            };
            db.Insert<User>(user);
            client.SendChatMessage($"User {user.Username} : Created succesfully!");
        }

        // Check User command
        [Command("checkuser")]
        public void CMD_CheckUser(Client client, string name)
        {
            var result = db.GetSingle<User>("Username", name).Result;
            client.SendChatMessage($"User {result.Username} : Exists!");
        }
    }
}
