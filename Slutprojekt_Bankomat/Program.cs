namespace Slutprojekt_Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] userNameArray = new string[5];
            string[] userPassArray = new string[5];
            userNameArray[0] = "Johan";
            userPassArray[0] = "Ananas";
            userNameArray[1] = "Jenny";
            userPassArray[1] = "Banan";
            userNameArray[2] = "Thea";
            userPassArray[2] = "Äpple";
            userNameArray[3] = "Tage";
            userPassArray[3] = "Melon";
            userNameArray[4] = "Otto";
            userPassArray[4] = "Vindruva";

            Console.WriteLine("Skriv ditt användarnamn: ");
            string userNameInput = Console.ReadLine();

            Console.WriteLine(userNameArray[userNameInput]);
            string userNameIndex = Console.ReadLine();

            if (userNameIndex == userPassArray[userNameInput])
            {
                Console.WriteLine("Du skrev rätt!");

            }



        }
    }
}
