using System;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            string cont;
            do
            {
                Console.WriteLine("1) Create a ticket.");
                Console.WriteLine("2) See open tickets.");
                Console.WriteLine("Any other key to EXIT.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    StreamWriter sw = new StreamWriter(file);
                    do{
                        //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
                        Console.WriteLine("Enter the ticket ID");
                        string ticketID = Console.ReadLine();

                        Console.WriteLine("Enter a summary for this ticket.");
                        string summary = Console.ReadLine();

                        Console.WriteLine("Enter ticket status.");
                        string status = Console.ReadLine();

                        Console.WriteLine("Enter ticket priority.");
                        string priority = Console.ReadLine();

                        Console.WriteLine("Enter the ticket submitter");
                        string submitter = Console.ReadLine();

                        Console.WriteLine("Enter who the ticket is assigned to.");
                        string assigned = Console.ReadLine();

                        string watching = "";
                        string addWatcher;
                        do
                        {
                            Console.WriteLine("Enter who is watching the ticket");
                            watching = watching + Console.ReadLine();
                            Console.WriteLine("Press Y to enter another watcher.");
                            Console.WriteLine("Any other key to EXIT.");
                            addWatcher = Console.ReadLine().ToUpper();
                            if(addWatcher == "Y")
                            {
                                watching = watching + "|";
                            }
                        }while(addWatcher == "Y");

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, summary, status, priority, submitter, assigned, watching);

                        Console.WriteLine("Press Y to enter another ticket.");
                        Console.WriteLine("Any other key to EXIT.");
                        cont = Console.ReadLine().ToUpper();
                    }while(cont == "Y");
                    sw.Close();
                }
                else if (choice == "2")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string ticketline = sr.ReadLine();
                            string[] ticket = ticketline.Split(',');
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticket[0], ticket[1], ticket[2], ticket[3], ticket[4], ticket[5], ticket[6]);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
            } while (choice == "1" || choice == "2");
        }
    }
}