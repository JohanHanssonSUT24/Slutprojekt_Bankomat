﻿namespace Slutprojekt_Bankomat
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int[] userNameArray = new int[] { 850128, 890918, 100723, 180423, 230110 };
            int[] userPassArray = new int[] { 1111, 2222, 3333, 4444, 5555 };
            int[] userBalanceArray = new int[] { 22034, 101455, 11003, 8078, 3452 };
            int[] userSavingsArray = new int[] { 12503, 202434, 30078, 4054, 599 };

            bool correctLoggin = false;
            int userPass;
            int userLoggins = 0;


            while (!correctLoggin && userLoggins < 3)
            {
                Console.WriteLine("Välkommen till DinBank!");
                Console.WriteLine("Skriv ditt personnummer: ");
                int userNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Skriv ditt lösenord: ");

                userPass = Int32.Parse(Console.ReadLine());
                if (userPass == userPassArray[Array.IndexOf(userNameArray, userNumber)])
                {
                    bool menuBool = true;
                    while (menuBool)
                    {
                        Console.Clear();
                        Console.WriteLine("Välkommen!");
                        Console.WriteLine("Var god välj ett av följande alternativ.");
                        Console.WriteLine("[1] Se dina konton och saldo");
                        Console.WriteLine("[2] Överföring mellan konton");
                        Console.WriteLine("[3] Ta ut pengar");
                        Console.WriteLine("[4] Logga ut");

                        

                        int menuChoice;
                        while (!Int32.TryParse(Console.ReadLine(), out menuChoice))
                        {
                            Console.WriteLine("Felaktig input!\nAnge alt 1 - 4. ");
                        }

                        switch (menuChoice)
                        {
                            case 1:
                                Console.WriteLine("Aktuella saldon:");
                                AccountBalance(userNumber, userNameArray, userBalanceArray, userSavingsArray);
                                
                                Console.ReadKey();
                                //Metod för konton och saldo
                                break;

                            case 2:
                                Console.WriteLine("Intern överföring");
                                TransferMoney(userNumber, userNameArray, userBalanceArray, userSavingsArray);
                                Console.ReadKey();
                                //Metod för överföring
                                break;

                            case 3:
                                Console.WriteLine("Ta ut pengar");
                                Console.ReadKey();
                                //Metod för uttag
                                break;

                            case 4:
                                Console.Write("Du loggas nu ut. Tack för besöket!");
                                menuBool = false;
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }

                    }

                }
                else
                {
                    Console.WriteLine("Felaktigt lösenord.");
                    userLoggins++;
                }

                if (userLoggins == 3)
                {
                    Console.WriteLine("Tyvärr, du har försökt logga in för många gånger!");
                    correctLoggin = true;
                }
            }

        }
        public static int AccountBalance(int userName, int[]userNameArray, int[] userBalanceArray, int[] userSavingsArray)
        {

            Console.WriteLine("Bankkonto: " + userBalanceArray[Array.IndexOf(userNameArray, userName)]);
            Console.WriteLine("Sparkonto: " + userSavingsArray[Array.IndexOf(userNameArray, userName)]);

            

            return userNameArray[0];

        }
        public static void TransferMoney(int userName, int[] userNameArray, int[] userBalanceArray, int[] userSavingsArray)
        {

            int userBalance = userBalanceArray[Array.IndexOf(userNameArray, userName)];
            int userSavings = userSavingsArray[Array.IndexOf(userNameArray, userName)];
            Console.WriteLine("Vilket konto vill du föra över pengar ifrån?");
            Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
            Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
            int account = Int32.Parse(Console.ReadLine());
            int amount = 0;
            int NewUserBalance = userBalance + amount;
            int NewUserSavings = userSavings - amount;            


            if (account == 1)
            {
                Console.WriteLine("Hur mycket pengar vill du för över?: ");
                amount = Int32.Parse(Console.ReadLine());
                userBalance = userBalance - amount;
                userSavings = userSavings + amount;
                Console.WriteLine("Nytt saldo Bankkonto: " + userBalance);
                Console.WriteLine("Nytt saldo Sparkonto: " + userSavings);
                
            }

            else if ( account == 2)
            {
                Console.WriteLine("Hur mycket pengar vill du för över?: ");
                amount = Int32.Parse(Console.ReadLine());
                //int NewUserBalance = userBalance + amount;
                //int NewUserSavings = userSavings - amount;
                Console.WriteLine("Nytt saldo Bankkonto: " + NewUserBalance);
                Console.WriteLine("Nytt saldo Sparkonto: " + NewUserSavings);

            }

            return NewUserBalance;
            return NewUserSavings;
            

        }
        
        //}
        //public static int WithdrawMoney()
        //{
        //    return;
        //}
    }
}
