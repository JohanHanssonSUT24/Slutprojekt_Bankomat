namespace Slutprojekt_Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] userArray = new string[5, 3] { { "1", "Johan", "1234" }, { "2", "Jenny", "1234" }, { "3", "Thea", "1234" }, { "4", "Tage", "1234" }, { "5", "Otto","1234"} };
            Console.WriteLine("Välkommen till Bankomaten!");
            Console.WriteLine("Skriv ditt användarnamn:");
            string userName = Console.ReadLine();
            Console.WriteLine("Ange din PIN: ");
            string userPin = Console.ReadLine();

        }
    }
}
