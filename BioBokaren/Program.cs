using System;

class SimpleCinemaBooking
{
    static void Main()
    {
        // Movies and prices
        string[] movies = { "Avatar", "Titanic", "Inception", "The Matrix" };
        double[] prices = { 150, 100, 180, 125 };
        const double STUDENT_DISCOUNT = 0.15;  //15% rabatt
        const double TAX = 0.25; // 25% moms
        const string CURRENCY = "SEK";

        // Show movies


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Välkommen till Simple Cinema Booking!");
        Console.ResetColor();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Välj en film:");
        for (int i = 0; i < movies.Length; i++)
        {
            double priceWithTax = prices[i] * (1 + TAX);
            Console.WriteLine($"{i + 1}. {movies[i]} - {priceWithTax:F2} {CURRENCY} (inkl. moms)");
        }

        // Choose movie
        Console.Write("Ange filmnummer: ");
        int choice = int.Parse(Console.ReadLine());
        string movie = movies[choice - 1];
        double basePrice = prices[choice - 1];

        // Tickets
        Console.Write("Antal biljetter: ");
        int tickets = int.Parse(Console.ReadLine());

        // Student?
        Console.Write("Är du student? (j/n): ");
        bool isStudent = Console.ReadLine().ToLower() == "j";

        if (isStudent)
        {
            Console.WriteLine(" Studentrabatt aktiverad.");
        }
        else
        {
            Console.WriteLine("Ingen rabatt (endast studenter får rabatt).");
        }


        // Calculate price
        double pricePerTicket = isStudent ? basePrice * (1 - STUDENT_DISCOUNT) : basePrice;
        double total = tickets * pricePerTicket * (1 + TAX);
        Console.ReadLine();

        // Receipt
        Console.WriteLine("KVITTO");
        Console.WriteLine($"Film: {movie}");
        Console.WriteLine($"Antal biljetter: {tickets}");
        Console.WriteLine($"Studentrabatt: {(isStudent ? "Ja" : "Nej")}");
        Console.WriteLine($"Totalt pris (inkl. moms): {total:F2} {CURRENCY}");

        Console.WriteLine("Tack för att du bokade med Simple Cinema Booking!");

    }
}





