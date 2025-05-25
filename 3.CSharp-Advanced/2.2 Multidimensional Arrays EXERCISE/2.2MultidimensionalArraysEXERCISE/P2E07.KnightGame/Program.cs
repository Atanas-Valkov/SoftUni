namespace P2E07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bordSize = int.Parse(Console.ReadLine());

            string[,] bord = new string[bordSize, bordSize];

            for (int row = 0; row < bord.GetLength(0); row++)
            {
                string[] colInfo = Console.ReadLine().Select(c => c.ToString()).ToArray();

                for (int col = 0; col < bord.GetLength(1); col++)
                {
                    bord[row, col] = colInfo[col];
                }
            }

            int removedKnight = 0;
            while (true)
            {
                int maxAttack = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < bord.GetLength(0); row++)
                {
                    for (int col = 0; col < bord.GetLength(1); col++)
                    {
                        if (bord[row, col] != "K")
                        {
                            continue;
                        }

                        int currentAttacks = 0;

                        if (IsInside(bord, row - 2, col - 1) && bord[row - 2, col - 1] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row - 2, col + 1) && bord[row - 2, col + 1] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row + 2, col - 1) && bord[row + 2, col - 1] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row + 2, col + 1) && bord[row + 2, col + 1] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row + 1, col + 2) && bord[row + 1, col + 2] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row - 1, col + 2) && bord[row - 1, col + 2] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row + 1, col - 2) && bord[row + 1, col - 2] == "K")
                        {
                            currentAttacks++;
                        }

                        if (IsInside(bord, row - 1, col - 2) && bord[row - 1, col - 2] == "K")
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttack)
                        {
                            maxAttack = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttack > 0)
                {
                    bord[knightRow, knightCol] = "0";
                    removedKnight++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnight);
        }

        private static bool IsInside(string[,] bord, int row, int col)
        {
            return row >= 0 && row < bord.GetLength(0) &&
                   col >= 0 && col < bord.GetLength(1);
        }
    }
}