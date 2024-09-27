namespace Slutprojekt_Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] userNameArray = new int[] { 850128, 890918, 100723, 180423, 230110 };
            int[] userPassArray = new int[] { 1111, 2222, 3333, 4444, 5555 };

            bool correctLoggin = false;
            int userPass;
            int userLoggins = 0;

            Console.WriteLine("Välkommen till DinBank!");
            Console.WriteLine("Skriv ditt personnummer: ");
            int userNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Skriv ditt lösenord: ");

            while (!correctLoggin && userLoggins < 3)
            {

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
                        Console.WriteLine("[4] Avsluta programmet");



                        int menuChoice;
                        while (!Int32.TryParse(Console.ReadLine(), out menuChoice))
                        {
                            Console.WriteLine("Felaktig input!\nAnge alt 1 - 4. ");
                        }

                        switch (menuChoice)
                        {
                            case 1:
                                Console.WriteLine("Dina konton och saldon");
                                Console.WriteLine($"Konto med nummer {userNumber} har saldo: { AccountBalance(userNumber) }" );
                                Console.ReadKey();
                                //Metod för konton och saldo
                                break;

                            case 2:
                                Console.WriteLine("Intern överföring");
                                Console.ReadKey();
                                //Metod för överföring
                                break;

                            case 3:
                                Console.WriteLine("Ta ut pengar");
                                Console.ReadKey();
                                //Metod för uttag
                                break;

                            case 4:
                                Console.Write("Tack för besöket. Vi ses nästa gång!");
                                menuBool = false;
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
        public static int AccountBalance(int userName)
        {
            int[] userNameArray = new int[] { 850128, 890918, 100723, 180423, 230110 };
            int[] userBalanceArray = new int[] { 22034, 101455, 11003, 8078, 3452 };

            Console.WriteLine(userBalanceArray[Array.IndexOf(userNameArray, userName)]);

                return userBalanceArray[0];



            //Console.WriteLine("Välkommen till DinBank!");
            //Console.WriteLine("Skriv ditt personnummer: ");
            //int userNumber = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Skriv ditt lösenord: ");

            //while (!correctLoggin && userLoggins < 3)
            //{

            //    userPass = Int32.Parse(Console.ReadLine());
            //    if (userPass == userPassArray[Array.IndexOf(userNameArray, userNumber)])





        }
    }
}
