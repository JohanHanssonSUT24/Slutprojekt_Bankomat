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
            bool correctPass = false;
            int userPass;
            int userLoggins = 0;
            int userNumber;
            while (!correctLoggin && userLoggins < 3)
            {
                Console.WriteLine("Välkommen till DinBank!");
                Console.WriteLine("Skriv ditt personnummer: ");
                if (!int.TryParse(Console.ReadLine(), out userNumber))
                {
                    Console.WriteLine("Felaktig inmatning.");
                }
                else if (!Array.Exists(userNameArray, element => element == userNumber))
                {
                    Console.WriteLine("Personnumret finns inte i vårt register.\n");
                }
                else
                {
                    while (!correctPass)
                    {
                        Console.WriteLine("Skriv ditt lösenord: ");
                        userPass = Int32.Parse(Console.ReadLine());
                        if (userPass == userPassArray[Array.IndexOf(userNameArray, userNumber)])
                        {
                            correctPass = true;
                            bool menuBool = true;
                            while (menuBool)
                            {   //Meny
                                Console.Clear();
                                Console.WriteLine("Välkommen!");
                                Console.WriteLine("Var god välj ett av följande alternativ.");
                                Console.WriteLine("[1] Se dina konton och saldo");
                                Console.WriteLine("[2] Överföring mellan konton");
                                Console.WriteLine("[3] Ta ut pengar");
                                Console.WriteLine("[4] Logga ut");
                                string userChoice = Console.ReadLine();
                                switch (userChoice)
                                {
                                    case "1": //Konton och saldon
                                        Console.Clear();
                                        Console.WriteLine("Se konton och saldo:\n");
                                        Console.WriteLine("--------------------");
                                        AccountBalance(userNumber, userNameArray, bankAccounts, accountBalance);
                                        Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                        Console.ReadKey();
                                        break;

                                    case "2": //Överföring
                                        Console.Clear();
                                        Console.WriteLine("Överföring");
                                        Console.WriteLine("-----------\n");
                                        TransferFunds(userNumber, userNameArray, bankAccounts, accountBalance);
                                        Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                        Console.ReadKey();
                                        //Metod för överföring
                                        break;

                                    case "3": //uttag
                                        Console.Clear();
                                        Console.WriteLine("Uttag");
                                        Console.WriteLine("-------\n");
                                        WithdrawMoney(userNumber, userNameArray, userPassArray, bankAccounts, accountBalance);
                                        Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                        Console.ReadKey();
                                        //Metod för uttag
                                        break;

                                    case "4": //Utloggning
                                        Console.Clear();
                                        Console.Write("Du loggas nu ut. Tack för besöket!");
                                        menuBool = false;
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.WriteLine("Felaktig input. Välj alternativ 1-4!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt lösenord.\n");
                            userLoggins++;
                        }
                        if (userLoggins == 3)
                        {
                            Console.WriteLine("Tyvärr, du har försökt logga in för många gånger!");
                            correctLoggin = true;
                            correctPass = true;
                        }
                    }
                }
            }
        }
        public static void AccountBalance(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
        {
            int user = Array.IndexOf(userNameArray, userName);
            for (int i = 0; i < bankAccounts[user].Length; i++)
            {
                string bankAccount = bankAccounts[user][i];
                double balanceOfAccount = accountBalance[user][i];

                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine("Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
        }
        public static void TransferFunds(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
        {
            bool transferBool = true;
            int user = Array.IndexOf(userNameArray, userName);
            for (int i = 0; i < bankAccounts[user].Length; i++)
            {
                string bankAccount = bankAccounts[user][i];
                double balanceOfAccount = accountBalance[user][i];
                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
            while (transferBool)
            {

                Console.WriteLine("Välj konto att flytta pengar ifrån: ");
                int fromAccount = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Välj konto att flytta pengar till: ");
                int toAccount = Int32.Parse(Console.ReadLine()) - 1;
                if (fromAccount != toAccount)
                {
                    Console.WriteLine("Skriv den summa du vill flytta över: ");
                    double transferSum = double.Parse(Console.ReadLine());

                    if (transferSum <= 0)
                    {
                        Console.WriteLine("Ogiltigt uttag. Du måste ange en summa högre än 0.\n");

                    }
                    else if (transferSum > accountBalance[user][fromAccount])
                    {
                        Console.WriteLine("Ogiltigt uttag. Du kan inte föra över mer pengar än vad som finns tillgängligt på kontot.\n");
                    }
                    else if (transferSum >= 0 || transferSum < accountBalance[user][fromAccount])
                    {
                        accountBalance[user][toAccount] = accountBalance[user][toAccount] + transferSum;
                        accountBalance[user][fromAccount] = accountBalance[user][fromAccount] - transferSum;

                        Console.WriteLine("\nSaldo:\n");
                        for (int i = 0; i < accountBalance[user].Length; i++)
                        {
                            string bankAccount = bankAccounts[user][i];
                            double balanceOfAccount = accountBalance[user][i];
                            Console.WriteLine($"Konto: " + bankAccount);
                            Console.WriteLine($"Saldo: " + balanceOfAccount);
                            Console.WriteLine("---------------------");

                        }
                        transferBool = false;
                    }
                }
                else
                {
                    Console.WriteLine("Du kan inte göra en överföring till samma konto!\n");
                }
            }
        }
        public static void WithdrawMoney(int userName, int[] userNameArray, int[] userPassArray, string[][] bankAccounts, double[][] accountBalance)
        {
            bool passBool = true;
            int user = Array.IndexOf(userNameArray, userName);
            for (int i = 0; i < bankAccounts[user].Length; i++)
            {
                string bankAccount = bankAccounts[user][i];
                double balanceOfAccount = accountBalance[user][i];
                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("Välj konto att ta pengar ifrån: ");
            int fromAccount = Int32.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Skriv den summa du vill ta ut: ");
            double transferSum = double.Parse(Console.ReadLine());
            int counterPass = 0;
            while (passBool)
            {
                Console.WriteLine("Ange lösenord för att bekräfta uttag: ");
                int withdrawPass = Int32.Parse(Console.ReadLine());

                if (withdrawPass != userPassArray[user] && counterPass < 3)
                {
                    Console.WriteLine("Fel lösenord.\n");
                    counterPass++;
                }
                else
                {
                    passBool = false;
                }
                if (counterPass == 3)
                {
                    Console.WriteLine("Du har skrivit fel lösenord 3 gånger. Transaktion avbruten.");
                    passBool = false;
                }
            }
            if (transferSum <= 0)
            {
                Console.WriteLine("Ogiltigt uttag. Du måste ange en summa högre än 0.\n");
            }
            else if (transferSum > accountBalance[user][fromAccount])
            {
                Console.WriteLine("Summan du försöker ta ut är större än kontots saldo.\n");
            }
            else if (transferSum >= 0 || transferSum < accountBalance[user][fromAccount])
            {
                accountBalance[user][fromAccount] = accountBalance[user][fromAccount] - transferSum;
            }
            Console.WriteLine("\nUttag genomfört!\n");
            Console.WriteLine("\nSaldo:\n");
            for (int i = 0; i < accountBalance[user].Length; i++)
            {
                string bankAccount = bankAccounts[user][i];
                double balanceOfAccount = accountBalance[user][i];
                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }
        }
    }
}







