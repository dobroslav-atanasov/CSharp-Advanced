namespace _12._CharacterMultiplier
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
            string firstString = words[0];
            string secondString = words[1];

            int sum = 0;
            if (firstString.Length == secondString.Length)
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    sum += (int) firstString[i] * (int) secondString[i];
                }
            }
            else if (firstString.Length > secondString.Length)
            {
                for (int i = 0; i < secondString.Length; i++)
                {
                    sum += (int)firstString[i] * (int)secondString[i];
                }
                for (int i = secondString.Length; i < firstString.Length; i++)
                {
                    sum += (int) firstString[i];
                }
            }
            else
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    sum += (int)firstString[i] * (int)secondString[i];
                }
                for (int i = firstString.Length; i < secondString.Length; i++)
                {
                    sum += (int)secondString[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}