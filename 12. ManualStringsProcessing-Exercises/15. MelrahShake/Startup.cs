namespace _15._MelrahShake
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int firstIndex = text.IndexOf(pattern);
                int lastIndex = text.LastIndexOf(pattern);

                if (firstIndex >= 0 && lastIndex >= 0 && pattern.Length > 0)
                {
                    text = text.Remove(lastIndex, pattern.Length);
                    text = text.Remove(firstIndex, pattern.Length);
                    Console.WriteLine("Shaked it.");

                    int indexToRemove = pattern.Length / 2;
                    pattern = pattern.Remove(indexToRemove, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }

            Console.WriteLine(text);
        }
    }
}