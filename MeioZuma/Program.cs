using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ListaDuplamenteEncadeada;

namespace MeioZuma
{
    internal class Program
    {
        static public Random random = new Random();
        static public int initialSize = 8;
        static public int variety = 4;
        private static List<int> firstValues;
        private static String presentation; 
        
        public static void Main(string[] args)
        {
            Lista zumaList = new Lista();
            Boolean flag = true;
            int op1, op2;
            ZumaPlayer player = new ZumaPlayer();
            newGameAnimation();
            initZuma(ref zumaList);
            
            while (flag)
            {
                zumaList.MostraListaINIFIM();

                if (GenerateColorOption(zumaList, out op1, out op2))
                {
                    zumaList = GameOverWinner(zumaList, ref flag, player);
                }

                Console.WriteLine("\nEntre com a posição e com a cor a ser inserida");
                Console.WriteLine("Cores disponiveis [" + op1 + " e " + op2 + "]\n\n\n");
                Console.WriteLine("Pontos: " + player.Score);
                Console.Write("Posição: ");
                player.PositionSelector = int.Parse(Console.ReadLine());
                
                if (entryValidator(player, zumaList))
                {
                    Console.WriteLine("Posição inválida");
                    Thread.Sleep(1500);
                    continue;
                }
                Console.Write("Cor [" + op1 + " ou " + op2 + "]: ");

                do
                {
                    player.ColorPicker = int.Parse(Console.ReadLine());

                    if (player.ColorPicker == op1 || player.ColorPicker == op2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Escolha uma das cores disponíveis: " + op1 + " ou " + op2);
                    }
                } while (true);
                
                
                zumaList.VerifySequence(player.PositionSelector, player.ColorPicker, ref player);
                
                if (zumaList.Tamanho >= 20)
                {
                    zumaList = GameOverLoser(zumaList, ref flag, player);
                }

                if (zumaList.Tamanho == 0)
                {
                    zumaList = GameOverWinner(zumaList, ref flag, player);
                }
            }
        }

        private static void newGameAnimation()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(File.ReadAllText("home.txt"));
                Thread.Sleep(1000);
                Console.Clear();
                Thread.Sleep(100);
            }
        }

        private static Lista GameOverLoser(Lista zumaList, ref bool flag, ZumaPlayer player)
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText("loser.txt"));
            Console.WriteLine(player.Score + " pontos");
            Console.WriteLine("Gostaria de jogar novamente?(0-sim, *-não)");
            if (int.Parse(Console.ReadLine()) == 0)
            {
                Console.Clear();
                zumaList = new Lista();
                initZuma(ref zumaList);
            }
            else
            {
                flag = false;
            }

            return zumaList;
        }

        private static Lista GameOverWinner(Lista zumaList, ref bool flag, ZumaPlayer player)
        {
            Console.Clear();
            
            Console.WriteLine(File.ReadAllText("winner.txt"));
            Console.WriteLine("Você fez " + player.Score + " pontos");
            Console.WriteLine("Gostaria de jogar novamente?(0-sim, *-não)");
            if (int.Parse(Console.ReadLine()) == 0)
            {
                Console.Clear();
                zumaList = new Lista();
                initZuma(ref zumaList);
            }
            else
            {
                flag = false;
            }

            return zumaList;
        }

        private static Boolean GenerateColorOption(Lista zumaList, out int op1, out int op2)
        {
            try
            {
                if (zumaList.Tamanho <= 2)
                {
                    int[] aux = zumaList.pickTwoRandomColors();
                    if (aux == null)
                    {
                        op1 = 0;
                        op2 = 0;
                        return true;
                    }

                    op1 = aux[0];
                    op2 = aux[1];
                }
                else
                {
                    op1 = generateRandomColor();
                    op2 = generateRandomColor();
                }

                return false;
            }
            catch (Exception e)
            {
                op1 = 0;
                op2 = 0;
                return true;
            }
            
        }

        private static void WinMessage()
        {
            
        }

        private static Boolean entryValidator(ZumaPlayer player, Lista zumaList)
        {
            if (player != null)
            {
                if (player.ColorPicker != null)
                {
                    if (player.PositionSelector != null && (player.PositionSelector > zumaList.Tamanho || player.PositionSelector < 1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void initZuma(ref Lista zumaList)
        {
            firstValues = new List<int>();
            generateValuesRandomly(ref firstValues);

            foreach (int el in firstValues)
            {
                zumaList.InserirInício(el);
            }
        }
        
        private static void generateValuesRandomly(ref List<int> randomList)
        {
            while (randomList.Count != initialSize)
            {
                int aux = generateRandomColor();
                randomList.Add(aux);
            }
        }

        private static int generateRandomColor()
        {
            return random.Next(0, variety);
        }
        
    }
}