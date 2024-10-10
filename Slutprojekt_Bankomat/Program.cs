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
                new string[] {"[1]Bankkonto", "[2]Sparkonto", "[3]Pensionskonto", "[4]Aktier", "[5]Fonder" },
                new string[] {"[1]Bankkonto", "[2]Sparkonto", "[3]Pensionskonto", "[4]Aktier" },
                new string[] {"[1]Bankkonto", "[2]Sparkonto", "[3]Pensionskonto" },
                new string[] {"[1]Sparkonto","[2]Fonder" },
                new string[] {"[1]Sparkonto"}
            };
            //Jagged array for accountbalance
            decimal[][] accountBalance =
            {
                new decimal[] { 22034.33m, 12503.23m, 150138.98m, 340986.09m, 276349.19m },
                new decimal[] { 101455.12m, 202434.22m, 234098.96m, 510652.99m },
                new decimal[] { 11003.11m, 30078.14m, 36889.71m },
                new decimal[] { 4054.55m, 27980.76m },
                new decimal[] { 1599.64m },
            };
            bool correctLoggin = false;
            int userPass;
            int userLoggins = 0;
            int userNumber;
            Console.WriteLine("Välkommen till DinBank!\n");
            while (!correctLoggin && userLoggins < 3)
            {
                Console.WriteLine("Skriv ditt personnummer: ");
                if (!int.TryParse(Console.ReadLine(), out userNumber))  //See if user input is a number
                {
                    Console.WriteLine("Felaktig inmatning.");
                }
                else if (!Array.Exists(userNameArray, element => element == userNumber)) //Use Array.Exists to check if user input exists in array or not.
                {
                    Console.WriteLine("Personnumret finns inte i vårt register.\n");
                }
                else
                {
                    Console.WriteLine("Skriv ditt lösenord: "); //Compare if input has the same indexplace in password-array as in username-array.  
                    int.TryParse(Console.ReadLine(), out userPass);
                    if (userPass == userPassArray[Array.IndexOf(userNameArray, userNumber)])
                    {
                        bool menuBool = true;
                        while (menuBool)
                        {
                            Console.Clear();//Menu
                            Console.WriteLine("Välkommen!");
                            Console.WriteLine("Var god välj ett av följande alternativ.");
                            Console.WriteLine("[1] Se dina konton och saldo");
                            Console.WriteLine("[2] Överföring mellan konton");
                            Console.WriteLine("[3] Ta ut pengar");
                            Console.WriteLine("[4] Logga ut");
                            string userChoice = Console.ReadLine();
                            switch (userChoice)
                            {
                                case "1": //Accounts and balance
                                    Console.Clear();
                                    Console.WriteLine("Se konton och saldo:\n");
                                    AccountBalance(userNumber, userNameArray, bankAccounts, accountBalance);
                                    Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                    Console.ReadKey();
                                    break;

                                case "2": //Transfer
                                    Console.Clear();
                                    Console.WriteLine("Överföring\n");
                                    TransferFunds(userNumber, userNameArray, bankAccounts, accountBalance);
                                    Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                    Console.ReadKey();
                                    break;

                                case "3": //Withdraw
                                    Console.Clear();
                                    Console.WriteLine("Uttag\n");
                                    WithdrawMoney(userNumber, userNameArray, userPassArray, bankAccounts, accountBalance);
                                    Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                    Console.ReadKey();
                                    break;

                                case "4": //Log out
                                    Console.Clear();
                                    Console.Write("Du loggas nu ut. Tack för besöket!\n");
                                    correctLoggin = false;
                                    menuBool = false;
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                default: //Error message
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
                    }
                }
            }
        }
        public static void AccountBalance(int userNumber, int[] userNameArray, string[][] bankAccounts, decimal[][] accountBalance) //Method to see accounts and balances
        {
            UserConfirmation(userNumber, userNameArray, bankAccounts, accountBalance); //Call method for userconfirmation
        }
        public static void TransferFunds(int userNumber, int[] userNameArray, string[][] bankAccounts, decimal[][] accountBalance) //Method for moneytransfer
        {
            bool transferBool = true;
            UserConfirmation(userNumber, userNameArray, bankAccounts, accountBalance);
            int user = Array.IndexOf(userNameArray, userNumber);

            if (bankAccounts[user].Length < 2) //Validate if transfer is possible
            {
                Console.WriteLine("Du kan inte föra över mellan konton då du endast har ett konto.");
                transferBool = false;
            }
            while (transferBool)
            {
                Console.WriteLine("Välj konto att flytta pengar ifrån: ");
                int fromAccount = Int32.Parse(Console.ReadLine()) - 1;

                if (fromAccount < 0 || fromAccount > bankAccounts[user].Length - 1) //If user tries to choose accounts that doesnt exists
                {
                    Console.WriteLine("Ogiltigt val av konto!");
                }
                else
                {
                    Console.WriteLine("Välj konto att flytta pengar till: ");
                    int toAccount = Int32.Parse(Console.ReadLine()) - 1;
                    if (toAccount < 0 || toAccount > bankAccounts[user].Length - 1)  //If user tries to choose accounts that doesnt exists
                    {
                        Console.WriteLine("Ogiltigt val av konto!");
                    }
                    else
                    {
                        if (fromAccount == toAccount)
                        {
                            Console.WriteLine("Du kan inte göra en överföring till samma konto!\n");//If user tries to move money to the same account.
                        }
                        if (fromAccount != toAccount)
                        {
                            Console.WriteLine("Skriv den summa du vill flytta över: ");
                            decimal transferSum = decimal.Parse(Console.ReadLine());

                            if (transferSum <= 0)
                            {
                                Console.WriteLine("Ogiltigt uttag. Du måste ange en summa högre än 0.\n"); //Errormessage if user input is 0 or less.
                            }
                            else if (transferSum > accountBalance[user][fromAccount])//Errormessage if user input is larger than amount avalible in given account.
                            {
                                Console.WriteLine("Ogiltigt uttag. Du kan inte föra över mer pengar än vad som finns tillgängligt på kontot.\n");
                            }
                            else if (transferSum >= 0 || transferSum < accountBalance[user][fromAccount])//If input is OK. Do transaction and show new accountbalance
                            {
                                accountBalance[user][toAccount] = accountBalance[user][toAccount] + transferSum;
                                accountBalance[user][fromAccount] = accountBalance[user][fromAccount] - transferSum;

                                Console.WriteLine("\nNytt saldo:\n");
                                string bankAccountFrom = bankAccounts[user][fromAccount];
                                decimal balanceOfAccountFrom = accountBalance[user][fromAccount];
                                Console.WriteLine($"Konto: " + bankAccountFrom);
                                Console.WriteLine($"Saldo: " + balanceOfAccountFrom);
                                Console.WriteLine("---------------------");

                                string bankAccountTo = bankAccounts[user][toAccount];
                                decimal balanceOfAccountTo = accountBalance[user][toAccount];
                                Console.WriteLine($"Konto: " + bankAccountTo);
                                Console.WriteLine($"Saldo: " + balanceOfAccountTo);
                                Console.WriteLine("---------------------");

                                transferBool = false;
                            }
                        }
                    }
                }
            }
        }
        public static void WithdrawMoney(int userNumber, int[] userNameArray, int[] userPassArray, string[][] bankAccounts, decimal[][] accountBalance) //Method for withdraw money
        {
            bool transferBool = true;
            UserConfirmation(userNumber, userNameArray, bankAccounts, accountBalance);
            int user = Array.IndexOf(userNameArray, userNumber);

            while (transferBool)
            {
                Console.WriteLine("Välj konto att ta ut pengar från: ");
                int fromAccount = Int32.Parse(Console.ReadLine()) - 1;

                if (fromAccount < 0 || fromAccount > bankAccounts[user].Length - 1) //Errormessage if user input is lower or higher than number of accounts.
                {
                    Console.WriteLine("Ogiltigt val av konto!");
                }
                else
                {
                    Console.WriteLine("Skriv den summa du vill ta ut: ");
                    decimal transferSum = decimal.Parse(Console.ReadLine());
                    if (transferSum <= 0)
                    {
                        Console.WriteLine("Ogiltigt inmatning. Du måste ange en summa högre än 0.\n");
                    }
                    else if (transferSum > accountBalance[user][fromAccount])
                    {
                        Console.WriteLine("Ogiltigt inmatning. Du kan inte ta ut mer pengar än vad som finns tillgängligt på kontot.\n");
                    }
                    else if (transferSum > 0 || transferSum < accountBalance[user][fromAccount])
                    {
                        int counter = 0;
                        bool myBool = true; ;
                        while (myBool)
                        {
                            Console.WriteLine("Ange lösenord för att bekräfta uttag: ");
                            int withdrawPass = Int32.Parse(Console.ReadLine());
                            if (withdrawPass == userPassArray[user])        //Confirm user input with index of password-array
                            {
                                Console.WriteLine("\nUttag bekräftat!");
                                accountBalance[user][fromAccount] = accountBalance[user][fromAccount] - transferSum; //Do transaction
                                Console.WriteLine("\nNytt saldo:\n");
                                string bankAccount = bankAccounts[user][fromAccount];
                                decimal balanceOfAccount = accountBalance[user][fromAccount];
                                Console.WriteLine($"Konto: " + bankAccount);
                                Console.WriteLine($"Saldo: " + balanceOfAccount);
                                Console.WriteLine("-----------------------");
                                myBool = false;
                                transferBool = false;
                            }
                            else
                            {
                                Console.WriteLine("Fel lösenord.");
                                counter++;
                            }
                            if (counter == 3)
                            {
                                Console.WriteLine("För många verifieringsförsök. Transaktion avbruten.");
                                myBool = false;
                                transferBool = false;
                            }
                        }
                    }
                }
            }
        }
        static void UserConfirmation(int userNumber, int[] userNameArray, string[][] bankAccounts, decimal[][] accountBalance) //Method for user confirmation
        {
            int user = Array.IndexOf(userNameArray, userNumber);//Collect indexvalue
            for (int i = 0; i < bankAccounts[user].Length; i++)//For-loop to print length of specified users bankaccounts.
            {
                string bankAccount = bankAccounts[user][i];
                decimal balanceOfAccount = accountBalance[user][i];
                Console.WriteLine($"Konto: " + bankAccount);
                Console.WriteLine($"Saldo: " + balanceOfAccount);
                Console.WriteLine("-----------------------");
            }
        }
    }
}
