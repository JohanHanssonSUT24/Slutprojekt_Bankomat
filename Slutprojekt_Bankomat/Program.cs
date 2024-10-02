namespace Slutprojekt_Bankomat
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Create arrays for users accountname, password, bankaccount and savingsaccount.
            int[] userNameArray = new int[] { 850128, 890918, 100723, 180423, 230110 };
            int[] userPassArray = new int[] { 1111, 2222, 3333, 4444, 5555 };
            int[] userBalanceArray = new int[] { 22034, 101455, 11003, 8078, 3452 };
            int[] userSavingsArray = new int[] { 12503, 202434, 30078, 4054, 599 };
            int[] userPensionArray = new int[] { 150138, 234098 };
            int[] userLifeInsurance = new int[] { 340986 };

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
                                Console.WriteLine("Se konton och saldo:");
                                AccountBalance(userNumber, userNameArray, userBalanceArray, userSavingsArray, userPensionArray, userLifeInsurance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();

                                //Metod för konton och saldo
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Överföring");
                                TransferMoney(userNumber, userNameArray, userBalanceArray, userSavingsArray, userPensionArray, userLifeInsurance);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();
                                //Metod för överföring
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Ta ut pengar");
                                WithdrawMoney(userNumber, userNameArray, userBalanceArray, userSavingsArray);
                                Console.WriteLine("\n\nKlicka på valfri tangent för att återvända till menyn.");
                                Console.ReadKey();
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
        public static int AccountBalance(int userName, int[] userNameArray, int[] userBalanceArray, int[] userSavingsArray, int[] userPensionArray, int[] userLifeInsurance)
        {
            if (userName == 850128)
            {
                Console.WriteLine("Bankkonto: " + userBalanceArray[Array.IndexOf(userNameArray, userName)]);
                Console.WriteLine("Sparkonto: " + userSavingsArray[Array.IndexOf(userNameArray, userName)]);
                Console.WriteLine("Pensionkonto: " + userPensionArray[Array.IndexOf(userNameArray, userName)]);
                Console.WriteLine("Aktier: " + userLifeInsurance[Array.IndexOf(userNameArray, userName)]);
            }
            else if (userName == 890918)
            {
                Console.WriteLine("Bankkonto: " + userBalanceArray[Array.IndexOf(userNameArray, userName)]);
                Console.WriteLine("Sparkonto: " + userSavingsArray[Array.IndexOf(userNameArray, userName)]);
                Console.WriteLine("Pensionkonto: " + userPensionArray[Array.IndexOf(userNameArray, userName)]);
            }
            else
            {
                Console.WriteLine("Sparkonto: " + userSavingsArray[Array.IndexOf(userNameArray, userName)]);
            }
            return userNameArray[0];

        }
        public static void TransferMoney(int userName, int[] userNameArray, int[] userBalanceArray, int[] userSavingsArray, int[] userPensionArray, int[] userLifeInsurance)
        {
            int userIndex = Array.IndexOf(userNameArray, userName);
            int userBalance = userBalanceArray[userIndex];
            int userSavings = userSavingsArray[userIndex];
            int userPension = userPensionArray[userIndex];
            int userStock = userLifeInsurance[userIndex];

            if (userName == 850128)
            {
                Console.WriteLine("Vilket konto vill du för över ifrån?: ");                
                Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
                Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
                Console.WriteLine("[4] Aktier - Saldo: " + userStock);
                int fromAccount = Int32.Parse(Console.ReadLine());
                if(fromAccount == 1)
                {
                    Console.WriteLine("Vilket konto vill du föra över till?: ");
                    Console.WriteLine("[1] Sparkonto - Saldo: " + userSavings);
                    Console.WriteLine("[2] Pensionskonto - Saldo: " + userPension);
                    Console.WriteLine("[3] Aktier - Saldo: " + userStock);

                }
                else if(fromAccount == 2)
                {
                    Console.WriteLine("Vilket konto vill du föra över till?: ");
                    Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                    Console.WriteLine("[2] Pensionskonto - Saldo: " + userPension);
                    Console.WriteLine("[3] Aktier - Saldo: " + userStock);
                }
                else if(fromAccount == 3)
                {
                    Console.WriteLine("Vilket konto vill du föra över till?: ");
                    Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                    Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
                    Console.WriteLine("[3] Aktier - Saldo: " + userStock);
                }
                else if(fromAccount == 4)
                {
                    Console.WriteLine("Vilket konto vill du föra över till?: ");
                    Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                    Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
                    Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
                }

                //Console.WriteLine("Vilket konto vill du föra över till?: ");
                //Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                //Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
                //Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
                //Console.WriteLine("[4] Livförsäkring - Saldo: " + userLifeIn);
                //int ToAccount = Int32.Parse(Console.ReadLine());



                //int amount;
                //Console.WriteLine("Vilket konto vill du föra över pengar ifrån?");
                //Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                //Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
                //Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
                //Console.WriteLine("[4] Livförsäkring - Saldo: " + userLifeIn);
                //int accountFrom = Int32.Parse(Console.ReadLine());
                //Console.WriteLine("Vilket konto vill du föra över pengar till?");
                //Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
                //Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
                //Console.WriteLine("[3] Pensionskonto - Saldo: " + userPension);
                //Console.WriteLine("[4] Livförsäkring - Saldo: " + userLifeIn);
                //int accountTo = Int32.Parse(Console.ReadLine());


                //if (accountFrom)
                //{
                //    Console.WriteLine("Hur mycket pengar vill du föra över?: ");
                //    amount = Int32.Parse(Console.ReadLine());
                //    userBalanceArray[userIndex] = userBalance - amount;
                //    userSavingsArray[userIndex] = userSavings + amount;
                //    Console.WriteLine("Nytt saldo Bankkonto: " + userBalanceArray[userIndex]);
                //    Console.WriteLine("Nytt saldo Sparkonto: " + userSavingsArray[userIndex]);

                //}
                //else if (account == 2)
                //{
                //    Console.WriteLine("Hur mycket pengar vill du föra över?: ");
                //    amount = Int32.Parse(Console.ReadLine());
                //    userBalanceArray[userIndex] = userBalance + amount;
                //    userSavingsArray[userIndex] = userSavings - amount;
                //    Console.WriteLine("Nytt saldo Bankkonto: " + userBalanceArray[userIndex]);
                //    Console.WriteLine("Nytt saldo Sparkonto: " + userSavingsArray[userIndex]);
                //}
                //else if(account == 3)
                //{

                //}
                //else
                //{

                //}
            }
        }
        public static void WithdrawMoney(int userName, int[] userNameArray, int[] userBalanceArray, int[] userSavingsArray)
        {
            int userIndex = Array.IndexOf(userNameArray, userName);
            int userBalance = userBalanceArray[userIndex];
            int userSavings = userSavingsArray[userIndex];
            Console.WriteLine("Vilket konto vill du ta ut pengar ifrån?");
            Console.WriteLine("[1] Bankkonto - Saldo: " + userBalance);
            Console.WriteLine("[2] Sparkonto - Saldo: " + userSavings);
            int account = Int32.Parse(Console.ReadLine());
            int amount;

            if (account == 1)
            {
                Console.WriteLine("Hur mycket pengar vill du ta ut?: ");
                amount = Int32.Parse(Console.ReadLine());
                userBalanceArray[userIndex] = userBalance - amount;
                Console.WriteLine("Nytt saldo Bankkonto: " + userBalanceArray[userIndex]);
            }
            else if (account == 2)
            {
                Console.WriteLine("Hur mycket pengar vill du ta ut?: ");
                amount = Int32.Parse(Console.ReadLine());
                userSavingsArray[userIndex] = userSavings - amount;
                Console.WriteLine("Nytt saldo Sparkonto: " + userSavingsArray[userIndex]);
            }
        }
    }
}

