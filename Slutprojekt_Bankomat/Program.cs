using System.Security.Principal;

namespace Slutprojekt_Bankomat
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Arrays for users accountname, password

            int[] userNameArray = new int[] { 850128, 890918, 100723, 180423, 230110 };
            int[] userPassArray = new int[] { 1111, 2222, 3333, 4444, 5555 };

            //Jagged array for bankaccount names
            string[][] bankAccounts =
            {
                new string[] {"[1]Bankkonto", "[2]Sparkonto", "[3]Pensionskonto", "[4]Aktier"},
                new string[] {"[1]Bankkonto", "[2]Sparkonto", "[3]Pensionskonto"},
                new string[] {"[1]Bankkonto", "[2]Sparkonto"},
                new string[] {"[1]Sparkonto"},
                new string[] {"[1]Sparkonto"}
            };
            //Jagged array for accountbalance
            double[][] accountBalance =
            {
                new double[] { 22034.33, 12503.23, 150138.98, 340986.09 },
                new double[] { 101455.12, 202434.22, 234098.96 },
                new double[] { 11003.11, 30078.14 },
                new double[] { 4054.55 },
                new double[] { 1599.64 },
            };


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
                            Console.ReadKey();
                        }

                        switch (menuChoice)
                        {
                            case 1: //Konton och saldon
                                Console.Clear();
                                Console.WriteLine("Se konton och saldo:\n");
                                Console.WriteLine("--------------------");
                                AccountBalance(userNumber, userNameArray, bankAccounts, accountBalance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();

                                
                                break;

                            case 2: //Överföring
                                Console.Clear();
                                Console.WriteLine("Överföring");
                                Console.WriteLine("-----------\n");
                                TransferFunds(userNumber, userNameArray, bankAccounts, accountBalance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();
                                //Metod för överföring
                                break;

                            case 3: //uttag
                                Console.Clear();
                                Console.WriteLine("Uttag");
                                Console.WriteLine("-------\n");
                                WithdrawMoney(userNumber, userNameArray, bankAccounts, accountBalance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();
                                //Metod för uttag
                                break;

                            case 4: //Utloggning
                                Console.Clear();
                                Console.Write("Du loggas nu ut. Tack för besöket!");
                                menuBool = false;
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            default:
                                Console.WriteLine("Felaktig input. Välj alt 1-4!");
                                Console.ReadKey();
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
        public static void AccountBalance(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
        {
            int userIndex = Array.IndexOf(userNameArray, userName);

            for (int i = 0; i < bankAccounts[userIndex].Length; i++)
            {
                string bankAccount = bankAccounts[userIndex][i];
                double balanceOfAccount = accountBalance[userIndex][i];

                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine("Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
        }

        public static void TransferFunds(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
        {
            int userIndex = Array.IndexOf(userNameArray, userName);

            for (int i = 0; i < bankAccounts[userIndex].Length; i++)
            {
                string bankAccount = bankAccounts[userIndex][i];
                double balanceOfAccount = accountBalance[userIndex][i];

                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Skriv den summa du vill flytta över: ");
            double transferSum = double.Parse(Console.ReadLine());
            Console.WriteLine("Välj konto att flytta pengar ifrån: ");
            int fromAccount = Int32.Parse(Console.ReadLine())-1;
            accountBalance[userIndex][fromAccount] = accountBalance[userIndex][fromAccount]-transferSum;
            Console.WriteLine("Välj konto att flytta pengar till: ");
            int toAccount = Int32.Parse(Console.ReadLine())-1;
            accountBalance[userIndex][toAccount] = accountBalance[userIndex][toAccount] + transferSum;

            Console.WriteLine("\nNytt saldo:\n");
            for (int i = 0; i < accountBalance[userIndex].Length; i++)
            {
                string bankAccount = bankAccounts[userIndex][i];
                double balanceOfAccount = accountBalance[userIndex][i];


                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
        }
        public static void WithdrawMoney(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
        {
            int userIndex = Array.IndexOf(userNameArray, userName);

            for (int i = 0; i < bankAccounts[userIndex].Length; i++)
            {
                string bankAccount = bankAccounts[userIndex][i];
                double balanceOfAccount = accountBalance[userIndex][i];

                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Skriv den summa du vill ta ut: ");
            double transferSum = double.Parse(Console.ReadLine());
            Console.WriteLine("Välj konto att ta pengar ifrån: ");
            int fromAccount = Int32.Parse(Console.ReadLine()) - 1;
            accountBalance[userIndex][fromAccount] = accountBalance[userIndex][fromAccount] - transferSum;
            

            Console.WriteLine("\nNytt saldo:\n");
            for (int i = 0; i < accountBalance[userIndex].Length; i++)
            {
                string bankAccount = bankAccounts[userIndex][i];
                double balanceOfAccount = accountBalance[userIndex][i];


                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
        }
    }
}







