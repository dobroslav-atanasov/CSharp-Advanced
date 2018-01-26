namespace _10._TheHeiganDance
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Player player = new Player();
            Heigan heigan = new Heigan();

            double heiganDamage = double.Parse(Console.ReadLine());
            string spell = string.Empty;

            while (true)
            {
                if (player.IsHit)
                {
                    player.Points -= 3500;
                    player.IsHit = false;
                }

                heigan.Damage(heiganDamage);

                if (HasWinner(player, heigan, spell))
                {
                    break;
                }

                string[] inputParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                spell = inputParts[0];
                int spellRow = int.Parse(inputParts[1]);
                int spellCol = int.Parse(inputParts[2]);

                if (MovePlayer(player.Row, player.Col, spellRow, spellCol) && IsDamaged(spellRow, spellCol, player))
                {
                    switch (spell)
                    {
                        case "Cloud":
                            player.Points -= 3500;
                            player.IsHit = true;
                            break;
                        case "Eruption":
                            player.Points -= 6000;
                            break;
                    }
                }

                if (HasWinner(player, heigan, spell))
                {
                    break;
                }
            }
        }

        private static bool IsDamaged(int spellRow, int spellCol, Player player)
        {
            if (player.Row > 0 && !MovePlayer(player.Row - 1, player.Col, spellRow, spellCol))
            {
                player.Row -= 1;
                return false;
            }

            if (player.Col + 1 < 15 && !MovePlayer(player.Row, player.Col + 1, spellRow, spellCol))
            {
                player.Col += 1;
                return false;
            }

            if (player.Row + 1 < 15 && !MovePlayer(player.Row + 1, player.Col, spellRow, spellCol))
            {
                player.Row += 1;
                return false;
            }

            if (player.Col > 0 && !MovePlayer(player.Row, player.Col - 1, spellRow, spellCol))
            {
                player.Col -= 1;
                return false;
            }
            return true;
        }

        private static bool MovePlayer(int playerRow, int playerCol, int spellRow, int spellCol)
        {
            return (playerRow >= spellRow - 1) && (playerRow <= spellRow + 1) && (playerCol >= spellCol - 1) &&
                   (playerCol <= spellCol + 1);
        }

        private static bool HasWinner(Player player, Heigan heigan, string spell)
        {
            if (player.Points <= 0 || heigan.Points <= 0)
            {
                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }

                Console.WriteLine(heigan.Points > 0 ? $"Heigan: {heigan.Points:F2}" : $"Heigan: Defeated!");
                Console.WriteLine(player.Points > 0 ? $"Player: {player.Points}" : $"Player: Killed by {spell}");
                Console.WriteLine($"Final position: {player.Row}, {player.Col}");

                return true;
            }
            return false;
        }
    }
}