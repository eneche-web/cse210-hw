using System;


class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            
            Console.WriteLine("Mindfulness Program");

            Console.WriteLine("-----------------------------");

            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("Quit");

            Console.WriteLine();
            Console.WriteLine("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":

                BreathingActivity breathing = new BreathingActivity();

                breathing.Run();
                break;

                case "2":

                ReflectionActivity reflection = new ReflectionActivity();

                reflection.Run();
                break;

                case "3":

                ListingActivity listing = new ListingActivity();

                listing.Run();
                break;

                case "4":

                GratitudeActivity gratitude = new GratitudeActivity();

                gratitude.Run();
                break;

                case "5":
                ActivityLog log = new ActivityLog();
                log.DisplayLog();
                break;

                case "6":

                Console.WriteLine("Thank you for using the Mindfullness Program.");
                break;

                default:

                Console.WriteLine("Invalid choice. Please try again.");

                Console.WriteLine("Press Enter to continue.....");
                break;
            }
        }
    }
}