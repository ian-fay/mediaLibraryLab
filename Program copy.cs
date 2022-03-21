// Repository:  MediaLibrary
// Author:      Jeff Grissom
// Version:     1.xx

using System;
using NLog.Web;
using System.IO;
using System.Linq;

namespace MediaLibrary
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

            logger.Info("Program started");

            string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
            logger.Info(scrubbedFile);
            MovieFile movieFile = new MovieFile(scrubbedFile);

            Console.ForegroundColor = ConsoleColor.Green;
            String choice = "";

            do {
            Console.WriteLine("Media Library Menu: Movie Section");
            Console.WriteLine("1) Display All Movies:");
            Console.WriteLine("2) Add New Movie to File:");
            Console.WriteLine("3) Find Movie (Title):");
            Console.WriteLine("Enter any key to exit.");
            choice = Console.ReadLine();

                if(choice == "1") {
                    Console.WriteLine("This button displays all movies.");
                } else if(choice == "2") {
                    Console.WriteLine("This button adds new movies.");
                } else if(choice == "3") {
                    Console.WriteLine("Enter the Title you want to search for.");
                    choice = Console.ReadLine();

                var SearchMovie = movieFile.Movies.Where(m => m.title.Contains(choice)).Select(m => m.title);
                Console.WriteLine($"There are {SearchMovie.Count()} movies with \"{choice}\" in the title:");
                    foreach(string m in SearchMovie)
                    {
                        Console.WriteLine($"  {m}");
                    }
                }

            } while (choice == "1" || choice == "2" || choice == "3");


            Console.ForegroundColor = ConsoleColor.White;
            logger.Info("Program ended");

        }
    }
}
