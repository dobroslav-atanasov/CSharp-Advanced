namespace _11._LogsAggregator
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            SortedDictionary<string, long> usersDuration = new SortedDictionary<string, long>();
            SortedDictionary<string, SortedSet<string>> usersIp = new SortedDictionary<string, SortedSet<string>>();

            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ip = inputParts[0];
                string user = inputParts[1];
                long duration = long.Parse(inputParts[2]);

                if (!usersDuration.ContainsKey(user))
                {
                    usersDuration[user] = 0;
                }
                usersDuration[user] += duration;

                if (!usersIp.ContainsKey(user))
                {
                    usersIp[user] = new SortedSet<string>();
                }
                usersIp[user].Add(ip);
            }

            foreach (KeyValuePair<string, long> user in usersDuration)
            {
                string username = user.Key;
                string ips = string.Empty;
                if (usersIp.ContainsKey(username))
                {
                    ips = string.Join(", ", usersIp[username]);
                }
                Console.WriteLine($"{user.Key}: {user.Value} [{ips}]");
            }
        }
    }
}