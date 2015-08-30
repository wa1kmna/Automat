using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int [] CurPosition = new int[2]{0,22};
            CookieAutomat automat = new CookieAutomat();
            ConsoleKeyInfo key = new ConsoleKeyInfo();   
            while (true)
            {
                automat.printInterf();
                Console.SetCursorPosition(CurPosition[0], CurPosition[1]);
                try
                {           
                        key = Console.ReadKey();
                        switch (Convert.ToString(key.Key))
                        {
                            case ("UpArrow"):
                                if (Console.CursorTop - 1 > -1)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                                    CurPosition[0] = Console.CursorLeft;
                                    CurPosition[1] = Console.CursorTop;
                                }
                                else
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    CurPosition[0] = Console.CursorLeft;
                                    CurPosition[1] = Console.CursorTop;
                                }
                                break;
                            case ("DownArrow"):
                                if (Console.CursorTop - 1 < 25)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                                    CurPosition[0] = Console.CursorLeft;
                                    CurPosition[1] = Console.CursorTop;
                                }
                                else
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    CurPosition[0] = Console.CursorLeft;
                                    CurPosition[1] = Console.CursorTop;
                                }
                                break;
                            case ("LeftArrow"):

                                if (Console.CursorLeft - 1 > 0)
                                {
                                    Console.CursorLeft = Console.CursorLeft - 2;
                                    CurPosition[0] = Console.CursorLeft;
                                    CurPosition[1] = Console.CursorTop;
                                }
                                else
                                {
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    CurPosition[0] = Console.CursorLeft;
                                    CurPosition[1] = Console.CursorTop;
                                }
                                break;
                            case ("RightArrow"):
                                CurPosition[0] = Console.CursorLeft;
                                CurPosition[1] = Console.CursorTop;
                                break;
                            case ("Enter"):
                                if(CurPosition[0]>0 & CurPosition[0]<55 & CurPosition[1]==20)
                                    automat.ranting();
                                if (CurPosition[0] > 0 & CurPosition[0] < 27 & CurPosition[1] > 9 & CurPosition[1] < 14)
                                    automat.buying_product("Cookie");
                                if (CurPosition[0] > 0 & CurPosition[0] < 27 & CurPosition[1] > 4 & CurPosition[1] < 9)
                                    automat.buying_product("Wafers");
                                if (CurPosition[0] > 28 & CurPosition[0] < 55 & CurPosition[1] > 4 & CurPosition[1] < 9)
                                    automat.buying_product("Cake");
                                if (CurPosition[0] > 28 & CurPosition[0] < 55 & CurPosition[1] ==10 )
                                    automat.Add_Money(1);
                                if (CurPosition[0] > 28 & CurPosition[0] < 55 & CurPosition[1] == 11)
                                    automat.Add_Money(2);
                                if (CurPosition[0] > 28 & CurPosition[0] < 55 & CurPosition[1] == 12)
                                    automat.Add_Money(5);
                                if (CurPosition[0] > 28 & CurPosition[0] < 55 & CurPosition[1] == 13)
                                    automat.Add_Money(10);
                                break;
                        }
                }
                catch (CookieAutomat.NotEnoughMoneyException)
                {
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Не хватает денег");
                    Console.ReadKey();
                }
                catch (CookieAutomat.NotNominalMoneyException)
                {
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Нет монет данного номинала");
                    Console.ReadKey();
                }
                catch (CookieAutomat.NotRentingMoneyException)
                {
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Извините,у автомата нет монет нужного номинала для сдачи");
                    Console.ReadKey();
                }
                catch (CookieAutomat.NotEnoughProductException)
                {
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Извините,выбранный товар отсутствует в наличии");
                    Console.ReadKey();
                }
            }

        }
    }
}
