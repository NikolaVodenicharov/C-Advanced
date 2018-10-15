namespace TheHeiganDance
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static double HeiganLifePoints = 3000000;
        private const int PlagueCloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private static Area damageArea;
        private static bool IsPlagueCloudActive = false;

        private static Player player = new Player();

        private const int FirstRowIndex = 0;
        private const int LastRowIndex = 14;
        private const int FirstColumnIndex = 0;
        private const int LastColumnIndex = 14;

        public static void Main(string[] args)
        {
            player.AttackPoints = double.Parse(Console.ReadLine());

            ExecuteCommands();
            Console.WriteLine(FormatResult());
        }

        private static void ExecuteCommands()
        {
            while (true)
            {
                AttackHeigan();
                if (!IsHeiganAlive())
                {
                    break;
                }

                AttackPlayer();
                if (!player.IsAlive)
                {
                    break;
                }
            }
        }

        private static void AttackHeigan()
        {
            HeiganLifePoints -= player.AttackPoints;
        }
        private static bool IsHeiganAlive()
        {
            if (HeiganLifePoints <= 0)
            {
                return false;
            }

            return true;
        }

        private static void AttackPlayer()
        {
            RenderResidualSpells();
            if (!player.IsAlive)
            {
                return;
            }

            var command = Console.ReadLine().Split().ToArray();

            CreateDamageArea(command);

            if (!IsPlayerInsideDamageZone())
            {
                return;
            }

            // try move player, else take the damage
            if (player.RowIndex > FirstRowIndex &&
                (player.RowIndex - 1) < damageArea.FirstRow)
            {
                player.RowIndex--;
            }
            else if (player.ColumnIndex < LastColumnIndex &&
                    (player.ColumnIndex + 1) > damageArea.LastColumn)
            {
                player.ColumnIndex++;
            }
            else if (player.RowIndex < LastRowIndex &&
                    (player.RowIndex + 1) > damageArea.LastRow)
            {
                player.RowIndex++;
            }
            else if (player.ColumnIndex > FirstColumnIndex &&
                    (player.ColumnIndex - 1) < damageArea.FirstColumn)
            {
                player.ColumnIndex--;
            }
            else
            {
                HitPlayer(command);
            }
        }
        private static void RenderResidualSpells()
        {
            if (IsPlagueCloudActive)
            {
                player.LifePoints -= PlagueCloudDamage;
                IsPlagueCloudActive = false;

                if (!player.IsAlive)
                {
                    player.KilledBy = "Plague Cloud";
                }
            }
        }
        private static void CreateDamageArea(string[] command)
        {
            var targetRow = int.Parse(command[1]);
            var targetColumn = int.Parse(command[2]);

            damageArea = new Area
            {
                FirstRow = Math.Max(FirstRowIndex, targetRow - 1),
                LastRow = Math.Min(LastRowIndex, targetRow + 1),
                FirstColumn = Math.Max(FirstColumnIndex, targetColumn - 1),
                LastColumn = Math.Min(LastColumnIndex, targetColumn + 1)
            };
        }
        private static bool IsPlayerInsideDamageZone()
        {
            if (player.RowIndex >= damageArea.FirstRow &&
                player.RowIndex <= damageArea.LastRow &&
                player.ColumnIndex >= damageArea.FirstColumn &&
                player.ColumnIndex <= damageArea.LastColumn)
            {
                return true;
            }

            return false;
        }
        private static void HitPlayer(string[] command)
        {
            var spell = command[0];

            if (spell.Equals("Cloud"))
            {
                player.LifePoints -= PlagueCloudDamage;
                IsPlagueCloudActive = true;

                if (!player.IsAlive)
                {
                    player.KilledBy = "Plague Cloud";
                }
            }
            else if (spell.Equals("Eruption"))
            {
                player.LifePoints -= EruptionDamage;

                if (!player.IsAlive)
                {
                    player.KilledBy = "Eruption";
                }
            }
            else
            {
                throw new ArgumentException("Invalid spell.");
            }
        }

        private static string FormatResult()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Heigan: {0}", 
                IsHeiganAlive() ? 
                String.Format($"{HeiganLifePoints:f2}") : 
                "Defeated!");

            sb.AppendLine();

            sb.AppendFormat("Player: {0}", 
                player.IsAlive ? 
                player.LifePoints.ToString() : 
                String.Format($"Killed by {player.KilledBy}"));

            sb.AppendLine();

            sb.AppendFormat($"Final position: {player.RowIndex}, {player.ColumnIndex}");

            return sb.ToString();
        }
    }
}
