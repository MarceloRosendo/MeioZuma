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
        static public int initialSize = 10;
        static public int variety = 5;
        private static List<int> firstValues;
        private static String presentation; 
        
        public static void Main(string[] args)
        {
            Lista zumaList = new Lista();
            Boolean flag = true;
            int op1, op2;
            ZumaPlayer player = new ZumaPlayer();

            initZuma(ref zumaList);
            
            while (flag)
            {
                Console.Clear();
                zumaList.MostraListaINIFIM();
                
                op1 = generateRandomColor();
                op2 = generateRandomColor();
                
                Console.WriteLine("\nEntre com a posição e com a cor a ser inserida");
                Console.WriteLine("Cores disponiveis [" + op1 + " e " + op2 + "]\n\n\n\n\n");
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
                
                
                zumaList.VerifySequence(player.PositionSelector, player.ColorPicker);
                
                if (zumaList.Tamanho >= 20)
                {
                    Console.WriteLine("Perdeu");
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
                }

                if (zumaList.Tamanho == 0)
                {
                    Console.WriteLine("Vencedor!");
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
                }
            }
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