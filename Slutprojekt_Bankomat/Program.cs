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
                new string[] {"Bankkonto", "Sparkonto", "Pensionskonto", "Aktier"},
                new string[] {"Bankkonto", "Sparkonto", "Pensionskonto"},
                new string[] {"Bankkonto", "Sparkonto"},
                new string[] {"Sparkonto"},
                new string[] {"Sparkonto"}
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
                        }

                        switch (menuChoice)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Se konton och saldo:\n");
                                AccountBalance(userNumber, userNameArray, bankAccounts, accountBalance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();

                                //Metod för konton och saldo
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Överföring");
                                TransferMoney(userNumber, userNameArray, bankAccounts, accountBalance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();
                                //Metod för överföring
                                break;

                            case 3:
                                //Console.Clear();
                                //Console.WriteLine("Ta ut pengar");
                                //WithdrawMoney(userNumber, userNameArray, userBalanceArray, userSavingsArray);
                                //Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                //Console.ReadKey();
                                //Metod för uttag
                                break;

                            case 4:
                                Console.Clear();
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
        public static void AccountBalance(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
        {
            int userIndex = Array.IndexOf(userNameArray, userName);

            for (int i = 0; i < bankAccounts[userIndex].Length; i++)
            {
                string bankAccount = bankAccounts[userIndex][i];
                double balanceOfAccount = accountBalance[userIndex][i];

                Console.WriteLine("Konto: " + bankAccount);
                Console.WriteLine("Saldo: " + balanceOfAccount);
                Console.WriteLine("---------------------");
            }

        }
    }
    public static void TransferMoney(int userName, int[] userNameArray, string[][] bankAccounts, double[][] accountBalance)
    {
        int userIndex = Array.IndexOf(userNameArray, userName);
        int fromAccount;
        int toAccount;
        int amount;

        for (int i = 0; i < bankAccounts[userIndex].Length; i++)
        {
            string bankAccount = bankAccounts[userIndex][i];
            double balanceOfAccount = accountBalance[userIndex][i];

            Console.WriteLine("Konto: " + bankAccount);
            Console.WriteLine("Saldo: " + balanceOfAccount);
            Console.WriteLine("---------------------");
        }

        Console.WriteLine("\nVälj ett konto att föra över pengar ifrån: ");
        fromAccount = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Välj ett konto att föra över pengar till: ");
        toAccount = Convert.ToInt32(Console.ReadLine());

        if (userIndex == fromAccount + 1)
        {

        }
        
    }
}

            //accounts[userIndex, fromAccount - 1, 1] = (int)accounts[userIndex, fromAccount - 1, 1] - amount;
            //accounts[userIndex, toAccount - 1, 1] = (int)accounts[userIndex, toAccount - 1, 1] + amount;



//        public static void TransferMoney(int userName, int[] userNameArray, int[] userBalanceArray, int[] userSavingsArray, int[] userPensionArray, int[] userLifeInsurance)
//        {

//            int userBalance = userBalanceArray[userIndex];
//            int userSavings = userSavingsArray[userIndex];
//            int userPension = userPensionArray[userIndex];
//            int userStock = userLifeInsurance[userIndex];

//            if (userName == 850128)
//            {
//                Console.WriteLine("Vilket konto vill du för över ifrån?: ");                
//                Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//                Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
//                Console.WriteLine("[4] Aktier - Saldo: " + userStock);
//                int fromAccount = Int32.Parse(Console.ReadLine());
//                if(fromAccount == 1)
//                {
//                    Console.WriteLine("Vilket konto vill du föra över till?: ");
//                    Console.WriteLine("[1] Sparkonto - Saldo: " + userSavings);
//                    Console.WriteLine("[2] Pensionskonto - Saldo: " + userPension);
//                    Console.WriteLine("[3] Aktier - Saldo: " + userStock);

//                }
//                else if(fromAccount == 2)
//                {
//                    Console.WriteLine("Vilket konto vill du föra över till?: ");
//                    Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                    Console.WriteLine("[2] Pensionskonto - Saldo: " + userPension);
//                    Console.WriteLine("[3] Aktier - Saldo: " + userStock);
//                }
//                else if(fromAccount == 3)
//                {
//                    Console.WriteLine("Vilket konto vill du föra över till?: ");
//                    Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                    Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//                    Console.WriteLine("[3] Aktier - Saldo: " + userStock);
//                }
//                else if(fromAccount == 4)
//                {
//                    Console.WriteLine("Vilket konto vill du föra över till?: ");
//                    Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                    Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//                    Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
//                }



//                //Console.WriteLine("Vilket konto vill du föra över till?: ");
//                //Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                //Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//                //Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
//                //Console.WriteLine("[4] Livförsäkring - Saldo: " + userLifeIn);
//                //int ToAccount = Int32.Parse(Console.ReadLine());



//                //int amount;
//                //Console.WriteLine("Vilket konto vill du föra över pengar ifrån?");
//                //Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                //Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//                //Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
//                //Console.WriteLine("[4] Livförsäkring - Saldo: " + userLifeIn);
//                //int accountFrom = Int32.Parse(Console.ReadLine());
//                //Console.WriteLine("Vilket konto vill du föra över pengar till?");
//                //Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//                //Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//                //Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
//                //Console.WriteLine("[4] Livförsäkring - Saldo: " + userLifeIn);
//                //int accountTo = Int32.Parse(Console.ReadLine());


//                //if (accountFrom)
//                //{
//                //    Console.WriteLine("Hur mycket pengar vill du föra över?: ");
//                //    amount = Int32.Parse(Console.ReadLine());
//                //    userBalanceArray[userIndex] = userBalance - amount;
//                //    userSavingsArray[userIndex] = userSavings + amount;
//                //    Console.WriteLine("Nytt saldo Bankkonto: " + userBalanceArray[userIndex]);
//                //    Console.WriteLine("Nytt saldo Sparkonto: " + userSavingsArray[userIndex]);

//                //}
//                //else if (account == 2)
//                //{
//                //    Console.WriteLine("Hur mycket pengar vill du föra över?: ");
//                //    amount = Int32.Parse(Console.ReadLine());
//                //    userBalanceArray[userIndex] = userBalance + amount;
//                //    userSavingsArray[userIndex] = userSavings - amount;
//                //    Console.WriteLine("Nytt saldo Bankkonto: " + userBalanceArray[userIndex]);
//                //    Console.WriteLine("Nytt saldo Sparkonto: " + userSavingsArray[userIndex]);
//                //}
//                //else if(account == 3)
//                //{

//                //}
//                //else
//                //{

//                //}
//            }
//        }
//        public static void WithdrawMoney(int userName, int[] userNameArray, int[] userBalanceArray, int[] userSavingsArray)
//        {
//            int userIndex = Array.IndexOf(userNameArray, userName);
//            int userBalance = userBalanceArray[userIndex];
//            int userSavings = userSavingsArray[userIndex];
//            Console.WriteLine("Vilket konto vill du ta ut pengar ifrån?");
//            Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
//            Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
//            int account = Int32.Parse(Console.ReadLine());
//            int amount;

//            if (account == 1)
//            {
//                Console.WriteLine("Hur mycket pengar vill du ta ut?: ");
//                amount = Int32.Parse(Console.ReadLine());
//                userBalanceArray[userIndex] = userBalance - amount;
//                Console.WriteLine("Nytt saldo Bankkonto: " + userBalanceArray[userIndex]);
//            }
//            else if (account == 2)
//            {
//                Console.WriteLine("Hur mycket pengar vill du ta ut?: ");
//                amount = Int32.Parse(Console.ReadLine());
//                userSavingsArray[userIndex] = userSavings - amount;
//                Console.WriteLine("Nytt saldo Sparkonto: " + userSavingsArray[userIndex]);
//            }
//        }
//    }
//}

