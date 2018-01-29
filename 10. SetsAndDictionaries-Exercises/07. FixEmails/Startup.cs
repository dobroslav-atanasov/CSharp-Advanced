namespace _07._FixEmails
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (input != "stop")
            {
                string name = input;
                string email = Console.ReadLine();
                if (!email.ToLower().EndsWith(".us") && !email.ToLower().EndsWith(".uk"))
                {
                    if (!emails.ContainsKey(name))
                    {
                        emails[name] = string.Empty;
                    }
                    emails[name] = email;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, string> kvp in emails)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}