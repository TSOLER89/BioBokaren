namespace BioBokaren
{
    internal class CinemaBookingApp
    {
        // Constants
        const double TAX_RATE = 0.6;
        const double STUDENT_DISCOUNT = 0.15;
        const string CURRENCY = "SEK";

        // Arrays
        static string[] movies = { "Avatar", "Titanic", "Inception", "The Matrix" };
        static double[] ticketPrices = { 120.0, 100.0, 150.0, 130.0 };
        static string[] showTimes = { "12:00", "15:00", "18:00", "21:00" };

        // State variables
        static int selectedMovieIndex = -1;
        static int selectedShowTimeIndex = -1;
        static int numberOfTickets = 0;
        static bool isStudent = false;

        static void Main()
        {
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListMovies(movies, showTimes, ticketPrices);
                        break;
                    case "2":
                        SelectMovieAndTickets();
                        break;
                    case "3":
                        Console.WriteLine("Visningstid väljs med film.");
                        break;
                    case "4":
                        EnterTickets();
                        break;
                    case "5":
                        ToggleStudentDiscount();
                        break;
                    case "6":
                        if (selectedMovieIndex >= 0 && selectedShowTimeIndex >= 0 && numberOfTickets > 0)
                        {
                            double total = CalculatePric(
                                numberOfTickets,
                                ticketPrices[selectedMovieIndex],
                                isStudent ? STUDENT_DISCOUNT : 0
                            ) * (1 + TAX_RATE);

                            GenerateReceipt(
                                movies[selectedMovieIndex],
                                showTimes[selectedShowTimeIndex],
                                numberOfTickets,
                                total,
                                isStudent
                            );
                        }
                        else
                        {
                            Console.WriteLine("❗ Du måste välja film, tid och biljetter först.");
                        }
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("Tack för att du använde BioBokaren! Hej då!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("BioBokaren - Meny");
            Console.WriteLine("1. Visa filmer");
            Console.WriteLine("2. Välj film och tid");
            Console.WriteLine("3. (Hoppa - redan vald i steg 2)");
            Console.WriteLine("4. Ange antal biljetter");
            Console.WriteLine("5. Student? (växla rabatt)");
            Console.WriteLine("6. Skriv ut kvitto");
            Console.WriteLine("7. Avsluta");
            Console.Write("Välj ett alternativ: ");
        }

        static void ListMovies(string[] movies, string[] times, double[] basePrices)
        {
            Console.WriteLine("\n📽️ Tillgängliga filmer:");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i]} - Tid: {times[i]} - Pris: {basePrices[i]} {CURRENCY}");
            }
        }

        static void SelectMovieAndTickets()
        {
            Console.Write("Ange filmnummer: ");
            if (int.TryParse(Console.ReadLine(), out int movieIndex) && movieIndex >= 1 && movieIndex <= movies.Length)
                selectedMovieIndex = movieIndex - 1;
            else
            {
                Console.WriteLine("Ogiltigt filmnummer.");
                return;
            }

            Console.Write("Ange visningstidens nummer: ");
            if (int.TryParse(Console.ReadLine(), out int timeIndex) && timeIndex >= 1 && timeIndex <= showTimes.Length)
                selectedShowTimeIndex = timeIndex - 1;
            else
            {
                Console.WriteLine("Ogiltigt tidnummer.");
            }
        }

        static void EnterTickets()
        {
            Console.Write("Ange antal biljetter: ");
            if (int.TryParse(Console.ReadLine(), out int tickets) && tickets > 0)
                numberOfTickets = tickets;
            else
                Console.WriteLine("Ogiltigt antal biljetter.");
        }

        static void ToggleStudentDiscount()
        {
            isStudent = !isStudent;
            Console.WriteLine(isStudent ? "✅ Studentrabatt aktiverad." : "❌ Studentrabatt avaktiverad.");
        }

        static double CalculatePric(int tickets, double basePrice, double discountPercent)
        {
            double discountedPrice = basePrice * (1 - discountPercent);
            return tickets * discountedPrice;
        }

        static void GenerateReceipt(string movie, string time, int tickets, double total, bool isStudent)
        {
            Console.WriteLine("\n🧾 KVITTO");
            Console.WriteLine($"Film: {movie}");
            Console.WriteLine($"Tid: {time}");
            Console.WriteLine($"Antal biljetter: {tickets}");
            Console.WriteLine($"Studentrabatt: {(isStudent ? "Ja" : "Nej")}");
            Console.WriteLine($"Totalt pris (inkl. moms): {total:F2} {CURRENCY}");
        }
    }
}


