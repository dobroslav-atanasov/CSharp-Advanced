namespace _09._UserLogs
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                string[] inputParts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string[] ipParts = inputParts[0].Split('=');
                string[] userParts = inputParts[2].Split('=');
                string ip = ipParts[1];
                string user = userParts[1];

                if (!users.ContainsKey(user))
                {
                    users[user] = new Dictionary<string, int>();
                }
                if (!users[user].ContainsKey(ip))
                {
                    users[user][ip] = 0;
                }
                users[user][ip]++;

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> user in users)
            {
                string username = user.Key;
                List<string> ips = new List<string>();
                foreach (KeyValuePair<string, int> kvp in user.Value)
                {
                    string ip = $"{kvp.Key} => {kvp.Value}";
                    ips.Add(ip);
                }

                Console.WriteLine($"{username}:");
                Console.WriteLine($"{string.Join(", ", ips)}.");
            }
        }
    }
}