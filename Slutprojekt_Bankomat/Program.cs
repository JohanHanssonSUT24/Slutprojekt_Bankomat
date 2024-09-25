namespace Slutprojekt_Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] userNameArray = new int[5];
            int[] userPassArray = new int[5];
            userNameArray[0] = 850128;
            userPassArray[0] = 1111;
            userNameArray[1] = 890918;
            userPassArray[1] = 2222;
            userNameArray[2] = 100723;
            userPassArray[2] = 3333;
            userNameArray[3] = 180423;
            userPassArray[3] = 4444;
            userNameArray[4] = 230110;
            userPassArray[4] = 5555;

            bool correctLoggin = false;
            int userLoggins = 0;

            Console.WriteLine("Skriv ditt personnummer: ");
            int userNumber = Int32.Parse(Console.ReadLine());


            while (!correctLoggin && userLoggins < 3)
            {

                Console.WriteLine("Skriv ditt lösenord: ");
                int userPass = Int32.Parse(Console.ReadLine());
                if (userPass == userPassArray[Array.IndexOf(userNameArray, userNumber)])
                {
                    bool menuBool = true;
                    while (menuBool)
                    {
                        Console.WriteLine("Välkommen!");
                        Console.WriteLine("Var god välj ett av följande alternativ.");
                        Console.WriteLine("[1] Se dina konton och saldo");
                        Console.WriteLine("[2] Överföring mellan konton");
                        Console.WriteLine("[3] Ta ut pengar");
                        Console.WriteLine("[4] Avsluta programmet");

                        int userChoice = Int32.Parse(Console.ReadLine());

                        switch (userChoice)
                        {
                            case 1:
                                
                                break;

                            case 2:

                                break;

                            case 3:

                                break;

                            case 4:
                                Console.WriteLine("Tack för besöket. Vi ses nästa gång!");
                                menuBool = false;
                                break;

                        }

                    }

                }
                else
                {
                    Console.WriteLine("Felaktigt lösenord");
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
}
