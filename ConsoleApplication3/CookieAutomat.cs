using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class CookieAutomat
    {
        public int CurrentBalance;
        public Dictionary<string, int> UserWallet = new Dictionary<string, int>();
        public Dictionary<string, int> AutomatWallet = new Dictionary<string, int>();
        public Dictionary<string, int[]> Products = new Dictionary<string, int[]>();
        public class NotEnoughMoneyException : ApplicationException { }
        public class NotNominalMoneyException : ApplicationException { }
        public class NotRentingMoneyException : ApplicationException { }
        public class NotEnoughProductException : ApplicationException { }



        public CookieAutomat()
        {
            CurrentBalance = 0;
            int[] Cookie = new int[] { 10, 4 };
            int[] Cake = new int[] { 50, 4 };
            int[] Wafers = new int[] { 30, 10 };
            Products.Add("Cookie", Cookie);
            Products.Add("Cake", Cake);
            Products.Add("Wafers", Wafers);
            UserWallet.Add("ten", 0);
            UserWallet.Add("five", 0);
            UserWallet.Add("two", 0);
            UserWallet.Add("one", 0);
            AutomatWallet.Add("ten", 0);
            AutomatWallet.Add("five", 0);
            AutomatWallet.Add("two", 0);
            AutomatWallet.Add("one", 0);
            Random rnd = new Random();
            UserWallet["ten"] = rnd.Next(0, 14);
            UserWallet["five"] = rnd.Next(0, (150 - UserWallet["ten"] * 10) / 5);
            UserWallet["two"] = rnd.Next(0, (150 - UserWallet["ten"] * 10 - UserWallet["five"] * 5) / 2);
            UserWallet["one"] = 150 - UserWallet["ten"] * 10 - UserWallet["five"] * 5 - UserWallet["two"] * 2;//рандомное заполнение кошелька юзера разными монетами,дающими в сумме 150
        }

        public void Add_Money(int R)
        {
            int CurrentSum = UserWallet["one"] + UserWallet["two"] * 2 + UserWallet["five"] * 5 + UserWallet["ten"] * 10;
            if (R > CurrentSum)
            {
                throw new NotEnoughMoneyException();
            }
            Console.SetCursorPosition(0, 0);
            switch (R)
            {
                case (1):
                    if (UserWallet["one"] != 0)
                    {
                        Console.WriteLine("                                     ");
                        UserWallet["one"] = UserWallet["one"] - 1;
                        AutomatWallet["one"] = AutomatWallet["one"] + 1;
                        CurrentBalance = CurrentBalance + 1;
                        break;
                    }
                    else
                    {
                        throw new NotNominalMoneyException();
                    }

                case (2):
                    if (UserWallet["two"] != 0)
                    {
                        Console.WriteLine("                                     ");
                        UserWallet["two"] = UserWallet["two"] - 1;
                        AutomatWallet["two"] = AutomatWallet["two"] + 1;
                        CurrentBalance = CurrentBalance + 2;
                        break;
                    }
                    else
                    {
                        throw new NotNominalMoneyException();
                    }
                case (5):
                    if (UserWallet["five"] != 0)
                    {
                        Console.WriteLine("                                     ");
                        UserWallet["five"] = UserWallet["five"] - 1;
                        AutomatWallet["five"] = AutomatWallet["five"] + 1;
                        CurrentBalance = CurrentBalance + 5;
                        break;
                    }
                    else
                    {
                        throw new NotNominalMoneyException();
                    }
                case (10):
                    if (UserWallet["ten"] != 0)
                    {
                        Console.WriteLine("                                     ");
                        UserWallet["ten"] = UserWallet["ten"] - 1;
                        AutomatWallet["ten"] = AutomatWallet["ten"] + 1;
                        CurrentBalance = CurrentBalance + 10;
                        break;
                    }
                    else
                    {
                        throw new NotNominalMoneyException();
                    }
            }
        }

        public void ranting()
        {
            while (CurrentBalance / 10 != 0 && AutomatWallet["ten"] != 0)
            {
                CurrentBalance = CurrentBalance = CurrentBalance - 10;
                AutomatWallet["ten"] = AutomatWallet["ten"] - 1;
                UserWallet["ten"] = UserWallet["ten"] + 1;
            }
            while (CurrentBalance / 5 != 0 && AutomatWallet["five"] != 0)
            {
                CurrentBalance = CurrentBalance - 5;
                AutomatWallet["five"] = AutomatWallet["five"] - 1;
                UserWallet["five"] = UserWallet["five"] + 1;
            }
            while (CurrentBalance / 2 != 0 && AutomatWallet["two"] != 0)
            {
                CurrentBalance = CurrentBalance - 2;
                AutomatWallet["two"] = AutomatWallet["two"] - 1;
                UserWallet["two"] = UserWallet["two"] + 1;
            }
            while (CurrentBalance != 0 && AutomatWallet["one"] != 0)
            {
                CurrentBalance = CurrentBalance - 2;
                AutomatWallet["one"] = AutomatWallet["one"] - 1;
                UserWallet["one"] = UserWallet["one"] + 1;
            }
            if (CurrentBalance != 0)
            {
                throw new NotRentingMoneyException();
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                     ");
            }

        }
        public void buying_product(string Product)
        {
            if (CurrentBalance < Products[Product][0])
            {
                throw new NotEnoughMoneyException();
            }
            else
            {
                if (Products[Product][1] == 0)
                {
                    throw new NotEnoughProductException();
                }
                else
                {
                    CurrentBalance = CurrentBalance - Products[Product][0];
                    Products[Product][1] = Products[Product][1] - 1;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("                                     ");
                }
            }
        }
        public void printInterf()
        {
            Console.Clear();
            Console.WriteLine(@"########################################################");
            Console.WriteLine(@"#                                                      #");
            Console.WriteLine(@"########################################################");
            Console.WriteLine(@"#               Текущий баланс: {0} рублей              ", CurrentBalance);
            Console.SetCursorPosition(55, 3);
            Console.WriteLine("#");
            Console.WriteLine(@"########################################################");
            Console.WriteLine(@"#        КУПИТЬ            ##        КУПИТЬ            #");
            Console.WriteLine(@"#        Вафли             ##        Кекс              #");
            Console.WriteLine(@"#      {0} Рублей/шт        ##      {1} Рублей/шт        #", Products["Wafers"][0], Products["Cake"][0]);
            Console.WriteLine(@"#      {0} шт в наличии     ", Products["Wafers"][1]);
            Console.SetCursorPosition(27, 8);
            Console.WriteLine(@"##      {0} шт в наличии      #", Products["Cake"][1]);
            Console.WriteLine(@"########################################################");
            Console.WriteLine(@"#        КУПИТЬ            ##      Внести 1 рубль      #");
            Console.WriteLine(@"#        Печенье           ##      Внести 2 рубля      #");
            Console.WriteLine(@"#      {0} Рублей/шт        ##      Внести 5 рублей     #", Products["Cookie"][0], Products["Cake"][0]);
            Console.WriteLine(@"#      {0} шт в наличии      ##      Внести 10 рублей    #", Products["Cookie"][1], Products["Cake"][1]);
            Console.WriteLine(@"########################################################");
            Console.WriteLine(@"#       Кошелек юзера      ##     Кошелек автомата     #");
            Console.WriteLine(@"# Монеты  1р  2р  5р  10р  ##     1р  2р  5р  10р      #");
            Console.Write(@"# Кол-во  {0}  {1}   {2}  {3} ", UserWallet["one"], UserWallet["two"], UserWallet["five"], UserWallet["ten"]);
            Console.SetCursorPosition(23, 17);
            Console.WriteLine(@"    ##     {0}   {1}   {2}   {3}       ", AutomatWallet["one"], AutomatWallet["two"], AutomatWallet["five"], AutomatWallet["ten"]);
            Console.SetCursorPosition(55, 17);
            Console.WriteLine("#");
            Console.WriteLine(@"#       Всего:{0}рублей", (UserWallet["one"] + UserWallet["two"] * 2 + UserWallet["five"] * 5 + UserWallet["ten"] * 10));
            Console.SetCursorPosition(23, 18);
            Console.WriteLine(@"    ##     Всего:{0}рублей", (AutomatWallet["one"] + AutomatWallet["two"] * 2 + AutomatWallet["five"] * 5 + AutomatWallet["ten"] * 10));
            Console.SetCursorPosition(55, 18);
            Console.WriteLine("#");
            Console.WriteLine(@"########################################################");
            Console.WriteLine(@"#                     ЗАБРАТЬ СДАЧУ                    #");
            Console.WriteLine(@"########################################################");
        }
    }


}
